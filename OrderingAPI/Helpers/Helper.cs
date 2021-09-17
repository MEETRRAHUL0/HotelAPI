using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace OrderingAPI.Helpers
{
    public class Helper
    {
       public static List<KeyValuePair<WebHookEvent, WebHookCallBackMethods>> WebHookCallBackMethod =
            new List<KeyValuePair<WebHookEvent, WebHookCallBackMethods>>() {
        new KeyValuePair<WebHookEvent, WebHookCallBackMethods>(WebHookEvent.store_creation,WebHookCallBackMethods.StoresAddUpdate),
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