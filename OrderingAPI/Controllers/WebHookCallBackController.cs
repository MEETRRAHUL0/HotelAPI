using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrderingAPI.Model;
using System;

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

        /// <summary>
        /// // TODO- how we will authanticate the call, that its comming from right place ?
        // they are doing multipla call to this API withing ine min, how to manage that multipla call ?
        //https://stackoverflow.com/questions/54800512/ngrok-and-https-tunnel-for-asp-net-core-application
        //https://www.c-sharpcorner.com/article/installing-ngrok-on-windows/
        // https://dashboard.ngrok.com/get-started/setup
        //https://www.twilio.com/docs/usage/tutorials/how-use-ngrok-windows-and-visual-studio-test-webhooks
        //            Download the current version of ngrok
        //            Register and get a token: https://dashboard.ngrok.com/auth
        //            Run ngrok and set the token with the command: ngrok authtoken YOUR_AUTHTOKEN
        //            Create a tunnel: ngrok http -host - header = localhost https://localhost:44313
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("StoresAddUpdate")]
        public IActionResult StoresAddUpdate(StoresCallBack value)
        {
            var actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            var controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            //var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _logger.LogInformation($"{controllerName}Controller.{actionName} method called!!!");
            var header = JsonConvert.SerializeObject(Request.Headers);
            Request.Headers.TryGetValue("Authorization", out var accessToken);

            if (value.reference != null && value.stats != null && value.stores.Count > 0)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(wi =>
                {
                    try
                    {
                        var res = JsonConvert.SerializeObject(value);
                        _logger.LogInformation($"{actionName} Header : {header}");
                        _logger.LogInformation($"{actionName} Responce : {res}");
                        _logger.LogInformation($"{actionName} Authorization : {accessToken}");
                    }
                    catch (Exception Ex)
                    {
                        _logger.LogInformation($"{actionName} Error : {Ex}");
                    }
                });
            }

            return Ok("Success");
        }
        [HttpPost]
        [Route("StoreActions")]
        public IActionResult StoreActions(StoreActionsCallBack value)
        {
            var actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            var controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            //var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _logger.LogInformation($"{controllerName}Controller.{actionName} method called!!!");
            var header = JsonConvert.SerializeObject(Request.Headers);
            Request.Headers.TryGetValue("Authorization", out var accessToken);

            if (value.action != null)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(wi =>
                {
                    try
                    {
                        var res = JsonConvert.SerializeObject(value);
                        _logger.LogInformation($"{actionName} Header : {header}");
                        _logger.LogInformation($"{actionName} Responce : {res}");
                        _logger.LogInformation($"{actionName} Authorization : {accessToken}");
                    }
                    catch (Exception Ex)
                    {
                        _logger.LogInformation($"{actionName} Error : {Ex}");
                    }
                });
            }

            return Ok("Success");
        }
        [HttpPost]
        [Route("CatalogueIngestion")]
        public IActionResult CatalogueIngestion(CatalogueIngestionCallBack value)
        {
            var actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            var controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            //var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _logger.LogInformation($"{controllerName}Controller.{actionName} method called!!!");
            var header = JsonConvert.SerializeObject(Request.Headers);
            Request.Headers.TryGetValue("Authorization", out var accessToken);

            if (value.reference != null && value.stats != null)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(wi =>
                {
                    try
                    {
                        var res = JsonConvert.SerializeObject(value);
                        _logger.LogInformation($"{actionName} Header : {header}");
                        _logger.LogInformation($"{actionName} Responce : {res}");
                        _logger.LogInformation($"{actionName} Authorization : {accessToken}");
                    }
                    catch (Exception Ex)
                    {
                        _logger.LogInformation($"{actionName} Error : {Ex}");
                    }
                });
            }

            return Ok("Success");
        }
        [HttpPost]
        [Route("CategoryTimingGroup")]
        public IActionResult CategoryTimingGroup(CategoryTimingGroupCallBack value)
        {
            var actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            var controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            //var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _logger.LogInformation($"{controllerName}Controller.{actionName} method called!!!");
            var header = JsonConvert.SerializeObject(Request.Headers);
            Request.Headers.TryGetValue("Authorization", out var accessToken);

            if (value.reference_id != null)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(wi =>
                {
                    try
                    {
                        var res = JsonConvert.SerializeObject(value);
                        _logger.LogInformation($"{actionName} Header : {header}");
                        _logger.LogInformation($"{actionName} Responce : {res}");
                        _logger.LogInformation($"{actionName} Authorization : {accessToken}");
                    }
                    catch (Exception Ex)
                    {
                        _logger.LogInformation($"{actionName} Error : {Ex}");
                    }
                });
            }

            return Ok("Success");
        }

        [HttpPost]
        [Route("ItemActions")]
        public IActionResult ItemActions(ItemActionsCallBack value)
        {
            var actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            var controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            //var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _logger.LogInformation($"{controllerName}Controller.{actionName} method called!!!");
            var header = JsonConvert.SerializeObject(Request.Headers);
            Request.Headers.TryGetValue("Authorization", out var accessToken);

            if (value.reference_id != null)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(wi =>
                {
                    try
                    {
                        var res = JsonConvert.SerializeObject(value);
                        _logger.LogInformation($"{actionName} Header : {header}");
                        _logger.LogInformation($"{actionName} Responce : {res}");
                        _logger.LogInformation($"{actionName} Authorization : {accessToken}");
                    }
                    catch (Exception Ex)
                    {
                        _logger.LogInformation($"{actionName} Error : {Ex}");
                    }
                });
            }

            return Ok("Success");
        }

        [HttpPost]
        [Route("OptionActions ")]
        public IActionResult OptionActions(OptionActionsCallBack value)
        {
            var actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            var controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            //var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _logger.LogInformation($"{controllerName}Controller.{actionName} method called!!!");
            var header = JsonConvert.SerializeObject(Request.Headers);
            Request.Headers.TryGetValue("Authorization", out var accessToken);

            if (value.reference_id != null)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(wi =>
                {
                    try
                    {
                        var res = JsonConvert.SerializeObject(value);
                        _logger.LogInformation($"{actionName} Header : {header}");
                        _logger.LogInformation($"{actionName} Responce : {res}");
                        _logger.LogInformation($"{actionName} Authorization : {accessToken}");
                    }
                    catch (Exception Ex)
                    {
                        _logger.LogInformation($"{actionName} Error : {Ex}");
                    }
                });
            }

            return Ok("Success");
        }

        [HttpPost]
        [Route("OrderRelay")]
        public IActionResult OrderRelay(OrderRelayCallBack value)
        {
            var actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            var controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            //var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _logger.LogInformation($"{controllerName}Controller.{actionName} method called!!!");
            var header = JsonConvert.SerializeObject(Request.Headers);
            Request.Headers.TryGetValue("Authorization", out var accessToken);

            if (value.customer != null)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(wi =>
                {
                    try
                    {
                        var res = JsonConvert.SerializeObject(value);
                        _logger.LogInformation($"{actionName} Header : {header}");
                        _logger.LogInformation($"{actionName} Responce : {res}");
                        _logger.LogInformation($"{actionName} Authorization : {accessToken}");
                    }
                    catch (Exception Ex)
                    {
                        _logger.LogInformation($"{actionName} Error : {Ex}");
                    }
                });
            }

            return Ok("Success");
        }

        [HttpPost]
        [Route("OrderStatusChange")]
        public IActionResult OrderStatusChange(OrderStatusChangeCallBack value)
        {
            var actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            var controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            //var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _logger.LogInformation($"{controllerName}Controller.{actionName} method called!!!");
            var header = JsonConvert.SerializeObject(Request.Headers);
            Request.Headers.TryGetValue("Authorization", out var accessToken);

            if (value.order_id != null)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(wi =>
                {
                    try
                    {
                        var res = JsonConvert.SerializeObject(value);
                        _logger.LogInformation($"{actionName} Header : {header}");
                        _logger.LogInformation($"{actionName} Responce : {res}");
                        _logger.LogInformation($"{actionName} Authorization : {accessToken}");
                    }
                    catch (Exception Ex)
                    {
                        _logger.LogInformation($"{actionName} Error : {Ex}");
                    }
                });
            }

            return Ok("Success");
        }

        [HttpPost]
        [Route("RiderStatusChange")]
        public IActionResult RiderStatusChange(RiderStatusChangeCallBack value)
        {
            var actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            var controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            //var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _logger.LogInformation($"{controllerName}Controller.{actionName} method called!!!");
            var header = JsonConvert.SerializeObject(Request.Headers);
            Request.Headers.TryGetValue("Authorization", out var accessToken);

            if (value.order_id != null)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(wi =>
                {
                    try
                    {
                        var res = JsonConvert.SerializeObject(value);
                        _logger.LogInformation($"{actionName} Header : {header}");
                        _logger.LogInformation($"{actionName} Responce : {res}");
                        _logger.LogInformation($"{actionName} Authorization : {accessToken}");
                    }
                    catch (Exception Ex)
                    {
                        _logger.LogInformation($"{actionName} Error : {Ex}");
                    }
                });
            }

            return Ok("Success");
        }



    }
}