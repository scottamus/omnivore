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
                    Link l = inner[k].ToObject<Link>();
                    l.Name = k;

                    output.Add(l);
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

                        // load links
                        output.Links = LoadLinks(menuTmp);
                    }
                }
            }

            return output;
        }

        public static async Task<Menu> TestGetMenuWithCategoriesAndItems_Async() //https://api.omnivore.io/0.1/locations/zGibgKT9/menu/categories/
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
                HttpResponseMessage response = await client.GetAsync(String.Concat(apiVersion, "/locations/", defaultLocationId, "/", "menu", "/", "categories"));
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    if (!String.IsNullOrEmpty(jsonString))
                    {
                        JObject menuTmp = JObject.Parse(jsonString);

                        JsonSerializer serializer = new JsonSerializer();
                        serializer.NullValueHandling = NullValueHandling.Ignore; // to skip setting null onto enums, especially

                        output = menuTmp.ToObject<Menu>(serializer);

                        // load links
                        output.Links = LoadLinks(menuTmp);

                        // load embedded categories and items
                        Category categoryTmp;
                        MenuItem menuItemTmp;
                        JToken menuToken = menuTmp["_embedded"];
                        JArray catArray = menuToken["categories"] as JArray;
                        foreach (JToken category in catArray)
                        {
                            // safety check
                            if (output.Categories == null)
                            {
                                output.Categories = new List<Category>();
                            }

                            categoryTmp = category.ToObject<Category>(serializer);
                            JObject tmpCatObj = JObject.Parse(category.ToString()); // need to convert JToken to JObject here, would like to improve this
                            categoryTmp.Links = LoadLinks(tmpCatObj);

                            // add items for this category -- TODO: make recursive method if possible, to avoid this
                            JToken catToken = tmpCatObj["_embedded"];
                            JArray itemArray = catToken["items"] as JArray;
                            foreach (JToken item in itemArray)
                            {
                                // safety check
                                if (categoryTmp.MenuItems == null)
                                {
                                    categoryTmp.MenuItems = new List<MenuItem>();
                                }

                                menuItemTmp = item.ToObject<MenuItem>(serializer);
                                JObject tmpItemObj = JObject.Parse(item.ToString()); // need to convert JToken to JObject here, would like to improve this
                                menuItemTmp.Links = LoadLinks(tmpItemObj);

                                // add to collection
                                categoryTmp.MenuItems.Add(menuItemTmp);
                            }

                            // add to collection
                            output.Categories.Add(categoryTmp);
                        }
                    }
                }
            }

            return output;
        }

        public static async Task<List<ModifierGroup>> TestGetMenuItemModifiers_Async() //https://api.omnivore.io/0.1/locations/zGibgKT9/menu/items/rMTAbTjr/modifier_groups/
        {
            List<ModifierGroup> output = null;

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
                        JObject modGrpCollectionTmp = JObject.Parse(jsonString);

                        JsonSerializer serializer = new JsonSerializer();
                        serializer.NullValueHandling = NullValueHandling.Ignore; // to skip setting null onto enums, especially

                        ModifierGroupCollection mgc = modGrpCollectionTmp.ToObject<ModifierGroupCollection>(serializer);

                        // load links
                        mgc.Links = LoadLinks(modGrpCollectionTmp);

                        // load embedded modifier groups and modifiers
                        // TODO: do a much better job parsing this so it isn't so manual
                        ModifierGroup modGrpTmp;
                        Modifier modifierTmp;
                        JToken modGrpCollectionToken = modGrpCollectionTmp["_embedded"];
                        JArray modGrpArray = modGrpCollectionToken["modifier_groups"] as JArray;
                        foreach (JToken modGrp in modGrpArray)
                        {
                            // safety check
                            if (output == null)
                            {
                                output = new List<ModifierGroup>();
                            }

                            modGrpTmp = modGrp.ToObject<ModifierGroup>(serializer);
                            JObject tmpModGrpObj = JObject.Parse(modGrp.ToString()); // need to convert JToken to JObject here, would like to improve this
                            modGrpTmp.Links = LoadLinks(tmpModGrpObj);

                            // add items for this category -- TODO: make recursive method if possible, to avoid this
                            JToken modGrpToken = tmpModGrpObj["_embedded"];
                            JArray modArray = modGrpToken["options"] as JArray;
                            foreach (JToken mod in modArray)
                            {
                                // safety check
                                if (modGrpTmp.Modifiers == null)
                                {
                                    modGrpTmp.Modifiers = new List<Modifier>();
                                }

                                modifierTmp = mod.ToObject<Modifier>(serializer);
                                JObject tmpItemObj = JObject.Parse(mod.ToString()); // need to convert JToken to JObject here, would like to improve this
                                modifierTmp.Links = LoadLinks(tmpItemObj);

                                // add to collection
                                modGrpTmp.Modifiers.Add(modifierTmp);
                            }

                            // add to collection
                            output.Add(modGrpTmp);
                        }
                    }
                }
            }

            return output;
        }
    }
}
