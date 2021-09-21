using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace OrderingAPI.Helpers
{
    public class Helper
    {
        public static List<KeyValuePair<WebHookEvent, WebHookCallBackMethods>> WebHookCallBackMethod =
             new List<KeyValuePair<WebHookEvent, WebHookCallBackMethods>>() {
        new KeyValuePair<WebHookEvent, WebHookCallBackMethods>(WebHookEvent.all,WebHookCallBackMethods.all),
        new KeyValuePair<WebHookEvent, WebHookCallBackMethods>(WebHookEvent.order_placed,WebHookCallBackMethods.OrderStatusChange),
        new KeyValuePair<WebHookEvent, WebHookCallBackMethods>(WebHookEvent.order_status_update,WebHookCallBackMethods.OrderStatusChange),
        new KeyValuePair<WebHookEvent, WebHookCallBackMethods>(WebHookEvent.rider_status_update,WebHookCallBackMethods.RiderStatusChange),
        new KeyValuePair<WebHookEvent, WebHookCallBackMethods>(WebHookEvent.inventory_update,WebHookCallBackMethods.OrderStatusChange),
        new KeyValuePair<WebHookEvent, WebHookCallBackMethods>(WebHookEvent.store_creation,WebHookCallBackMethods.StoresAddUpdate),
        new KeyValuePair<WebHookEvent, WebHookCallBackMethods>(WebHookEvent.store_action,WebHookCallBackMethods.StoreActions),
        new KeyValuePair<WebHookEvent, WebHookCallBackMethods>(WebHookEvent.item_state_toggle,WebHookCallBackMethods.ItemActions),
        new KeyValuePair<WebHookEvent, WebHookCallBackMethods>(WebHookEvent.catalogue_timing_grp,WebHookCallBackMethods.CategoryTimingGroup),
        new KeyValuePair<WebHookEvent, WebHookCallBackMethods>(WebHookEvent.option_state_toggle,WebHookCallBackMethods.OptionActions),
        new KeyValuePair<WebHookEvent, WebHookCallBackMethods>(WebHookEvent.hub_menu_publish,WebHookCallBackMethods.StoresAddUpdate),
        new KeyValuePair<WebHookEvent, WebHookCallBackMethods>(WebHookEvent.order_items_oos_processed,WebHookCallBackMethods.StoresAddUpdate),
         };

        public static string SerializeObject<T>(T Value)
        {
            string jsonRequest = JsonConvert.SerializeObject(Value, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            });

            return jsonRequest;
        }
    }
}