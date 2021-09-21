using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderingAPI.Helpers;
using OrderingAPI.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using static OrderingAPI.Model.Responce;

namespace OrderingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebHookController : ControllerBase
    {
        private readonly ILogger<WebHookController> _logger;
        public string WebHookURL = "https://pos-int.urbanpiper.com/external/api/v1/webhooks";
        public string WebHookCallBackURL = "";
        public string _accessToken = "apikey biz_adm_clients_maWLBzMzwGJi:2acfa77b49743cbe61aeb613135b14e85697acbc";

        public WebHookController(ILogger<WebHookController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation($"WebhooksController.Get Method");
            return await ApiCall<WebHooks>(HttpAttribute.GET, $"{WebHookURL}/");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation($"WebhooksController.Get webhooksId - [{id}] Method");
            return await ApiCall<WebHook>(HttpAttribute.GET, $"{WebHookURL}/{id}/");
        }

        [HttpPost]
        public async Task<IActionResult> Post(WebHookRequest webHookRequest)
        {
            _logger.LogInformation($"WebhooksController.Post Method");
            return await ApiCall<WebHookResponce>(HttpAttribute.POST, $"{WebHookURL}/", Helper.SerializeObject(webHookRequest));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] WebHookRequest webHookRequest)
        {
            _logger.LogInformation($"WebhooksController.Put webhooksId - [{id}] Method");
            return await ApiCall<WebHookResponce>(HttpAttribute.PUT, $"{WebHookURL}/{id}/", Helper.SerializeObject(webHookRequest));
        }

        [Route("CreateAllWebHook")]
        [HttpPost]
        public async Task<IActionResult> CreateAllWebHook(WebHookRequest webHookRequest)
        {
            _logger.LogInformation($"WebhooksController.Post Method");
            return await ApiCall<WebHooks>(HttpAttribute.GET, $"{WebHookURL}/");
        }

        [Route("UpdateWebHookURL")]
        [HttpPost]
        public async Task<IActionResult> UpdateWebHookURL(WebHookEvent webHookEvent, String Url)
        {
            var actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            var controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            try
            {
                _logger.LogInformation($"{controllerName}Controller.{actionName} method called!!!");

                if (webHookEvent.ToString() == "all")
                {
                    _logger.LogInformation($"{actionName} event Type {webHookEvent} Update All webhook");

                    var AllWebHook = await HttpApiCall<WebHooks>(HttpAttribute.GET, $"{WebHookURL}/");

                    if (AllWebHook != null && AllWebHook.result != null)
                    {
                        var _webHookList = ((WebHooks)AllWebHook.result).webhooks.Where(w=>w.active == true);
                        _webHookList = _webHookList.Where(w => w.active == true);
                        foreach (var webhook in _webHookList)
                        {
                            try
                            {
                                var webhookEventIndex = webhook.event_type;
                                var callBackMethod = Helper.WebHookCallBackMethod.Where(k=> k.Key == webhookEventIndex);


                                var id = webhook.webhook_id;
                                var h = webhook.headers;
                                var uri = new Uri(webhook.url);
                                string host = uri.Host;
                                string scheme = uri.Scheme;
                                int port = uri.Port;
                                var baseUri = uri.GetLeftPart(System.UriPartial.Authority);

                                var urlBuilder = new UriBuilder(webhook.url);

                                urlBuilder.Host = Url;

                                var req = new WebHookRequest()
                                {
                                    active = true,
                                    event_type = webhook.event_type.ToString(),
                                    headers = new Headers() { ContentType = "application/json", x_api_token = "4trgfdsfd243tg54342rewfcef" },
                                    retrial_interval_units = "seconds",
                                    url= urlBuilder.Uri.ToString()
                                    //url = $"{Url}/api/WebHookCallBack/{callBackMethod}"
                                    //https://2748-106-203-216-58.ngrok.io/api/WebHookCallBack/StoresAddUpdate"
                                };
                                _logger.LogInformation($"{actionName} ID {id} Update All webhook");
                                var updateRes = await HttpApiCall<WebHooks>(HttpAttribute.PUT, $"{WebHookURL}/{id}/", Helper.SerializeObject(req));

                                _logger.LogInformation($"{actionName} ID {id} Update responce {updateRes}");
                            }
                            catch (Exception ex)
                            {
                                _logger.LogInformation($"{controllerName}Controller.{actionName} Error while reading callBackMethod name - {ex}");
                                continue;
                            }
                        }
                    }
                }
                else
                {
                    var t = webHookEvent.ToString();
                }

                ///
                _logger.LogInformation($"WebhooksController.Post Method");
                var res = await HttpApiCall<WebHooks>(HttpAttribute.GET, $"{WebHookURL}/");

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{controllerName}Controller.{actionName} Error {ex}");
                return BadRequest(ex);
            }
        }

        #region API Call -

        // TODO - Move this to commoun file
        private async Task<HttpResponce> HttpApiCall<T>(HttpAttribute HttpMethod, string Url, string JsonRequest = null)
        {
            var res = new HttpResponce();
            var apiController = new APIController(_logger);
            Request.Headers.TryGetValue("Authorization", out var accessToken);
            if (string.IsNullOrEmpty(accessToken.ToString()))
            {
                Request.Headers.Add("Authorization", _accessToken);
            }
            switch (HttpMethod)
            {
                case HttpAttribute.GET:
                    res = await apiController.GetApi_HttpClient<T>($"{Url}", Request.Headers);
                    break;

                case HttpAttribute.POST:
                    res.result = await apiController.PostApi_HttpClient<T>($"{Url}", JsonRequest, Request.Headers);
                    break;

                case HttpAttribute.PUT:
                    res.result = await apiController.PutApi_HttpClient<T>($"{Url}", JsonRequest, Request.Headers);
                    break;

                default:
                    res.Status = false;
                    res.HttpMessage = "Wrong HttpMethod";
                    break;
            }
            return res;
        }

        private async Task<IActionResult> ApiCall<T>(HttpAttribute HttpMethod, string Url, string JsonRequest = null)
        {
            Request.Headers.TryGetValue("Authorization", out var accessToken);
            if (string.IsNullOrEmpty(accessToken.ToString()))
            {
                Request.Headers.Add("Authorization", _accessToken);
            }

            var res = await HttpApiCall<T>(HttpMethod, Url, JsonRequest);

            if (res.Status && res.HttpStatusCode == "OK")
            {
                return Ok(res.result);
            }
            else
            {
                return BadRequest(res.result);
            }
        }

        //private async Task<HttpResponce> GetApi_HttpClient<T>(string Url)
        //{
        //    _logger.LogInformation($"WebhooksController.PostApi_HttpClient method Complete");

        //    //Request.Headers.TryGetValue("Authorization", out var accessToken);

        //    if (string.IsNullOrEmpty(accessToken) || !accessToken.ToString().Contains("apikey"))
        //    {
        //        _logger.LogInformation($"Error:Apikey not found");
        //        return new HttpResponce
        //        {
        //            Status = false,
        //            HttpMessage = "Apikey not found."
        //        };
        //    }

        //    //StringContent data = new StringContent(JsonRequest, Encoding.UTF8, "application/json");

        //    //var client = new HttpClient();
        //    //client.DefaultRequestHeaders.Add("Authorization", accessToken.ToString());
        //    //var res = await client.GetAsync(Url);
        //    //string result = await res.Content.ReadAsStringAsync();
        //    //client.Dispose();

        //    using (var httpClient = new HttpClient())
        //    {
        //        httpClient.DefaultRequestHeaders.Add("Authorization", accessToken.ToString());
        //        try
        //        {
        //            using (var response = await httpClient.GetAsync(Url))
        //            {
        //                object WebHookResponse = null;
        //                _logger.LogInformation($"Http Responce-{response}");
        //                string apiResponse = await response.Content.ReadAsStringAsync();

        //                if (response.IsSuccessStatusCode)
        //                {
        //                    _logger.LogInformation($"Success Responce-{apiResponse}");
        //                    WebHookResponse = JsonConvert.DeserializeObject<T>(apiResponse);
        //                }
        //                else
        //                {
        //                    _logger.LogInformation($"Success Responce-{apiResponse}");
        //                    WebHookResponse = JsonConvert.DeserializeObject<HttpErrorResponce>(apiResponse);
        //                }
        //                return new HttpResponce
        //                {
        //                    HttpMessage = response.ReasonPhrase,
        //                    result = WebHookResponse,
        //                    HttpStatusCode = response.StatusCode.ToString(),
        //                    Status = response.IsSuccessStatusCode
        //                };
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            _logger.LogInformation($"Error Responce-{e}");
        //            return new HttpResponce
        //            {
        //                HttpMessage = "Error.",
        //                result = e,
        //                HttpStatusCode = null,
        //                Status = false
        //            };
        //        }
        //    }
        //}

        //private async Task<HttpResponce> PostApi_HttpClient<T>(string Url, String JsonRequest)
        //{
        //    _logger.LogInformation($"WebhooksController.PostApi_HttpClient method Complete");

        //    if (String.IsNullOrEmpty(JsonRequest))
        //    {
        //        return new HttpResponce
        //        {
        //            Status = false,
        //            HttpMessage = "JsonRequest not found."
        //        };
        //    }

        //    _logger.LogInformation($"URL:{Url}, Request-{JsonRequest}");

        //    //Request.Headers.TryGetValue("Authorization", out var accessToken);

        //    if (string.IsNullOrEmpty(accessToken) || !accessToken.ToString().Contains("apikey"))
        //    {
        //        _logger.LogInformation($"Error:Apikey not found");
        //        return new HttpResponce
        //        {
        //            Status = false,
        //            HttpMessage = "Apikey not found."
        //        };
        //    }

        //    StringContent data = new StringContent(JsonRequest, Encoding.UTF8, "application/json");

        //    //var client = new HttpClient();
        //    //client.DefaultRequestHeaders.Add("Authorization", accessToken.ToString());
        //    //var res = await client.PostAsync(Url, data);
        //    //string result = await res.Content.ReadAsStringAsync();
        //    //client.Dispose();

        //    using (var httpClient = new HttpClient())
        //    {
        //        httpClient.DefaultRequestHeaders.Add("Authorization", accessToken.ToString());
        //        try
        //        {
        //            using (var response = await httpClient.PostAsync(Url, data))
        //            {
        //                object WebHookResponse = null;
        //                _logger.LogInformation($"Http Responce-{response}");
        //                string apiResponse = await response.Content.ReadAsStringAsync();

        //                if (response.IsSuccessStatusCode)
        //                {
        //                    _logger.LogInformation($"Success Responce-{apiResponse}");
        //                    WebHookResponse = JsonConvert.DeserializeObject<T>(apiResponse);
        //                }
        //                else
        //                {
        //                    _logger.LogInformation($"Fail Responce-{apiResponse}");
        //                    WebHookResponse = JsonConvert.DeserializeObject<HttpErrorResponce>(apiResponse);
        //                }

        //                return new HttpResponce
        //                {
        //                    HttpMessage = response.ReasonPhrase,
        //                    result = WebHookResponse,
        //                    HttpStatusCode = response.StatusCode.ToString(),
        //                    Status = response.IsSuccessStatusCode
        //                };
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            _logger.LogInformation($"Error Responce-{e}");
        //            return new HttpResponce
        //            {
        //                HttpMessage = "Error.",
        //                result = e,
        //                HttpStatusCode = null,
        //                Status = false
        //            };
        //        }
        //    }
        //}

        //private async Task<HttpResponce> PutApi_HttpClient<T>(string Url, String JsonRequest)
        //{
        //    _logger.LogInformation($"WebhooksController.PostApi_HttpClient method Complete");

        //    if (String.IsNullOrEmpty(JsonRequest))
        //    {
        //        return new HttpResponce
        //        {
        //            Status = false,
        //            HttpMessage = "JsonRequest not found."
        //        };
        //    }

        //    _logger.LogInformation($"URL:{Url}, Request-{JsonRequest}");

        //    //Request.Headers.TryGetValue("Authorization", out var accessToken);

        //    if (string.IsNullOrEmpty(accessToken) || !accessToken.ToString().Contains("apikey"))
        //    {
        //        _logger.LogInformation($"Error:Apikey not found");
        //        return new HttpResponce
        //        {
        //            Status = false,
        //            HttpMessage = "Apikey not found."
        //        };
        //    }

        //    StringContent data = new StringContent(JsonRequest, Encoding.UTF8, "application/json");

        //    //var client = new HttpClient();
        //    //client.DefaultRequestHeaders.Add("Authorization", accessToken.ToString());
        //    //var res = await client.PutAsync(Url, data);
        //    //string result = await res.Content.ReadAsStringAsync();
        //    //client.Dispose();

        //    using (var httpClient = new HttpClient())
        //    {
        //        httpClient.DefaultRequestHeaders.Add("Authorization", accessToken.ToString());
        //        try
        //        {
        //            using (var response = await httpClient.PutAsync(Url, data))
        //            {
        //                object WebHookResponse = null;
        //                _logger.LogInformation($"Http Responce-{response}");
        //                string apiResponse = await response.Content.ReadAsStringAsync();

        //                if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //                {
        //                    _logger.LogInformation($"Success Responce-{apiResponse}");
        //                    WebHookResponse = JsonConvert.DeserializeObject<T>(apiResponse);
        //                }
        //                else
        //                {
        //                    _logger.LogInformation($"Fail Responce-{apiResponse}");
        //                    WebHookResponse = JsonConvert.DeserializeObject<HttpErrorResponce>(apiResponse);
        //                }

        //                return new HttpResponce
        //                {
        //                    HttpMessage = response.ReasonPhrase,
        //                    result = WebHookResponse,
        //                    HttpStatusCode = response.StatusCode.ToString(),
        //                    Status = response.IsSuccessStatusCode
        //                };
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            _logger.LogInformation($"Error Responce-{e}");
        //            return new HttpResponce
        //            {
        //                HttpMessage = "Error.",
        //                result = e,
        //                HttpStatusCode = null,
        //                Status = false
        //            };
        //        }
        //    }
        //}

        #endregion API Call -
    }
}