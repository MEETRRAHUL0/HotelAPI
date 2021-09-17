using System.Collections.Generic;

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

    public class StoreList : Store
    {
        public UpiprStatus upipr_status { get; set; }
    }

    public class StoresCallBack : StoreRequest
    {
        public string reference { get; set; }
        public Stats stats { get; set; }
        //public List<StoreList> stores { get; set; }
    }


    public class StoreActionsCallBack
    {
        public string action { get; set; }
        public string location_ref_id { get; set; }
        public int location_upipr_id { get; set; }
        public string platform { get; set; }
        public string action_src { get; set; }
        public string reference_id { get; set; }
        public bool status { get; set; }
        public long ts_utc { get; set; }
    }


    public class Categories
    {
        public int updated { get; set; }
        public int errors { get; set; }
        public int created { get; set; }
        public int deleted { get; set; }
        public UpiprStatus upipr_status { get; set; }
    }

    public class Items
    {
        public int updated { get; set; }
        public int errors { get; set; }
        public int created { get; set; }
        public int deleted { get; set; }
        public UpiprStatus upipr_status { get; set; }
    }

    public class OptionGroups
    {
        public int updated { get; set; }
        public int errors { get; set; }
        public int created { get; set; }
        public int deleted { get; set; }
        public UpiprStatus upipr_status { get; set; }
    }

    public class Options
    {
        public int updated { get; set; }
        public int errors { get; set; }
        public int created { get; set; }
        public int deleted { get; set; }
        public UpiprStatus upipr_status { get; set; }
    }

    public class CatalogueStats
    {
        public Categories categories { get; set; }
        public Items items { get; set; }
        public OptionGroups option_groups { get; set; }
        public Options options { get; set; }
    }

    public class CatalogueCharge : Charge
    {
        public UpiprStatus upipr_status { get; set; }
    }

    public class CatalogueTax: Tax
    {
        public UpiprStatus upipr_status { get; set; }
    }

    public class CatalogueIngestionCallBack : CatalogueRequest
    {
        public string reference { get; set; }
        public CatalogueStats stats { get; set; }
    }

    public class Stat
    {
        public string category { get; set; }
        public bool success { get; set; }
        public List<Stat> stats { get; set; }
        public string title { get; set; }
    }

    public class CategoryTimingGroupCallBack : CategoryTimingGroupsRequest
    {
        public string reference_id { get; set; }
        public List<Stat> stats { get; set; }
    }


    public class StatusItem
    {
        public int id { get; set; }
        public int ilpa_id { get; set; }
        public string ref_id { get; set; }
        public string status { get; set; }
    }

    public class Location
    {
        public int id { get; set; }
        public string ref_id { get; set; }
    }

    public class Status
    {
        public List<StatusItem> items { get; set; }
        public Location location { get; set; }
    }

    public class ItemActionsCallBack
    {
        public string action { get; set; }
        public string platform { get; set; }
        public string reference_id { get; set; }
        public List<Status> status { get; set; }
        public long ts_utc { get; set; }
    }

    public class ActionsOption
    {
        public int id { get; set; }
        public string ref_id { get; set; }
        public bool success { get; set; }
    }

    public class OptionActionsCallBack
    {
        public string action { get; set; }
        public Location location { get; set; }
        public List<ActionsOption> options { get; set; }
        public string platform { get; set; }
        public string reference_id { get; set; }
        public long ts_utc { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class StockoutStore
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Data
    {
        public string message { get; set; }
        public string customer_masked_number { get; set; }
        public string pin { get; set; }
    }

    public class MarkOrderItemsStockoutCallBack
    {
        public bool success { get; set; }
        public string reference_id { get; set; }
        public string platform { get; set; }
        public int upipr_order_id { get; set; }
        public string ref_order_id { get; set; }
        public string platform_order_id { get; set; }
        public StockoutStore store { get; set; }
        public Data data { get; set; }
    }



}