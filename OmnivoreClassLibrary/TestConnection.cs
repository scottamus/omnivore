﻿using System;
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

        public static async Task<ModifierGroupCollection> TestGetMenuItemModifierGroupCollection_Async() //https://api.omnivore.io/0.1/locations/zGibgKT9/menu/items/rMTAbTjr/modifier_groups/
        {
            ModifierGroupCollection output = null;

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

                        output = menuTmp.ToObject<ModifierGroupCollection>(serializer);
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
    }
}
