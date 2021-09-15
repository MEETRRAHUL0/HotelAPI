using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrderingAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebHookCallBackController : ControllerBase
    {
        private readonly ILogger<WebHookCallBackController> _logger;

        public WebHookCallBackController(ILogger<WebHookCallBackController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("CreateUpdateStores")]
        public IActionResult CreateUpdateStores(StoreCallBack value)
        {
            // TODO- how we will authanticate the call, that its comming from right place ?
            // they are doing multipla call to this API withing ine min, how to manage that multipla call ?

            _logger.LogInformation("WebHookCallBackController.CreateUpdateStores method called!!!");
            var header = JsonConvert.SerializeObject(Request.Headers);
            var res = JsonConvert.SerializeObject(value);
            Request.Headers.TryGetValue("Authorization", out var accessToken);

            _logger.LogInformation($"CreateUpdateStores Header : {header}");
            _logger.LogInformation($"CreateUpdateStores Responce : {res}");
            _logger.LogInformation($"CreateUpdateStores Authorization : {accessToken}");

            return Ok("Success");
        }
    }
}
