using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrderingAPI.Model;
using OrderingAPI.Helpers;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static OrderingAPI.Model.Responce;

namespace OrderingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly ILogger<ConfigurationController> _logger;

        public ConfigurationController(ILogger<ConfigurationController> logger)
        {
            _logger = logger;
        }

        public string jsonSring_ = @"{  ""stores"": [    {      ""city"": ""Bangalore"",      ""name"": ""Koramanagala"",      ""ref_id"": ""5916020-QETWW6521""    }  ]}";
        public string jdata_ = @"{	  ""stores"": [    {      ""city"": ""Bangalore"",      ""name"": ""Koramanagala"",      ""min_pickup_time"": 900,      ""min_delivery_time"": 1800,      ""contact_phone"": ""9999999999"",      ""notification_phones"": [        ""+919999999999"",        ""8888888888""      ],      ""ref_id"": ""5916020-QETWW6521"",      ""min_order_value"": 200,      ""hide_from_ui"": false,      ""address"": ""2nd Cross 5th Main"",      ""notification_emails"": [        ""b1@mail.com"",        ""b2@mail.com""      ],      ""zip_codes"": [        ""560033"",        ""560022""      ],      ""geo_longitude"": 22.234324,      ""active"": true,      ""geo_latitude"": 19.12312,      ""ordering_enabled"": true,      ""translations"": [        {          ""language"": ""fr"",          ""name"": ""Koramanagala""        }      ],      ""excluded_platforms"": [        ""swiggy"",        ""scootsy""      ],      ""platform_data"": [        {          ""name"": ""zomato"",          ""url"": ""https://www.zomato.com/bangalore/cakes-sweets/order"",          ""platform_store_id"": ""535678588""        }      ],      ""timings"": [        {          ""day"": ""monday"",          ""slots"": [            {              ""start_time"": ""10:00:00"",              ""end_time"": ""22:30:00""            }          ]        },        {          ""day"": ""tuesday"",          ""slots"": [            {              ""start_time"": ""10:00:00"",              ""end_time"": ""22:30:00""            }          ]        }      ]    },    {      ""city"": ""delhi"",      ""name"": ""Connaught Place"",      ""min_pickup_time"": 900,      ""min_delivery_time"": 1800,      ""contact_phone"": ""+919999999999"",      ""notification_phones"": [        ""9999999999"",        ""+918888888888""      ],      ""ref_id"": ""6906-45r7-f7u3-3645"",      ""min_order_value"": 200,      ""hide_from_ui"": false,      ""address"": ""Sector 21, D - block"",      ""notification_emails"": [        ""d1@mail.com"",        ""d2@mail.com""      ],      ""zip_codes"": [        ""110021"",        ""2312323""      ],      ""geo_longitude"": 22.234324,      ""active"": false,      ""geo_latitude"": 19.12312,      ""ordering_enabled"": true,      ""translations"": [        {          ""language"": ""fr"",          ""name"": ""Connaught Place""        }      ],      ""included_platforms"": [        ""swiggy""      ],      ""platform_data"": [        {          ""name"": ""swiggy"",          ""url"": ""https://www.swiggy.com/restaurants/cakes-sweets-connaught-place-5567"",          ""platform_store_id"": ""5567""        }      ]    }  ]}";
        public string URL = "https://pos-int.urbanpiper.com";
        public string accessToken_ = "apikey biz_adm_clients_maWLBzMzwGJi:2acfa77b49743cbe61aeb613135b14e85697acbc";

        //[Route("GetReservation2")]
        //[HttpPost]
        //public StoreResponce GetReservation2(StoreRequest storeRequest)
        //{
        //    System.Net.WebRequest request = System.Net.HttpWebRequest.Create(url);
        //    request.Method = "POST";
        //    request.ContentType = "application/json";
        //    request.Headers.Add("Authorization", accessToken);
        //    StoreResponce reservation = new StoreResponce();

        //    string json = JsonConvert.SerializeObject(storeRequest, new JsonSerializerSettings()
        //    {
        //        NullValueHandling = NullValueHandling.Ignore,
        //        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        //        Formatting = Formatting.Indented
        //    });

        //    byte[] postBytes = new ASCIIEncoding().GetBytes(json);

        //    Stream postStream = request.GetRequestStream();
        //    postStream.Write(postBytes, 0, postBytes.Length);
        //    postStream.Flush();
        //    postStream.Close();

        //    using (System.Net.WebResponse response = request.GetResponse())
        //        {
        //            using (System.IO.StreamReader streamReader = new System.IO.StreamReader(response.GetResponseStream()))
        //            {
        //                dynamic jsonResponseText = streamReader.ReadToEnd();
        //            reservation = JsonConvert.DeserializeObject<StoreResponce>(jsonResponseText);
        //            }
        //        }
        //    return reservation;
        //}

        [HttpPost]
        [Route("Stores")]
        public async Task<IActionResult> Stores(StoreRequest storeRequest)
        {
            var t = WebHookEvent.catalogue_timing_grp;
            _logger.LogInformation($"HomeController.Stores Method");
            return await PostApi_HttpClient($"{URL}/external/api/v1/stores/", Helper.SerializeObject(storeRequest));
        }

        [HttpPost]
        [Route("Catalogue")]
        public async Task<IActionResult> Catalogue(string location_ref_id, CatalogueRequest catalogueRequest)
        {
            _logger.LogInformation($"HomeController.Catalogue Method");
            return await PostApi_HttpClient($"{URL}/external/api/v1/inventory/locations/{location_ref_id}/", Helper.SerializeObject(catalogueRequest));
        }

        [HttpPost]
        [Route("CategoryTimingGroups")]
        public async Task<IActionResult> CategoryTimingGroups(CategoryTimingGroupsRequest categoryTimingGroupsRequest)
        {
            _logger.LogInformation($"HomeController.CategoryTimingGroups Method");
            return await PostApi_HttpClient($"{URL}/external/api/v1/inventory/categories/timing-groups/", Helper.SerializeObject(categoryTimingGroupsRequest));
        }

        [HttpPost]
        [Route("StoresActions")]
        public async Task<IActionResult> StoresActions(StoresActionsRequest storesActionsRequest)
        {
            _logger.LogInformation($"HomeController.Stores StoresActions");
            return await PostApi_HttpClient($"{URL}/hub/api/v1/location/", Helper.SerializeObject(storesActionsRequest));
        }

        [HttpPost]
        [Route("Item")]
        public async Task<IActionResult> Item(ItemRequest itemRequest)
        {
            _logger.LogInformation($"HomeController.Item Method");
            return await PostApi_HttpClient($"{URL}/hub/api/v1/items/", Helper.SerializeObject(itemRequest));
        }

        //[ApiExplorerSettings(IgnoreApi = true)]
        //[HttpPost]
        //[Route("checkCall")]
        //public async Task<IActionResult> checkCall(string url,  OrderRelayCallBack value)
        //{
        //    var t = WebHookEvent.catalogue_timing_grp;
        //    _logger.LogInformation($"HomeController.Stores Method");
        //    //var url = "";
        //    //var req = "";
        //    return await PostApi_HttpClient(url, Helper.SerializeObject(value));
        //}

        #region API Call -

        // TODO - Move this to commoun file
        private string PostApi_WebRequest(string Url, String JsonRequest)
        {
            Request.Headers.TryGetValue("Authorization", out var accessToken);

            if (string.IsNullOrEmpty(accessToken) || !accessToken.Contains("apikey"))
            {
                return "apikey not found.";
            }

            byte[] postBytes = new ASCIIEncoding().GetBytes(JsonRequest);
            System.Net.WebRequest request = System.Net.HttpWebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", accessToken);
            Stream postStream = request.GetRequestStream();
            postStream.Write(postBytes, 0, postBytes.Length);
            postStream.Flush();
            postStream.Close();

            using (System.Net.WebResponse response = request.GetResponse())
            {
                using (System.IO.StreamReader streamReader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    dynamic jsonResponseText = streamReader.ReadToEnd();
                    var res = JsonConvert.DeserializeObject<ConfigurationResponce>(jsonResponseText);
                    return jsonResponseText;
                }
            }
        }

        private async Task<IActionResult> PostApi_HttpClient(string Url, String JsonRequest)
        {
            _logger.LogInformation($"HomeController.PostApi_HttpClient method Complete");
            _logger.LogInformation($"URL:{Url}, Request-{JsonRequest}");

            Request.Headers.TryGetValue("Authorization", out var accessToken);

            if (string.IsNullOrEmpty(accessToken) || !accessToken.ToString().Contains("apikey"))
            {
                Request.Headers.Add("Authorization", accessToken_);
                _logger.LogInformation($"Error:Apikey not found");
                //return BadRequest("Apikey not found.");
            }

            StringContent data = new StringContent(JsonRequest, Encoding.UTF8, "application/json");

            //var client = new HttpClient();
            //client.DefaultRequestHeaders.Add("Authorization", accessToken.ToString());
            //var res = await client.PostAsync(Url, data);
            //string result = await res.Content.ReadAsStringAsync();
            //client.Dispose();

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
           // HttpClient client = new HttpClient(clientHandler);

            using (var httpClient = new HttpClient(clientHandler))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", accessToken_.ToString());
                try
                {
                    var response2 = await httpClient.PostAsync(Url, data);
                    using (var response = await httpClient.PostAsync(Url, data))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            var ConfigurationResponce = JsonConvert.DeserializeObject<ConfigurationResponce>(apiResponse);
                            _logger.LogInformation($"Success Responce-{response}");
                            return Ok(apiResponse);
                        }
                        else
                        {
                            _logger.LogInformation($"Fail Responce-{response}");
                            return BadRequest(response);
                        }
                    }
                }
                catch (Exception e)
                {
                    _logger.LogInformation($"Error Responce-{e}");
                    return BadRequest(e);
                }
            }
        }

        #endregion API Call -

    }
}