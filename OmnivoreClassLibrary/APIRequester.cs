using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OmnivoreClassLibrary
{
    public static class APIRequester
    {
        public static async Task<HttpResponseMessage> MakeAPIGETRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key
                return await client.GetAsync(url);
            }
        }
    }
}
