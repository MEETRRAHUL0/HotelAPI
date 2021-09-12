using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhooksController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            // /external/api/v1/webhooks/
            return new string[] { "value1", "value2" };
        }

        // GET api/<WebhooksController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            ///external/api/v1/webhooks/{webhook_id}/
            return "value";
        }

        // POST api/<WebhooksController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            ///external/api/v1/webhooks/
        }

        // PUT api/<WebhooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            ///external/api/v1/webhooks/{webhook_id}/
        }

        // DELETE api/<WebhooksController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
