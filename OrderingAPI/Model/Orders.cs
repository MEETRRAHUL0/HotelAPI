using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingAPI.Model
{
    public class Orders
    {
        public List<OrderItem> Items { get; set; }
        public string ID { get; set; }
        public string customer_phone { get; set; }
        public string customer_address { get; set; }
        public string customer_email { get; set; }
        public string customer_name { get; set; }
        public string next_state { get; set; }
        public string store_name { get; set; }
        public string store_longitude { get; set; }
        public string store_merchant_ref_id { get; set; }
        public string store_address { get; set; }
        public string store_latitude { get; set; }
        public string store_id { get; set; }
        public string coupon { get; set; }
        public string total_taxes { get; set; }
        public string merchant_ref_id { get; set; }
        public string order_level_total_charges { get; set; }
        public string Order_id { get; set; }
        public string payable_amount { get; set; }
        public string total_external_discount { get; set; }
        public string order_total { get; set; }
        public string order_type { get; set; }
        public string state { get; set; }
        public string modified_from { get; set; }
        public string channel { get; set; }
        public string delivery_datetime { get; set; }
        public string item_level_total_charges { get; set; }
        public string item_taxes { get; set; }
        public string modified_to { get; set; }
        public string item_level_total_taxes { get; set; }
        public string biz_id { get; set; }
        public string order_state { get; set; }
        public string instructions { get; set; }
        public string total_charges { get; set; }
        public string discount { get; set; }
        public string created { get; set; }
        public string order_level_total_taxes { get; set; }
        public string order_subtotal { get; set; }
        public string dash_config_auto_assign { get; set; }
        public string dash_config_enabled { get; set; }
        public string OrderJSON { get; set; }
        //public string next_state { get; set; }

        ////Customer Details
        //public string Customer_address { get; set; }
        //public string Customer_email { get; set; }
        //public string Customer_name { get; set; }
        //public string Customer_phone { get; set; }

        //// Store
        //public string Store_address { get; set; }
        //public int Store_id { get; set; }
        //public double Store_latitude { get; set; }
        //public double Store_longitude { get; set; }
        //public string Store_merchant_ref_id { get; set; }
        //public string Store_name { get; set; }


        //// Details
        //public int biz_id { get; set; }
        //public string channel { get; set; }
        //public string coupon { get; set; }
        //public long created { get; set; }
        //public DashConfig dash_config { get; set; }
        //public long delivery_datetime { get; set; }
        //public double discount { get; set; }
        //public double total_external_discount { get; set; }
        //public int id { get; set; }
        //public string instructions { get; set; }
        //public double item_level_total_charges { get; set; }
        //public double item_level_total_taxes { get; set; }
        //public double item_taxes { get; set; }
        //public string merchant_ref_id { get; set; }
        //public object modified_from { get; set; }
        //public object modified_to { get; set; }
        //public double order_level_total_charges { get; set; }
        //public double order_level_total_taxes { get; set; }
        //public string order_state { get; set; }
        //public double order_subtotal { get; set; }
        //public double order_total { get; set; }
        //public double payable_amount { get; set; }
        //public string time_slot_end { get; set; }
        //public string time_slot_start { get; set; }
        //public string order_type { get; set; }
        //public string state { get; set; }
        //public double total_charges { get; set; }
        //public double total_taxes { get; set; }
    }
}
