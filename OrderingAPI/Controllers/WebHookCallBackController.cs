using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrderingAPI.Model;
using OrderingAPI.SQL;
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
        //            Create a tunnel: ngrok http -host-header=localhost https://localhost:44321
        //ngrok http -host-header=localhost https://api.uvtechsolutions.in/
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("StoresAddUpdate")]
        //[Route("StoresAddUpdate")]
        public IActionResult StoresAddUpdate(StoresCallBack value)
        {
            _logger.LogInformation($"StoresAddUpdate called");

            try
            {
                var actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                var controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                //var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

                _logger.LogInformation($"{controllerName}Controller.{actionName} method called!!!");
                var header = JsonConvert.SerializeObject(Request.Headers);
                Request.Headers.TryGetValue("Authorization", out var accessToken);

                if (value != null && value.stores.Count > 0 )
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
                else
                {
                    _logger.LogInformation($"method OrderRelay Responce is Empty");
                }
            }
            catch (Exception Ex)
            {
                _logger.LogInformation($" Error on method OrderRelay : {Ex}");
                return Ok("Success");
            }
            finally
            {
                _logger.LogInformation($" finally call on OrderRelay");
            }
            _logger.LogInformation($"StoresAddUpdate completed");
            return Ok("Success");
        }
        [HttpPost]
        //[Route("StoreActions")]
        [Route("StoresStatusChange")]
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
        //[Route("CatalogueIngestion")]
        [Route("CataloguepublishthroughAPI")]
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
        //[Route("CategoryTimingGroup")]
        [Route("CategoryTimingGroupsCreateUpdate")]
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
        //[Route("ItemActions")]
        [Route("ItemStockInOut")]
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
        //[Route("OptionActions ")]
        [Route("OptionStockInOut")]
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
        //[Route("OrderPlaced")]
        [Route("OrderRelay")]
        public IActionResult OrderRelay(OrderRelayCallBack value)
        {
            _logger.LogInformation($"OrderRelay called");
            try
            {
                var actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                var controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                //var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

                _logger.LogInformation($"{controllerName}Controller.{actionName} method called!!!");
                var header = JsonConvert.SerializeObject(Request.Headers);
                Request.Headers.TryGetValue("Authorization", out var accessToken);

                if (value != null)
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(wi =>
                    {
                        try
                        {
                            var res = JsonConvert.SerializeObject(value);
                            _logger.LogInformation($"{actionName} Header : {header}");
                            _logger.LogInformation($"{actionName} Responce : {res}");
                            _logger.LogInformation($"{actionName} Authorization : {accessToken}");

                            DBConnect dbConnect = new DBConnect(_logger);
                            dbConnect.AddOrder(value);
                        }
                        catch (Exception Ex)
                        {
                            _logger.LogInformation($"{actionName} Error : {Ex}");
                        }
                    });
                }
                else
                {
                    _logger.LogInformation($"method OrderRelay Responce is Empty");
                }
            }
            catch (Exception Ex)
            {
                _logger.LogInformation($" Error on method OrderRelay : {Ex}");
                return Ok("Success");
            }
            finally
            {
                _logger.LogInformation($" finally call on OrderRelay");
            }
            _logger.LogInformation($"OrderRelay called");
            return Ok("Success");
        }

        [HttpPost]
        //[Route("OrderStatusChange")]
        [Route("OrderStatusUpdate")]
        [Route("OrderDeliveryStatus")]
        public IActionResult OrderStatusChange(OrderStatusChangeCallBack value)
        {
            var actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            var controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            //var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _logger.LogInformation($"{controllerName}Controller.{actionName} method called!!!");
            var header = JsonConvert.SerializeObject(Request.Headers);
            Request.Headers.TryGetValue("Authorization", out var accessToken);

            if (value.order_id >0)
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

        [HttpPost]
        [Route("UserFeedback")]
        public IActionResult UserFeedback(dynamic value)
        {
            var actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            var controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            //var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _logger.LogInformation($"{controllerName}Controller.{actionName} method called!!!");
            var header = JsonConvert.SerializeObject(Request.Headers);
            Request.Headers.TryGetValue("Authorization", out var accessToken);

            //if (value.order_id > 0)
            //{
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
            //}

            return Ok("Success");
        }

    }
}



//< div class= "selectize-dropdown-content" >
// < div data - value = "10005" data - selectable = "" class= "option" > User Feedback </ div >  -- done
//< div data - value = "18" data - selectable = "" class= "option" > Order placed </ div >    -- done
//< div data - value = "60008" data - selectable = "" class= "option" > Order status update</div>   -- done
//<div data-value= "60012" data-selectable= "" class= "option" > Order delivery status</div>  -- done
//<div data-value= "60013" data-selectable= "" class= "option" > Catalogue publish through API</div>  -- done
//<div data-value="60014" data-selectable="" class= "option selected" > Stores create / update </ div >  --- done
//< div data - value = "60015" data - selectable = "" class= "option" > Stores status change</div>  -- done
//<div data-value= "60016" data-selectable= "" class= "option" > Category timing groups create/update</div>  -- done
//<div data-value="12004" data-selectable="" class= "option" > Item Stock In/Out</div>  -- done
//<div data-value="12005" data-selectable="" class= "option" > Option Stock In/Out</div>  -- done
//		<div data-value="60017" data-selectable="" class= "option" > Order Feature Action</div>
//<div data-value= "80001" data-selectable= "" class= "option" > Comet: Order Placed</div>
//<div data-value= "12002" data-selectable= "" class= "option" > Hub Menu Publish</div>
//<div data-value= "60018" data-selectable= "" class= "option" > Order Items OOS Processed</div>
//</div> -->
//User feedback	10005
//Order placed	18
//Order status update	60008
//Order delivery status update	60012
//Catalogue Create/Update through API	60013
//Store Create/Update through API	60014
//Store Actions through API	60015
//Items Actions through API	12004
//Options Actions through API	12005
//Category Timing Groups through API	60016
//Hub Menu Publish	12002
//Mark Order Items Stock-out	60018

//order_placed:			order placed event.
//order_status_update:	order state change event.
//rider_status_update:	rider state change event.
//inventory_update:		callback url for managing catalogue call.
//store_creation:			callback url for store creation call.
//store_action:			event for callback url for Store Actions API call.
//item_state_toggle:		event for callback url for items actions done through Item/Option - actions API call.
//catalogue_timing_grp:	event for callback url for Category Timing Groups API.
//option_state_toggle:	event for callback url for option actions done through Item/Option - actions API call.
//hub_menu_publish:		event for callback url for menu publish to aggregators.
//order_items_oos_processed:	event for callback url for mark order item out-of-stock.