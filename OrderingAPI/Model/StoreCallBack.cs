using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingAPI.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Stats
    {
        public int updated { get; set; }
        public int errors { get; set; }
        public int created { get; set; }
    }

    public class UpiprStatus
    {
        public string action { get; set; }
        public int id { get; set; }
        public bool error { get; set; }
        public string err_msg { get; set; }
    }

    public class StoreList
    {
        public UpiprStatus upipr_status { get; set; }
    }

    public class StoreCallBack
    {
        public string reference { get; set; }
        public Stats stats { get; set; }
        public List<StoreList> stores { get; set; }
    }


}
