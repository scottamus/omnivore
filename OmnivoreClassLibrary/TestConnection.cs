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

                        // load links
                        output.Links = LoadLinks(mainInter);
                    }

                    //JObject inter = JObject.Parse(jsonString);
                    //output = inter.ToObject<MainInterface>();
                }
            }

            return output;
        }

        public static async Task<List<Location>> TestGetLocationsCollection_Async() // root https://api.omnivore.io/0.1/locations
        {
            List<Location> output = null;

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

                        JToken locToken = loc["_embedded"];
                        JArray locArray = locToken["locations"] as JArray;
                        output = locArray.ToObject<List<Location>>(serializer);

                        // don't need to load links for this, because we only want the list of locations..
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

                        // load links
                        output.Links = LoadLinks(loc);
                    }
                }
                else
                {
                    // TODO: deal with other codes here
                }
            }

            return output;
        }

        /// <summary>
        /// Loads the links.
        /// </summary>
        /// <param name="jObj">The j object.</param>
        /// <returns></returns>
        private static List<Link> LoadLinks(JObject jObj)
        {
            List<Link> output = null;

            if (jObj["_links"] != null)
            {
                JObject inner = jObj["_links"].Value<JObject>();

                List<string> keys = inner.Properties().Select(p => p.Name).ToList();

                output = new List<Link>();

                foreach (string k in keys)
                {
                    LinkDetail ld = inner[k].ToObject<LinkDetail>();

                    output.Add(new Link() { Name = k, LinkDetail = new LinkDetail() { Etag = ld.Etag, URL = ld.URL, Profile = ld.Profile } });
                }
            }

            return output;
        }

        //public static async Task<MenuLinks> TestGetMenuLinks_Async() //https://api.omnivore.io/0.1/locations/zGibgKT9/menu/
        //{
        //    MenuLinks output = null;

        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://api.omnivore.io/");
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key

        //        string apiVersion = AppSettings.API_Version;
        //        string defaultLocationId = AppSettings.DefaultLocationId;
        //        HttpResponseMessage response = await client.GetAsync(String.Concat(apiVersion, "/locations/", defaultLocationId, "/", "menu"));
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string jsonString = await response.Content.ReadAsStringAsync();
        //            output = JsonConvert.DeserializeObject<MenuLinks>(jsonString);
        //        }
        //    }

        //    return output;
        //}

        //public static async Task<MenuItemsCollection> TestGetMenuItemsCollection_Async() //https://api.omnivore.io/0.1/locations/zGibgKT9/menu/items/
        //{
        //    MenuItemsCollection output = null;

        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://api.omnivore.io/");
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key

        //        string apiVersion = AppSettings.API_Version;
        //        string defaultLocationId = AppSettings.DefaultLocationId;
        //        HttpResponseMessage response = await client.GetAsync(String.Concat(apiVersion, "/locations/", defaultLocationId, "/", "menu", "/", "items"));
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string jsonString = await response.Content.ReadAsStringAsync();
        //            output = JsonConvert.DeserializeObject<MenuItemsCollection>(jsonString);
        //        }
        //    }

        //    return output;
        //}

        //public static async Task<MenuCategoryCollection> TestGetMenuCategoryCollection_Async() //https://api.omnivore.io/0.1/locations/zGibgKT9/menu/categories/
        //{
        //    MenuCategoryCollection output = null;

        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://api.omnivore.io/");
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key

        //        string apiVersion = AppSettings.API_Version;
        //        string defaultLocationId = AppSettings.DefaultLocationId;
        //        HttpResponseMessage response = await client.GetAsync(String.Concat(apiVersion, "/locations/", defaultLocationId, "/", "menu", "/", "categories"));
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string jsonString = await response.Content.ReadAsStringAsync();
        //            output = JsonConvert.DeserializeObject<MenuCategoryCollection>(jsonString);
        //        }
        //    }

        //    return output;
        //}

        //public static async Task<ModifierCollection> TestGetMenuModifierCollection_Async() //https://api.omnivore.io/0.1/locations/zGibgKT9/menu/modifiers/
        //{
        //    ModifierCollection output = null;

        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://api.omnivore.io/");
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key

        //        string apiVersion = AppSettings.API_Version;
        //        string defaultLocationId = AppSettings.DefaultLocationId;
        //        HttpResponseMessage response = await client.GetAsync(String.Concat(apiVersion, "/locations/", defaultLocationId, "/", "menu", "/", "modifiers"));
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string jsonString = await response.Content.ReadAsStringAsync();
        //            output = JsonConvert.DeserializeObject<ModifierCollection>(jsonString);
        //        }
        //    }

        //    return output;
        //}
    }
}
