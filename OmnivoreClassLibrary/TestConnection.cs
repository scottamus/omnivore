using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OmnivoreClassLibrary
{
    public static class TestConnection
    {
        public static async Task<Interface> TestGetInterface_Async() // root https://api.omnivore.io
        {
            Interface output = null;

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
                    output = JsonConvert.DeserializeObject<Interface>(jsonString);
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
                    JObject loc = JObject.Parse(jsonString);
                    JToken locToken = loc["_embedded"];
                    JArray locArray = locToken["locations"] as JArray;
                    output = locArray.ToObject<List<Location>>();
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
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key

                string apiVersion = AppSettings.API_Version;
                string defaultLocationId = AppSettings.DefaultLocationId;
                HttpResponseMessage response = await client.GetAsync(String.Concat(apiVersion, "/locations/", defaultLocationId, "/"));
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    JObject loc = JObject.Parse(jsonString);
                    output = loc.ToObject<Location>();
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

        public static async Task<MenuItemsCollection> TestGetMenuItemsCollection_Async() //https://api.omnivore.io/0.1/locations/zGibgKT9/menu/items/
        {
            MenuItemsCollection output = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.omnivore.io/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key

                string apiVersion = AppSettings.API_Version;
                string defaultLocationId = AppSettings.DefaultLocationId;
                HttpResponseMessage response = await client.GetAsync(String.Concat(apiVersion, "/locations/", defaultLocationId, "/", "menu", "/", "items"));
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    output = JsonConvert.DeserializeObject<MenuItemsCollection>(jsonString);
                }
            }

            return output;
        }

        public static async Task<MenuCategoryCollection> TestGetMenuCategoryCollection_Async() //https://api.omnivore.io/0.1/locations/zGibgKT9/menu/categories/
        {
            MenuCategoryCollection output = null;

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
                    output = JsonConvert.DeserializeObject<MenuCategoryCollection>(jsonString);
                }
            }

            return output;
        }

        public static async Task<ModifierCollection> TestGetMenuModifierCollection_Async() //https://api.omnivore.io/0.1/locations/zGibgKT9/menu/modifiers/
        {
            ModifierCollection output = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.omnivore.io/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key

                string apiVersion = AppSettings.API_Version;
                string defaultLocationId = AppSettings.DefaultLocationId;
                HttpResponseMessage response = await client.GetAsync(String.Concat(apiVersion, "/locations/", defaultLocationId, "/", "menu", "/", "modifiers"));
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    output = JsonConvert.DeserializeObject<ModifierCollection>(jsonString);
                }
            }

            return output;
        }
    }
}
