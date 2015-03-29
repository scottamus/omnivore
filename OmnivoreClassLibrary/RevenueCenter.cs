using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmnivoreClassLibrary
{
    
//public class Rootobject
//{
//public _Embedded _embedded { get; set; }
//public _Links11 _links { get; set; }
//public int count { get; set; }
//public int limit { get; set; }
//}

//public class _Embedded
//{
//public Revenue_Centers[] revenue_centers { get; set; }
//}

//public class Revenue_Centers
//{
//public _Embedded1 _embedded { get; set; }
//public _Links10 _links { get; set; }
//public bool _default { get; set; }
//public string id { get; set; }
//public string name { get; set; }
//}

//public class _Embedded1
//{
//public Open_Tickets[] open_tickets { get; set; }
//public Table2[] tables { get; set; }
//}

//public class Open_Tickets
//{
//public _Embedded2 _embedded { get; set; }
//public _Links8 _links { get; set; }
//public bool auto_send { get; set; }
//public object closed_at { get; set; }
//public int guest_count { get; set; }
//public string id { get; set; }
//public string name { get; set; }
//public bool open { get; set; }
//public int opened_at { get; set; }
//public int ticket_number { get; set; }
//public Totals totals { get; set; }
//public bool _void { get; set; }
//}

//public class _Embedded2
//{
//public object[] discounts { get; set; }
//public Employee employee { get; set; }
//public Item[] items { get; set; }
//public Order_Type order_type { get; set; }
//public object[] payments { get; set; }
//public Revenue_Center revenue_center { get; set; }
//public Table table { get; set; }
//public object[] voided_items { get; set; }
//}

//public class Employee
//{
//public _Links _links { get; set; }
//public string check_name { get; set; }
//public string first_name { get; set; }
//public string id { get; set; }
//public string last_name { get; set; }
//public string login { get; set; }
//}

//public class _Links
//{
//public Self self { get; set; }
//}

//public class Self
//{
//public string etag { get; set; }
//public string href { get; set; }
//public string profile { get; set; }
//}

//public class Order_Type
//{
//public _Links1 _links { get; set; }
//public bool available { get; set; }
//public string id { get; set; }
//public string name { get; set; }
//}

//public class _Links1
//{
//public Self1 self { get; set; }
//}

//public class Self1
//{
//public string etag { get; set; }
//public string href { get; set; }
//public string profile { get; set; }
//}

//public class Revenue_Center
//{
//public _Links2 _links { get; set; }
//public bool _default { get; set; }
//public string id { get; set; }
//public string name { get; set; }
//}

//public class _Links2
//{
//public Self2 self { get; set; }
//}

//public class Self2
//{
//public string etag { get; set; }
//public string href { get; set; }
//public string profile { get; set; }
//}

//public class Table
//{
//public _Links3 _links { get; set; }
//public bool available { get; set; }
//public string id { get; set; }
//public string name { get; set; }
//public int number { get; set; }
//public int seats { get; set; }
//}

//public class _Links3
//{
//public Self3 self { get; set; }
//}

//public class Self3
//{
//public string etag { get; set; }
//public string href { get; set; }
//public string profile { get; set; }
//}

//public class Item
//{
//public _Embedded3 _embedded { get; set; }
//public _Links7 _links { get; set; }
//public string comment { get; set; }
//public string id { get; set; }
//public string name { get; set; }
//public string price_level { get; set; }
//public int price_per_unit { get; set; }
//public int quantity { get; set; }
//public bool sent { get; set; }
//}

//public class _Embedded3
//{
//public object[] discounts { get; set; }
//public Menu_Item menu_item { get; set; }
//public Modifier[] modifiers { get; set; }
//}

//public class Menu_Item
//{
//public _Links4 _links { get; set; }
//public string id { get; set; }
//public bool in_stock { get; set; }
//public int modifier_groups_count { get; set; }
//public string name { get; set; }
//public int price { get; set; }
//public Price_Levels[] price_levels { get; set; }
//}

//public class _Links4
//{
//public Modifier_Groups modifier_groups { get; set; }
//public Self4 self { get; set; }
//}

//public class Modifier_Groups
//{
//public string etag { get; set; }
//public string href { get; set; }
//public string profile { get; set; }
//}

//public class Self4
//{
//public string etag { get; set; }
//public string href { get; set; }
//public string profile { get; set; }
//}

//public class Price_Levels
//{
//public string id { get; set; }
//public int price { get; set; }
//}

//public class Modifier
//{
//public _Embedded4 _embedded { get; set; }
//public _Links6 _links { get; set; }
//public string comment { get; set; }
//public string id { get; set; }
//public string name { get; set; }
//public string price_level { get; set; }
//public int price_per_unit { get; set; }
//public int quantity { get; set; }
//}

//public class _Embedded4
//{
//public Menu_Modifier menu_modifier { get; set; }
//}

//public class Menu_Modifier
//{
//public _Links5 _links { get; set; }
//public string id { get; set; }
//public string name { get; set; }
//public Price_Levels1[] price_levels { get; set; }
//public int price_per_unit { get; set; }
//}

//public class _Links5
//{
//public Self5 self { get; set; }
//}

//public class Self5
//{
//public string etag { get; set; }
//public string href { get; set; }
//public string profile { get; set; }
//}

//public class Price_Levels1
//{
//public string id { get; set; }
//public int price { get; set; }
//}

//public class _Links6
//{
//public Menu_Modifier1 menu_modifier { get; set; }
//public Self6 self { get; set; }
//}

//public class Menu_Modifier1
//{
//public string href { get; set; }
//public string profile { get; set; }
//}

//public class Self6
//{
//public string etag { get; set; }
//public string href { get; set; }
//public string profile { get; set; }
//}

//public class _Links7
//{
//public Discounts discounts { get; set; }
//public Menu_Item1 menu_item { get; set; }
//public Modifiers modifiers { get; set; }
//public Self7 self { get; set; }
//}

//public class Discounts
//{
//public string href { get; set; }
//public string profile { get; set; }
//}

//public class Menu_Item1
//{
//public string href { get; set; }
//public string profile { get; set; }
//}

//public class Modifiers
//{
//public string href { get; set; }
//public string profile { get; set; }
//}

//public class Self7
//{
//public string etag { get; set; }
//public string href { get; set; }
//public string profile { get; set; }
//}

//public class _Links8
//{
//public Discounts1 discounts { get; set; }
//public Items items { get; set; }
//public Payments payments { get; set; }
//public Self8 self { get; set; }
//public Table1 table { get; set; }
//public Voided_Items voided_items { get; set; }
//}

//public class Discounts1
//{
//public string href { get; set; }
//public string profile { get; set; }
//}

//public class Items
//{
//public string href { get; set; }
//public string profile { get; set; }
//}

//public class Payments
//{
//public string href { get; set; }
//public string profile { get; set; }
//}

//public class Self8
//{
//public string etag { get; set; }
//public string href { get; set; }
//public string profile { get; set; }
//}

//public class Table1
//{
//public string href { get; set; }
//public string profile { get; set; }
//}

//public class Voided_Items
//{
//public string href { get; set; }
//public string profile { get; set; }
//}

//public class Totals
//{
//public int due { get; set; }
//public int other_charges { get; set; }
//public int service_charges { get; set; }
//public int sub_total { get; set; }
//public int tax { get; set; }
//public int total { get; set; }
//}

//public class Table2
//{
//public _Links9 _links { get; set; }
//public bool available { get; set; }
//public string id { get; set; }
//public string name { get; set; }
//public int number { get; set; }
//public int seats { get; set; }
//}

//public class _Links9
//{
//public Self9 self { get; set; }
//}

//public class Self9
//{
//public string etag { get; set; }
//public string href { get; set; }
//public string profile { get; set; }
//}

//public class _Links10
//{
//public Self10 self { get; set; }
//}

//public class Self10
//{
//public string etag { get; set; }
//public string href { get; set; }
//public string profile { get; set; }
//}

//public class _Links11
//{
//public Self11 self { get; set; }
//}

//public class Self11
//{
//public string etag { get; set; }
//public string href { get; set; }
//public string profile { get; set; }
//}



    class RevenueCenter
    {
    }
}
