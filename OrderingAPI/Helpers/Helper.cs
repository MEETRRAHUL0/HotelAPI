﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
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

        public static DateTime UnixTimeStampToDateTime(string unixTimeStamp)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            double d = double.Parse("1332958778172");  // Or avoid parsing if possible :)
            Console.Write(dt.AddMilliseconds(d));
            return dt;
            // Unix timestamp is seconds past epoch
            //DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            //dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            //return dateTime;
        }
        public static string epoch2string(double epoch)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epoch).ToShortDateString();
        }
    }
}