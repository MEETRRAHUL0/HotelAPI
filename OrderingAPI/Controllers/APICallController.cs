using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static OrderingAPI.Model.Responce;

namespace OrderingAPI.Controllers
{
    public class APICallController
    {
        private  ILogger _logger;

        public  APICallController(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<HttpResponce> GetApi_HttpClient<T>(string Url, IHeaderDictionary headers)
        {
            _logger.LogInformation($"WebhooksController.PostApi_HttpClient method Complete");

            headers.TryGetValue("Authorization", out var accessToken);

            if (string.IsNullOrEmpty(accessToken) || !accessToken.ToString().Contains("apikey"))
            {
                _logger.LogInformation($"Error:Apikey not found");
                return new HttpResponce
                {
                    Status = false,
                    HttpMessage = "Apikey not found."
                };
            }

            //StringContent data = new StringContent(JsonRequest, Encoding.UTF8, "application/json");

            //var client = new HttpClient();
            //client.DefaultRequestHeaders.Add("Authorization", accessToken.ToString());
            //var res = await client.GetAsync(Url);
            //string result = await res.Content.ReadAsStringAsync();
            //client.Dispose();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", accessToken.ToString());
                try
                {
                    using (var response = await httpClient.GetAsync(Url))
                    {
                        object WebHookResponse = null;
                        _logger.LogInformation($"Http Responce-{response}");
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        if (response.IsSuccessStatusCode)
                        {
                            _logger.LogInformation($"Success Responce-{apiResponse}");
                            WebHookResponse = JsonConvert.DeserializeObject<T>(apiResponse);
                        }
                        else
                        {
                            _logger.LogInformation($"Success Responce-{apiResponse}");
                            WebHookResponse = JsonConvert.DeserializeObject<HttpErrorResponce>(apiResponse);
                        }
                        return new HttpResponce
                        {
                            HttpMessage = response.ReasonPhrase,
                            result = WebHookResponse,
                            HttpStatusCode = response.StatusCode.ToString(),
                            Status = response.IsSuccessStatusCode
                        };
                    }
                }
                catch (Exception e)
                {
                    _logger.LogInformation($"Error Responce-{e}");
                    return new HttpResponce
                    {
                        HttpMessage = "Error.",
                        result = e,
                        HttpStatusCode = null,
                        Status = false
                    };
                }
            }
        }

        public  async Task<HttpResponce> PostApi_HttpClient<T>(string Url, String JsonRequest, IHeaderDictionary headers)
        {
            _logger.LogInformation($"WebhooksController.PostApi_HttpClient method Complete");

            if (String.IsNullOrEmpty(JsonRequest))
            {
                return new HttpResponce
                {
                    Status = false,
                    HttpMessage = "JsonRequest not found."
                };
            }

            _logger.LogInformation($"URL:{Url}, Request-{JsonRequest}");

            headers.TryGetValue("Authorization", out var accessToken);

            if (string.IsNullOrEmpty(accessToken) || !accessToken.ToString().Contains("apikey"))
            {
                _logger.LogInformation($"Error:Apikey not found");
                return new HttpResponce
                {
                    Status = false,
                    HttpMessage = "Apikey not found."
                };
            }

            StringContent data = new StringContent(JsonRequest, Encoding.UTF8, "application/json");

            //var client = new HttpClient();
            //client.DefaultRequestHeaders.Add("Authorization", accessToken.ToString());
            //var res = await client.PostAsync(Url, data);
            //string result = await res.Content.ReadAsStringAsync();
            //client.Dispose();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", accessToken.ToString());
                try
                {
                    using (var response = await httpClient.PostAsync(Url, data))
                    {
                        object WebHookResponse = null;
                        _logger.LogInformation($"Http Responce-{response}");
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        if (response.IsSuccessStatusCode)
                        {
                            _logger.LogInformation($"Success Responce-{apiResponse}");
                            WebHookResponse = JsonConvert.DeserializeObject<T>(apiResponse);
                        }
                        else
                        {
                            _logger.LogInformation($"Fail Responce-{apiResponse}");
                            WebHookResponse = JsonConvert.DeserializeObject<HttpErrorResponce>(apiResponse);
                        }

                        return new HttpResponce
                        {
                            HttpMessage = response.ReasonPhrase,
                            result = WebHookResponse,
                            HttpStatusCode = response.StatusCode.ToString(),
                            Status = response.IsSuccessStatusCode
                        };
                    }
                }
                catch (Exception e)
                {
                    _logger.LogInformation($"Error Responce-{e}");
                    return new HttpResponce
                    {
                        HttpMessage = "Error.",
                        result = e,
                        HttpStatusCode = null,
                        Status = false
                    };
                }
            }
        }

