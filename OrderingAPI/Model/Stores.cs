using System.Collections.Generic;

namespace OrderingAPI.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class StoreTranslation
    {
        public string language { get; set; }
        public string name { get; set; }
    }

    public class PlatformData
    {
        public string name { get; set; }
        public string url { get; set; }
        public string platform_store_id { get; set; }
    }

    public class StoreSlot
    {
        public string start_time { get; set; }
        public string end_time { get; set; }
    }

    public class Timing
    {
        public string day { get; set; }
        public List<StoreSlot> slots { get; set; }
    }

    public class Store
    {
        public string city { get; set; }
        public string name { get; set; }
        public int min_pickup_time { get; set; }
        public int min_delivery_time { get; set; }
        public string contact_phone { get; set; }
        public List<string> notification_phones { get; set; }
        public string ref_id { get; set; }
        public int min_order_value { get; set; }
        public bool hide_from_ui { get; set; }
        public string address { get; set; }
        public List<string> notification_emails { get; set; }
        public List<string> zip_codes { get; set; }
        public double geo_longitude { get; set; }
        public bool active { get; set; }
        public double geo_latitude { get; set; }
        public bool ordering_enabled { get; set; }
        public List<StoreTranslation> translations { get; set; }
        public List<string> excluded_platforms { get; set; }
        public List<PlatformData> platform_data { get; set; }
        public List<Timing> timings { get; set; }
        public List<string> included_platforms { get; set; }
    }

    public class StoreRequest
    {
        public List<Store> stores { get; set; }
    }
}