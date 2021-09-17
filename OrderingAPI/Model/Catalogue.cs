using System.Collections.Generic;

namespace OrderingAPI.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class CategoryTranslation
    {
        public string language { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string title { get; set; }
    }

    public class Category
    {
        public string ref_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int sort_order { get; set; }
        public bool active { get; set; }
        public string img_url { get; set; }
        public List<CategoryTranslation> translations { get; set; }
        public string parent_ref_id { get; set; }
    }

    public class Image
    {
        public string tag { get; set; }
        public string url { get; set; }
    }

    public class Tags
    {
        public List<string> zomato { get; set; }
        public List<string> swiggy { get; set; }
        public List<string> amazon { get; set; }
    }

    public class Item
    {
        public string ref_id { get; set; }
        public string title { get; set; }
        public bool available { get; set; }
        public string description { get; set; }
        public double weight { get; set; }
        public bool sold_at_store { get; set; }
        public int sort_order { get; set; }
        public int serves { get; set; }
        public double external_price { get; set; }
        public double price { get; set; }
        public double markup_price { get; set; }
        public int current_stock { get; set; }
        public bool recommended { get; set; }
        public string food_type { get; set; }
        public List<string> category_ref_ids { get; set; }
        public List<string> fulfillment_modes { get; set; }
        public List<Image> images { get; set; }
        public string img_url { get; set; }
        public List<CategoryTranslation> translations { get; set; }
        public Tags tags { get; set; }
        public List<string> included_platforms { get; set; }
        public string ref_title { get; set; }
    }

    public class OptionGroup
    {
        public string ref_id { get; set; }
        public string title { get; set; }
        public string ref_title { get; set; }
        public int min_selectable { get; set; }
        public int max_selectable { get; set; }
        public bool clear_item_ref_ids { get; set; }
        public bool display_inline { get; set; }
        public bool active { get; set; }
        public List<string> item_ref_ids { get; set; }
        public int sort_order { get; set; }
        public List<CategoryTranslation> translations { get; set; }
    }

    public class Option
    {
        public string ref_id { get; set; }
        public string title { get; set; }
        public string ref_title { get; set; }
        public string description { get; set; }
        public int weight { get; set; }
        public bool available { get; set; }
        public bool recommended { get; set; }
        public double price { get; set; }
        public bool sold_at_store { get; set; }
        public int sort_order { get; set; }
        public bool clear_opt_grp_ref_ids { get; set; }
        public List<string> opt_grp_ref_ids { get; set; }
        public List<object> nested_opt_grps { get; set; }
        public string food_type { get; set; }
        public List<CategoryTranslation> translations { get; set; }
    }

    public class Structure
    {
        public double value { get; set; }
        public string applicable_on { get; set; }
    }

    public class Tax
    {
        public string code { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public bool active { get; set; }
        public Structure structure { get; set; }
        public List<string> item_ref_ids { get; set; }
        public List<string> location_ref_ids { get; set; }
        public bool clear_items { get; set; }
        public bool clear_locations { get; set; }
    }

    public class Charge
    {
        public string code { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public bool active { get; set; }
        public Structure structure { get; set; }
        public List<string> fulfillment_modes { get; set; }
        public List<object> excluded_platforms { get; set; }
        public List<string> item_ref_ids { get; set; }
        public List<string> location_ref_ids { get; set; }
        public bool clear_items { get; set; }
        public bool clear_locations { get; set; }
    }

    public class CatalogueRequest
    {
        public bool flush_categories { get; set; }
        public List<Category> categories { get; set; }
        public bool flush_items { get; set; }
        public List<Item> items { get; set; }
        public bool flush_option_groups { get; set; }
        public List<OptionGroup> option_groups { get; set; }
        public bool flush_options { get; set; }
        public List<Option> options { get; set; }
        public bool flush_taxes { get; set; }
        public List<Tax> taxes { get; set; }
        public bool flush_charges { get; set; }
        public List<Charge> charges { get; set; }
    }
}