        public  async Task<HttpResponce> PutApi_HttpClient<T>(string Url, String JsonRequest, IHeaderDictionary headers)
        {
            _logger.LogInformation($"WebhooksController.PostApi_HttpClient method Complete");

            if (String.IsNullOrEmpty(JsonRequest))
            {
                return new HttpResponce
                {
                    Status = false,
                    HttpMessage = "JsonRequest not found."
                };
            }

            _logger.LogInformation($"URL:{Url}, Request-{JsonRequest}");

            headers.TryGetValue("Authorization", out var accessToken);

            if (string.IsNullOrEmpty(accessToken) || !accessToken.ToString().Contains("apikey"))
            {
                _logger.LogInformation($"Error:Apikey not found");
                return new HttpResponce
                {
                    Status = false,
                    HttpMessage = "Apikey not found."
                };
            }

            StringContent data = new StringContent(JsonRequest, Encoding.UTF8, "application/json");

            //var client = new HttpClient();
            //client.DefaultRequestHeaders.Add("Authorization", accessToken.ToString());
            //var res = await client.PutAsync(Url, data);
            //string result = await res.Content.ReadAsStringAsync();
            //client.Dispose();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", accessToken.ToString());
                try
                {
                    using (var response = await httpClient.PutAsync(Url, data))
                    {
                        object WebHookResponse = null;
                        _logger.LogInformation($"Http Responce-{response}");
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            _logger.LogInformation($"Success Responce-{apiResponse}");
                            WebHookResponse = JsonConvert.DeserializeObject<T>(apiResponse);
                        }
                        else
                        {
                            _logger.LogInformation($"Fail Responce-{apiResponse}");
                            WebHookResponse = JsonConvert.DeserializeObject<HttpErrorResponce>(apiResponse);
                        }

                        return new HttpResponce
                        {
                            HttpMessage = response.ReasonPhrase,
                            result = WebHookResponse,
                            HttpStatusCode = response.StatusCode.ToString(),
                            Status = response.IsSuccessStatusCode
                        };
                    }
                }
                catch (Exception e)
                {
                    _logger.LogInformation($"Error Responce-{e}");
                    return new HttpResponce
                    {
                        HttpMessage = "Error.",
                        result = e,
                        HttpStatusCode = null,
                        Status = false
                    };
                }
            }
        }
        //private string PostApi_WebRequest(string Url, String JsonRequest)
        //{
        //    Request.Headers.TryGetValue("Authorization", out var accessToken);

        //    if (string.IsNullOrEmpty(accessToken) || !accessToken.Contains("apikey"))
        //    {
        //        return "apikey not found.";
        //    }

        //    byte[] postBytes = new ASCIIEncoding().GetBytes(JsonRequest);
        //    System.Net.WebRequest request = System.Net.HttpWebRequest.Create(Url);
        //    request.Method = "POST";
        //    request.ContentType = "application/json";
        //    request.Headers.Add("Authorization", accessToken);
        //    Stream postStream = request.GetRequestStream();
        //    postStream.Write(postBytes, 0, postBytes.Length);
        //    postStream.Flush();
        //    postStream.Close();

        //    using (System.Net.WebResponse response = request.GetResponse())
        //    {
        //        using (System.IO.StreamReader streamReader = new System.IO.StreamReader(response.GetResponseStream()))
        //        {
        //            dynamic jsonResponseText = streamReader.ReadToEnd();
        //            return jsonResponseText;
        //        }
        //    }
        //}
        //private async Task<T> PostApi_HttpClient<T>(string Url, String JsonRequest, IHeaderDictionary headers)
        //{
        //    _logger.LogInformation($"HomeController.PostApi_HttpClient method Complete");
        //    _logger.LogInformation($"URL:{Url}, Request-{JsonRequest}");

        //    headers.TryGetValue("Authorization", out var accessToken);

        //    if (string.IsNullOrEmpty(accessToken) || !accessToken.ToString().Contains("apikey"))
        //    {
        //        _logger.LogInformation($"Error:Apikey not found");
        //        return BadRequest("Apikey not found.");
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
        //                if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //                {
        //                    string apiResponse = await response.Content.ReadAsStringAsync();
        //                    _logger.LogInformation($"Success Responce-{response}");
        //                    return Ok(apiResponse);
        //                }
        //                else
        //                {
        //                    _logger.LogInformation($"Fail Responce-{response}");
        //                    return BadRequest(response);
        //                }
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            _logger.LogInformation($"Error Responce-{e}");
        //            return BadRequest(e);
        //        }
        //    }
        //}
    }
}