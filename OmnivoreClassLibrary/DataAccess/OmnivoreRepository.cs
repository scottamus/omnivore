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
        /// <summary>
        /// Gets the omnivore object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public virtual async Task<T> GetOmnivoreObject<T>(string url)
            where T : OmnivoreBase
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
                    if (response.IsSuccessStatusCode) // todo: handle other error codes - create Response Handler class?
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();

                        output = Helpers.DeserializeJSONString<T>(jsonString);
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

        /// <summary>
        /// Posts the omnivore object.
        /// </summary>
        /// <typeparam name="T">The item to be added/posted.  Should already be converted to a DTO if necessary.</typeparam>
        /// <typeparam name="U">The return type.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="itemToPost">The item to post.</param>
        /// <returns></returns>
        public virtual async Task<U> PostOmnivoreObject<T, U>(string url, T itemToPost) 
            where U : OmnivoreBase
        {
            U output = null;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Api-Key", AppSettings.API_Key); // add api key

                string apiVersion = AppSettings.API_Version;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                string json = JsonConvert.SerializeObject(itemToPost, settings);
                StringContent stringContent = new StringContent(json);
                HttpResponseMessage response = await client.PostAsync(url, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    output = Helpers.DeserializeJSONString<U>(jsonString);
                }
            }

            return output;
        }
    }
}
