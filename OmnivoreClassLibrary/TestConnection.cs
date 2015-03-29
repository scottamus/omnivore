using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace OmnivoreClassLibrary
{
    public static class TestConnection
    {
        public static async Task TestGetLocation_Async() //https://api.omnivore.io/0.1/locations/zGibgKT9/
        {
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
                    string locationString = await response.Content.ReadAsStringAsync();
                    Location loc = JsonConvert.DeserializeObject<Location>(locationString);

                    Console.WriteLine(String.Format("Location Id: {0}", loc.id));
                    Console.WriteLine(String.Format("Location Name: {0}", loc.name));
                    Console.WriteLine(String.Format("Location Display Name: {0}", loc.display_name));
                    Console.WriteLine(String.Format("Location phone: {0}", loc.phone));
                    Console.WriteLine(String.Format("Location status: {0}", loc.status));
                    Console.WriteLine(String.Format("Location website: {0}", loc.website));
                    Console.WriteLine(String.Format("Location created: {0}", loc.created));
                    Console.WriteLine(String.Format("Location modified: {0}", loc.modified));
                }
            }
        }

        public static async Task TestGetInterface_Async() // root https://api.omnivore.io
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.omnivore.io/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key

                HttpResponseMessage response = await client.GetAsync(String.Empty);
                if (response.IsSuccessStatusCode)
                {
                    string locationString = await response.Content.ReadAsStringAsync();
                    Interface inter = JsonConvert.DeserializeObject<Interface>(locationString);

                    foreach (Version ver in inter.versions)
                    {
                        Console.WriteLine(ver.minor);
                    }
                }
            }
        }
    }
}
