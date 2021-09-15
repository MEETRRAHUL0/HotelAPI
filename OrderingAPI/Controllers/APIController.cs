using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrderingAPI.Controllers
{
    public class APIController
    {
        private readonly ILogger<APIController> _logger;

        public APIController(ILogger<APIController> logger)
        {
            _logger = logger;
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
        //private async Task<IActionResult> PostApi_HttpClient(string Url, String JsonRequest)
        //{
        //    _logger.LogInformation($"HomeController.PostApi_HttpClient method Complete");
        //    _logger.LogInformation($"URL:{Url}, Request-{JsonRequest}");

        //    Request.Headers.TryGetValue("Authorization", out var accessToken);

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
