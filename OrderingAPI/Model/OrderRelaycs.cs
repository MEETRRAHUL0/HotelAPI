using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingAPI.Model
{
    public class OrderRelaycs
    {
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Address
    {
        public string city { get; set; }
        public bool is_guest_mode { get; set; }
        public string line_1 { get; set; }
        public string line_2 { get; set; }
        public string landmark { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string sub_locality { get; set; }
        public string pin { get; set; }
        public string tag { get; set; }
    }

    public class Customer
    {
        public Address address { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
    }

    public class ChargeTax
    {
        public string title { get; set; }
        public double value { get; set; }
        public int rate { get; set; }
    }

    public class DetailsCharge
    {
        public List<ChargeTax> taxes { get; set; }
        public string title { get; set; }
        public double value { get; set; }
    }

    public class DashConfig
    {
        public bool auto_assign { get; set; }
        public bool enabled { get; set; }
    }

    public class Extras
    {
        public string order_type { get; set; }
        public bool thirty_minutes_delivery { get; set; }
        public double cash_to_be_collected { get; set; }
        public string swiggy_customer_id { get; set; }
    }

    public class Discount
    {
        public bool is_merchant_discount { get; set; }
        public double rate { get; set; }
        public string title { get; set; }
        public double value { get; set; }
        public string code { get; set; }
    }

    public class ExtPlatform
    {
        public string id { get; set; }
        public string kind { get; set; }
        public string name { get; set; }
        public string delivery_type { get; set; }
        public Extras extras { get; set; }
        public List<Discount> discounts { get; set; }
    }

    public class Details
    {
        public int biz_id { get; set; }
        public string channel { get; set; }
        public List<DetailsCharge> charges { get; set; }
        public string coupon { get; set; }
        public long created { get; set; }
        public DashConfig dash_config { get; set; }
        public long delivery_datetime { get; set; }
        public double discount { get; set; }
        public double total_external_discount { get; set; }
        public List<ExtPlatform> ext_platforms { get; set; }
        public int id { get; set; }
        public string instructions { get; set; }
        public int item_level_total_charges { get; set; }
        public double item_level_total_taxes { get; set; }
        public int item_taxes { get; set; }
        public string merchant_ref_id { get; set; }
        public object modified_from { get; set; }
        public object modified_to { get; set; }
        public int order_level_total_charges { get; set; }
        public int order_level_total_taxes { get; set; }
        public string order_state { get; set; }
        public double order_subtotal { get; set; }
        public double order_total { get; set; }
        public double payable_amount { get; set; }
        public string time_slot_end { get; set; }
        public string time_slot_start { get; set; }
        public string order_type { get; set; }
        public string state { get; set; }
        public List<Tax> taxes { get; set; }
        public double total_charges { get; set; }
        public double total_taxes { get; set; }
    }

    public class Translations
    {
        public string language { get; set; }
        public string title { get; set; }
    }

    public class OptionsToAdd
    {
        public int id { get; set; }
        public string merchant_id { get; set; }
        public int price { get; set; }
        public string title { get; set; }
        public Translations translations { get; set; }
        public double unit_weight { get; set; }
    }

    public class OrderItem
    {
        public List<DetailsCharge> charges { get; set; }
        public double discount { get; set; }
        public string food_type { get; set; }
        public int id { get; set; }
        public string image_landscape_url { get; set; }
        public string image_url { get; set; }
        public string merchant_id { get; set; }
        public List<OptionsToAdd> options_to_add { get; set; }
        public List<object> options_to_remove { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public List<Tax> taxes { get; set; }
        public string title { get; set; }
        public double total { get; set; }
        public double total_with_tax { get; set; }
        public object translations { get; set; }
        public double unit_weight { get; set; }
    }

    public class Payment
    {
        public double amount { get; set; }
        public string option { get; set; }
        public object srvr_trx_id { get; set; }
    }

    public class OrderStore
    {
        public string address { get; set; }
        public int id { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string merchant_ref_id { get; set; }
        public string name { get; set; }
    }

    public class Order
    {
        public Details details { get; set; }
        public List<OrderItem> items { get; set; }
        public string next_state { get; set; }
        public List<string> next_states { get; set; }
        public List<Payment> payment { get; set; }
        public OrderStore store { get; set; }
    }

    public class OrderRelayCallBack
    {
        public Customer customer { get; set; }
        public Order order { get; set; }
    }


}
