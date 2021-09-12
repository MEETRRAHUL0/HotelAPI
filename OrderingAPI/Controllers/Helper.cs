using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingAPI.Controllers
{
    public class Helper
    {
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
