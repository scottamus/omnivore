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
using OmnivoreClassLibrary.Interfaces;

namespace OmnivoreClassLibrary.DataAccess
{
    public class OmnivoreRepository : IOmnivoreRepository
    {
        public async Task<T> GetOmnivoreCollection<T>(string url)
            where T : OmnivoreCollectionBase
        {
            T output = null;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key from config

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode) // todo: handle other error codes
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();

                        if (!String.IsNullOrEmpty(jsonString))
                        {
                            JObject menuTmp = JObject.Parse(jsonString);

                            JsonSerializer serializer = new JsonSerializer();
                            serializer.NullValueHandling = NullValueHandling.Ignore; // to skip setting null onto enums

                            output = menuTmp.ToObject<T>(serializer);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // todo: want to do some logging here, but don't have time right now

                throw; //
            }

            return output;
        }
    }
}
