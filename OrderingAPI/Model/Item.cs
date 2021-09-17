using System.Collections.Generic;

namespace OrderingAPI.Model
{
    public class ItemRequest
    {
        public string location_ref_id { get; set; }
        public List<string> item_ref_ids { get; set; }
        public List<string> option_ref_ids { get; set; }
        public string action { get; set; }
    }
}