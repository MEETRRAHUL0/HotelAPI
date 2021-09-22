using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderingAPI.Helpers;
using OrderingAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OrderingAPI.Model.Responce;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        public string WebHookURL = "https://pos-int.urbanpiper.com";
        public string WebHookCallBackURL = "";
        public string _accessToken = "apikey biz_adm_clients_maWLBzMzwGJi:2acfa77b49743cbe61aeb613135b14e85697acbc";

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //[HttpPost]
        [HttpPut("{id}")]
        //[SwaggerOperation("GetCustomers")]
        [Route("ExternalOrderRefUpdate")]
        public async Task<IActionResult> ExternalOrderRefUpdate(int id, ExternalOrderReferenceUpdate reference)
        {
            _logger.LogInformation($"WebhooksController.Put webhooksId - [{id}] Method");
            return await ApiCall<ConfigurationResponce>(HttpAttribute.PUT, $"{WebHookURL}/external/api/v1/orders/{id}/", Helper.SerializeObject(reference));
        }

        [HttpPut("{id}/{status}")]
        [Route("OrderStatusUpdate")]
        public async Task<IActionResult> OrderStatusUpdate(int id, string status, [FromBody] OrderStatusUpdate orderStatusUpdate)
        {
            _logger.LogInformation($"WebhooksController.Put webhooksId - [{id}] Method");
            return await ApiCall<ConfigurationResponce>(HttpAttribute.PUT, $"{WebHookURL}/external/api/v1/orders/{id}/{status}", Helper.SerializeObject(orderStatusUpdate));
        }


        [HttpPost]
        [Route("MarkOrderItemsStockOut")]
        public async Task<IActionResult> MarkOrderItemsStockOut([FromBody] MarkOrderItemsStockOut markOrderItemsStockOut)
        {
            _logger.LogInformation($"WebhooksController.Put webhooksId Method");
            return await ApiCall<ConfigurationResponce>(HttpAttribute.PUT, $"{WebHookURL}/hub/api/v1/orders/items-oos/", Helper.SerializeObject(markOrderItemsStockOut));
        }

        private async Task<HttpResponce> HttpApiCall<T>(HttpAttribute HttpMethod, string Url, string JsonRequest = null)
        {
            var res = new HttpResponce();
            var apiController = new APICallController(_logger);
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
    }
}
