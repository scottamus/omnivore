using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmnivoreClassLibrary
{
    // root (https://api.omnivore.io)

    public class Interface
    {
        //public Links _links { get; set; }
        public List<Version> versions { get; set; }
    }

    public class Version
    {
        public object deprecation_date { get; set; }
        public string href { get; set; }
        public int major { get; set; }
        public int minor { get; set; }
        public string release_date { get; set; }
        public object retirement_date { get; set; }
        public string status { get; set; }
    }

// version (https://api.omnivore.io/0.1)

// locations (https://api.omnivore.io/0.1/locations)

    //public class LocationsCollection
    //{
    //    public _Embedded _embedded { get; set; }
    //    public Links _links { get; set; }
    //    public int count { get; set; }
    //}

    //public class _Embedded
    //{
    //    public List<Location> locations { get; set; }
    //    public List<Category> categories { get; set; }
    //    public List<MenuItem> menu_items { get; set; }
    //    public List<Item> items { get; set; }
    //    public List<Modifier> modifiers { get; set; }
    //}

    //public class Discounts
    //{
    //    public string href { get; set; }
    //    public string profile { get; set; }
    //}

    //public class Employees
    //{
    //    public string href { get; set; }
    //    public string profile { get; set; }
    //}

    //public class Menu
    //{
    //    public string href { get; set; }
    //    public string profile { get; set; }
    //}

    //public class OrderTypes
    //{
    //    public string href { get; set; }
    //    public string profile { get; set; }
    //}

    //public class RevenueCenters
    //{
    //    public string href { get; set; }
    //    public string profile { get; set; }
    //}

    //public class Self
    //{
    //    public string etag { get; set; }
    //    public string href { get; set; }
    //    public string profile { get; set; }
    //}

    //public class Tables
    //{
    //    public string href { get; set; }
    //    public string profile { get; set; }
    //}

    //public class TenderTypes
    //{
    //    public string href { get; set; }
    //    public string profile { get; set; }
    //}

    //public class Tickets
    //{
    //    public string href { get; set; }
    //    public string profile { get; set; }
    //}

    //public class Activate
    //{
    //    public string href { get; set; }
    //}

    //public class Locations
    //{
    //    public string href { get; set; }
    //    public string profile { get; set; }
    //}

    //public class Links
    //{
    //    public Activate activate { get; set; }
    //    public Locations locations { get; set; }
    //    public Discounts discounts { get; set; }
    //    public Employees employees { get; set; }
    //    public Menu menu { get; set; }
    //    public OrderTypes order_types { get; set; }
    //    public RevenueCenters revenue_centers { get; set; }
    //    public Self self { get; set; }
    //    public Tables tables { get; set; }
    //    public TenderTypes tender_types { get; set; }
    //    public Tickets tickets { get; set; }
    //    public Categories categories { get; set; }
    //    public Items items { get; set; }
    //    public Modifiers modifiers { get; set; }
    //    public ModifierGroups modifier_groups { get; set; }
    //}

    public class Address
    {
        public object city { get; set; }
        public object state { get; set; }
        public object street1 { get; set; }
        public object street2 { get; set; }
        public object zip { get; set; }
    }

    public class Location
    {
        //public Links _links { get; set; }
        public Address address { get; set; }
        public int created { get; set; }
        public string display_name { get; set; }
        public string id { get; set; }
        public int modified { get; set; }
        public string name { get; set; }
        public object phone { get; set; }
        public string status { get; set; }
        public object website { get; set; }
    }

    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class MenuCategoryCollection
    {
        public int count { get; set; }
        public int limit { get; set; }
    }

    public class MenuItemsCollection
    {
        public int count { get; set; }
        public int limit { get; set; }
    }

    public class ModifierCollection
    {
        public int count { get; set; }
        public int limit { get; set; }
    }

    public class PriceLevel
    {
        public string id { get; set; }
        public int price { get; set; }
    }

    public class MenuItem
    {
        public string id { get; set; }
        public bool in_stock { get; set; }
        public int modifier_groups_count { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public List<PriceLevel> price_levels { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public bool in_stock { get; set; }
        public int modifier_groups_count { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public List<PriceLevel> price_levels { get; set; }
    }

    public class Modifier
    {
        //public Links _links { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public List<PriceLevel> price_levels { get; set; }
        public int price_per_unit { get; set; }
    }

// specific location (https://api.omnivore.io/0.1/locations/zGibgKT9/)


//    public class Discount
//    {
//        public _Links _links { get; set; }
//        public Applies_To applies_to { get; set; }
//        public string id { get; set; }
//        public int? max_value { get; set; }
//        public object min_ticket_total { get; set; }
//        public object min_value { get; set; }
//        public string name { get; set; }
//        public bool open { get; set; }
//        public string type { get; set; }
//        public int? value { get; set; }
//    }

//    public class Applies_To
//    {
//        public bool item { get; set; }
//        public bool ticket { get; set; }
//    }


}
