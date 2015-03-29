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
        public static async Task TestGetLocation_Async()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.omnivore.io/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Api-Key", "f9abdb5c43bf4d9b9ae06fb1cedd2f81"); // add api key

                // New code:
                HttpResponseMessage response = await client.GetAsync("0.1/locations/zGibgKT9/"); // TODO: split this out, combine once I have a class for version, location, etc.  set default location id (from config??)
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
    }
}
