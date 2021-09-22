using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingAPI.Model
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class ExternalOrderReferenceUpdate
    {
        public string reference_id { get; set; }
    }



    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Extra
    {
        public int prep_time_mins { get; set; }
    }

    public class OrderStatusUpdate
    {
        public string new_status { get; set; }
        public string message { get; set; }
        public Extra extra { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class ItemsOo
    {
        public int upipr_id { get; set; }
        public string ref_id { get; set; }
    }

    public class MarkOrderItemsStockOut
    {
        public int order_upipr_id { get; set; }
        public string order_ref_id { get; set; }
        public bool allow_edit { get; set; }
        public List<ItemsOo> items_oos { get; set; }
    }




}
