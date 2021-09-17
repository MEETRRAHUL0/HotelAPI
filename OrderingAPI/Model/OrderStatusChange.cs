using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingAPI.Model
{
    public class OrderStatusChange
    {
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ExternalChannel
    {
        public string name { get; set; }
        public string order_id { get; set; }
    }

    public class AdditionalInfo
    {
        public bool customer_cancellation { get; set; }
        public ExternalChannel external_channel { get; set; }
        public int timeout_secs { get; set; }
    }

    public class Updater
    {
        public string username { get; set; }
        public string name { get; set; }
    }

    public class OrderStatusChangeCallBack
    {
        public AdditionalInfo additional_info { get; set; }
        public string new_state { get; set; }
        public int order_id { get; set; }
        public string prev_state { get; set; }
        public string timestamp { get; set; }
        public string store_id { get; set; }
        public long timestamp_unix { get; set; }
        public string message { get; set; }
        public Updater updater { get; set; }
    }


}
