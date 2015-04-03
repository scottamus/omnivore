using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using OmnivoreClassLibrary.DataContracts.V01;
using OmnivoreClassLibrary.DataContracts.V01.Enums;
using OmnivoreClassLibrary.DataAccess;

namespace OmnivoreClassLibrary
{
    public static class TestConnection
    {
        public static async Task<MainInterface> TestGetMainInterface_Async() // root https://api.omnivore.io
        {
            MainInterface output = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.omnivore.io/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key

                HttpResponseMessage response = await client.GetAsync(String.Empty);
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    if (!String.IsNullOrEmpty(jsonString))
                    {
                        JObject mainInter = JObject.Parse(jsonString);

                        JsonSerializer serializer = new JsonSerializer();
                        serializer.NullValueHandling = NullValueHandling.Ignore; // to skip setting null onto enums, especially

                        output = mainInter.ToObject<MainInterface>(serializer);
                    }
                }
            }

            return output;
        }

        public static async Task<LocationCollection> TestGetLocationCollection_Async() // root https://api.omnivore.io/0.1/locations
        {
            LocationCollection output = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.omnivore.io/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key

                string apiVersion = AppSettings.API_Version;
                HttpResponseMessage response = await client.GetAsync(String.Concat(apiVersion, "/", "locations"));
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    if (!String.IsNullOrEmpty(jsonString))
                    {
                        JObject loc = JObject.Parse(jsonString);

                        JsonSerializer serializer = new JsonSerializer();
                        serializer.NullValueHandling = NullValueHandling.Ignore; // to skip setting null onto enums, especially
                        output = loc.ToObject<LocationCollection>(serializer);
                    }
                }
            }

            return output;
        }

        public static async Task<Location> TestGetLocation_Async() //https://api.omnivore.io/0.1/locations/zGibgKT9/
        {
            Location output = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.omnivore.io/");
                client.DefaultRequestHeaders.Accept.Clear(); // just to be extra safe
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key to request headers

                string apiVersion = AppSettings.API_Version;
                string defaultLocationId = AppSettings.DefaultLocationId;
                HttpResponseMessage response = await client.GetAsync(String.Concat(apiVersion, "/locations/", defaultLocationId, "/")); // TODO: build up better later
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    if (!String.IsNullOrEmpty(jsonString))
                    {
                        JObject loc = JObject.Parse(jsonString);

                        JsonSerializer serializer = new JsonSerializer();
                        serializer.NullValueHandling = NullValueHandling.Ignore; // to skip setting null onto enums, especially

                        output = loc.ToObject<Location>(serializer);
                    }
                }
                else
                {
                    // TODO: deal with other codes here
                }
            }

            return output;
        }

        public static async Task<Menu> TestGetMenu_Async() //https://api.omnivore.io/0.1/locations/zGibgKT9/menu/
        {
            Menu output = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.omnivore.io/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key

                string apiVersion = AppSettings.API_Version;
                string defaultLocationId = AppSettings.DefaultLocationId;
                HttpResponseMessage response = await client.GetAsync(String.Concat(apiVersion, "/locations/", defaultLocationId, "/", "menu"));
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    if (!String.IsNullOrEmpty(jsonString))
                    {
                        JObject menuTmp = JObject.Parse(jsonString);

                        JsonSerializer serializer = new JsonSerializer();
                        serializer.NullValueHandling = NullValueHandling.Ignore; // to skip setting null onto enums, especially

                        output = menuTmp.ToObject<Menu>(serializer);
                    }
                }
            }

            return output;
        }

        public static async Task<CategoryCollection> TestGetMenuCategoriesAndItems_Async() //https://api.omnivore.io/0.1/locations/zGibgKT9/menu/categories/
        {
            CategoryCollection output = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.omnivore.io/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key

                string apiVersion = AppSettings.API_Version;
                string defaultLocationId = AppSettings.DefaultLocationId;
                HttpResponseMessage response = await client.GetAsync(String.Concat(apiVersion, "/locations/", defaultLocationId, "/", "menu", "/", "categories"));
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    if (!String.IsNullOrEmpty(jsonString))
                    {
                        JObject menuTmp = JObject.Parse(jsonString);

                        JsonSerializer serializer = new JsonSerializer();
                        serializer.NullValueHandling = NullValueHandling.Ignore; // to skip setting null onto enums, especially

                        output = menuTmp.ToObject<CategoryCollection>(serializer);
                    }
                }
            }

            return output;
        }

        public static async Task<MenuItemModifierGroupCollection> TestGetMenuItemModifierGroupCollection_Async() //https://api.omnivore.io/0.1/locations/zGibgKT9/menu/items/rMTAbTjr/modifier_groups/
        {
            MenuItemModifierGroupCollection output = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.omnivore.io/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key

                string apiVersion = AppSettings.API_Version;
                string defaultLocationId = AppSettings.DefaultLocationId;
                HttpResponseMessage response = await client.GetAsync(String.Concat(apiVersion, "/locations/", defaultLocationId, "/menu/items/rMTAbTjr/modifier_groups/"));
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    if (!String.IsNullOrEmpty(jsonString))
                    {
                        JObject menuTmp = JObject.Parse(jsonString);

                        JsonSerializer serializer = new JsonSerializer();
                        serializer.NullValueHandling = NullValueHandling.Ignore; // to skip setting null onto enums, especially

                        output = menuTmp.ToObject<MenuItemModifierGroupCollection>(serializer);
                    }
                }
            }

            return output;
        }

        public static async Task<MenuItemModifierGroupCollection> TestGetMenuItemModifierGroupCollection_Async(string url) //https://api.omnivore.io/0.1/locations/zGibgKT9/menu/items/rMTAbTjr/modifier_groups/
        {
            MenuItemModifierGroupCollection output = null;

            using (HttpClient client = new HttpClient())
            {
                //client.BaseAddress = new Uri("https://api.omnivore.io/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    if (!String.IsNullOrEmpty(jsonString))
                    {
                        JObject menuTmp = JObject.Parse(jsonString);

                        JsonSerializer serializer = new JsonSerializer();
                        serializer.NullValueHandling = NullValueHandling.Ignore; // to skip setting null onto enums, especially

                        output = menuTmp.ToObject<MenuItemModifierGroupCollection>(serializer);
                    }
                }
            }

            return output;
        }

        public static async Task<TableCollection> TestGetTableCollection_Async() // root https://api.omnivore.io/0.1/locations/zGibgKT9/tables
        {
            TableCollection output = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.omnivore.io/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key

                string apiVersion = AppSettings.API_Version;
                HttpResponseMessage response = await client.GetAsync(String.Concat(apiVersion, "/", "locations", "/", "zGibgKT9", "/tables"));
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    if (!String.IsNullOrEmpty(jsonString))
                    {
                        JObject loc = JObject.Parse(jsonString);

                        JsonSerializer serializer = new JsonSerializer();
                        serializer.NullValueHandling = NullValueHandling.Ignore; // to skip setting null onto enums, especially

                        output = loc.ToObject<TableCollection>(serializer);
                    }
                }
            }

            return output;
        }

        public static async Task<RevenueCenterCollection> TestGetRevenueCenterCollection_Async() // root https://api.omnivore.io/0.1/locations/zGibgKT9/revenue_centers
        {
            RevenueCenterCollection output = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.omnivore.io/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key

                string apiVersion = AppSettings.API_Version;
                HttpResponseMessage response = await client.GetAsync(String.Concat(apiVersion, "/", "locations", "/", "zGibgKT9", "/revenue_centers"));
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    if (!String.IsNullOrEmpty(jsonString))
                    {
                        JObject loc = JObject.Parse(jsonString);

                        JsonSerializer serializer = new JsonSerializer();
                        serializer.NullValueHandling = NullValueHandling.Ignore; // to skip setting null onto enums, especially

                        output = loc.ToObject<RevenueCenterCollection>(serializer);
                    }
                }
            }

            return output;
        }

        public static async Task<OrderTypeCollection> TestGetOrderTypeCollection_Async() // root https://api.omnivore.io/0.1/locations/zGibgKT9/revenue_centers
        {
            OrderTypeCollection output = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.omnivore.io/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key

                string apiVersion = AppSettings.API_Version;
                HttpResponseMessage response = await client.GetAsync(String.Concat(apiVersion, "/", "locations", "/", "zGibgKT9", "/order_types"));
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    if (!String.IsNullOrEmpty(jsonString))
                    {
                        JObject loc = JObject.Parse(jsonString);

                        JsonSerializer serializer = new JsonSerializer();
                        serializer.NullValueHandling = NullValueHandling.Ignore; // to skip setting null onto enums, especially

                        output = loc.ToObject<OrderTypeCollection>(serializer);
                    }
                }
            }

            return output;
        }

        public static async Task<EmployeeCollection> TestGetEmployeeCollection_Async() // root https://api.omnivore.io/0.1/locations/zGibgKT9/revenue_centers
        {
            EmployeeCollection output = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.omnivore.io/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key

                string apiVersion = AppSettings.API_Version;
                HttpResponseMessage response = await client.GetAsync(String.Concat(apiVersion, "/", "locations", "/", "zGibgKT9", "/employees"));
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    if (!String.IsNullOrEmpty(jsonString))
                    {
                        JObject loc = JObject.Parse(jsonString);

                        JsonSerializer serializer = new JsonSerializer();
                        serializer.NullValueHandling = NullValueHandling.Ignore; // to skip setting null onto enums, especially

                        output = loc.ToObject<EmployeeCollection>(serializer);
                    }
                }
            }

            return output;
        }

        public static async Task<OmnivoreCollection<TenderType>> TestGetTenderTypeCollection_Async(string url)
        {
            OmnivoreDataManager mgr = new OmnivoreDataManager();
            OmnivoreCollection<TenderType> output = await mgr.GetOmnivoreCollection<OmnivoreCollection<TenderType>>(url);

            return output;
        }

        public static async Task<Ticket> TestGetTicket(string ticketId)
        {
            Ticket output = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.omnivore.io/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key

                string apiVersion = AppSettings.API_Version;
                HttpResponseMessage response = await client.GetAsync(String.Concat(apiVersion, "/", "locations", "/", "zGibgKT9", "/", "tickets", "/", ticketId));
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    if (!String.IsNullOrEmpty(jsonString))
                    {
                        JObject loc = JObject.Parse(jsonString);

                        JsonSerializer serializer = new JsonSerializer();
                        serializer.NullValueHandling = NullValueHandling.Ignore; // to skip setting null onto enums, especially

                        output = loc.ToObject<Ticket>(serializer);
                    }
                }
            }

            return output;
        }

        public static async Task<Ticket> TestOpenTicket_Basic(Ticket ticket)
        {
            Ticket output = null;

            //// TODO: get location links and other domain data from POS system on startup or if not there, and cache
            //Location loc = await TestGetLocation_Async();
            //if (loc != null && loc.Links != null)
            //{
            //    KeyValuePair<string, Link> kvpEmps = loc.Links.Where(l => l.Key == "employees").FirstOrDefault();
            //    Link employeesLink = kvpEmps.Value;
            //}

            TicketOpenDTO ticketToCreate = new TicketOpenDTO(ticket);

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.omnivore.io/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key

                string apiVersion = AppSettings.API_Version;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                string json = JsonConvert.SerializeObject(ticketToCreate, settings);
                StringContent stringContent = new StringContent(json);
                HttpResponseMessage response = await client.PostAsync(String.Concat(apiVersion, "/", "locations", "/", "zGibgKT9", "/tickets"), stringContent);
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    if (!String.IsNullOrEmpty(jsonString))
                    {
                        JObject loc = JObject.Parse(jsonString);

                        JsonSerializer serializer = new JsonSerializer();
                        serializer.NullValueHandling = NullValueHandling.Ignore; // to skip setting null onto enums, especially

                        output = loc.ToObject<Ticket>(serializer);
                    }
                }
            }

            return output;
        }

        public static async Task<Ticket> AddTicketItems(string ticketId, List<TicketItem> ticketItemsToAdd)
        {
            Ticket output = null;

            if (!String.IsNullOrEmpty(ticketId) && ticketItemsToAdd != null && ticketItemsToAdd.Count > 0)
            {
                List<TicketItemOpenDTO> ticketItemDTOs = new List<TicketItemOpenDTO>();
                foreach (TicketItem item in ticketItemsToAdd)
                {
                    ticketItemDTOs.Add(new TicketItemOpenDTO(item));
                }

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api.omnivore.io/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key

                    string apiVersion = AppSettings.API_Version;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    string json = JsonConvert.SerializeObject(ticketItemDTOs, settings);
                    StringContent stringContent = new StringContent(json);
                    HttpResponseMessage response = await client.PostAsync(String.Concat(apiVersion, "/", "locations", "/", "zGibgKT9", "/", "tickets", "/", ticketId, "/", "items"), stringContent); // todo: fix how I build URL
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();

                        if (!String.IsNullOrEmpty(jsonString))
                        {
                            JObject loc = JObject.Parse(jsonString);

                            JsonSerializer serializer = new JsonSerializer();
                            serializer.NullValueHandling = NullValueHandling.Ignore; // to skip setting null onto enums, especially

                            output = loc.ToObject<Ticket>(serializer);
                        }
                    }
                }
            }

            return output;
        }

        public static async Task<PaymentStatus> MakePayment(string ticketId, PaymentDTO payment)
        {
            PaymentStatus output = null;

            if (!String.IsNullOrEmpty(ticketId) && payment != null)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api.omnivore.io/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key

                    string apiVersion = AppSettings.API_Version;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    string json = JsonConvert.SerializeObject(payment, settings);
                    StringContent stringContent = new StringContent(json);
                    HttpResponseMessage response = await client.PostAsync(String.Concat(apiVersion, "/", "locations", "/", "zGibgKT9", "/", "tickets", "/", ticketId, "/", "payments"), stringContent); // todo: fix how I build URL
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();

                        if (!String.IsNullOrEmpty(jsonString))
                        {
                            JObject loc = JObject.Parse(jsonString);

                            JsonSerializer serializer = new JsonSerializer();
                            serializer.NullValueHandling = NullValueHandling.Ignore; // to skip setting null onto enums, especially

                            output = loc.ToObject<PaymentStatus>(serializer);
                        }
                    }
                }
            }

            return output;
        }

        public static async Task<PaymentStatus> MakePaymentThirdParty(string ticketId, PaymentThirdPartyDTO payment)
        {
            PaymentStatus output = null;

            if (!String.IsNullOrEmpty(ticketId) && payment != null)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api.omnivore.io/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key

                    string apiVersion = AppSettings.API_Version;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    string json = JsonConvert.SerializeObject(payment, settings);
                    StringContent stringContent = new StringContent(json);
                    HttpResponseMessage response = await client.PostAsync(String.Concat(apiVersion, "/", "locations", "/", "zGibgKT9", "/", "tickets", "/", ticketId, "/", "payments"), stringContent); // todo: fix how I build URL
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();

                        if (!String.IsNullOrEmpty(jsonString))
                        {
                            JObject loc = JObject.Parse(jsonString);

                            JsonSerializer serializer = new JsonSerializer();
                            serializer.NullValueHandling = NullValueHandling.Ignore; // to skip setting null onto enums, especially

                            output = loc.ToObject<PaymentStatus>(serializer);
                        }
                    }
                }
            }

            return output;
        }
    }
}
