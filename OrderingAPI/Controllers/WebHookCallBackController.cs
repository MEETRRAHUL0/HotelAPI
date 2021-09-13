using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        [Route("CreateUpdateStores")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _logger.LogInformation("HomeController.Index method called!!!");
            var t = Request.Headers;
        }
    }
}
