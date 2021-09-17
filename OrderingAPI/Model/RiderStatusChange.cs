using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingAPI.Model
{
    public class RiderStatusChange
    {
    }

    public class RSExternalChannel
    {
        public string name { get; set; }
        public string order_id { get; set; }
    }

    public class RSAdditionalInfo
    {
        public RSExternalChannel external_channel { get; set; }
        public string bag_return_otp { get; set; }
    }

    public class DeliveryPersonDetails
    {
        public string alt_phone { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public int user_id { get; set; }
    }

    public class StatusUpdate
    {
        public object comments { get; set; }
        public object created { get; set; }
        public string status { get; set; }
    }

    public class DeliveryInfo
    {
        public string current_state { get; set; }
        public DeliveryPersonDetails delivery_person_details { get; set; }
        public string mode { get; set; }
        public List<StatusUpdate> status_updates { get; set; }
    }

    public class RSStore
    {
        public int id { get; set; }
        public string ref_id { get; set; }
    }

    public class RiderStatusChangeCallBack
    {
        public RSAdditionalInfo additional_info { get; set; }
        public DeliveryInfo delivery_info { get; set; }
        public int order_id { get; set; }
        public RSStore store { get; set; }
    }


}
