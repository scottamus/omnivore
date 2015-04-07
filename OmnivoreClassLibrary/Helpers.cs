using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using OmnivoreClassLibrary.DataContracts.V01;
using OmnivoreClassLibrary.DataContracts.V01.Enums;
using OmnivoreClassLibrary.DataAccess;
using OmnivoreClassLibrary.Interfaces;

namespace OmnivoreClassLibrary
{
    public static class Helpers
    {
        /// <summary>
        /// Deserializes the json string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="output">The output.</param>
        /// <param name="jsonString">The json string.</param>
        /// <returns></returns>
        public static T DeserializeJSONString<T>(string jsonString) where T : OmnivoreBase
        {
            if (!String.IsNullOrEmpty(jsonString))
            {
                JObject menuTmp = JObject.Parse(jsonString);

                JsonSerializer serializer = new JsonSerializer();
                serializer.NullValueHandling = NullValueHandling.Ignore; // to skip setting null onto enums

                return menuTmp.ToObject<T>(serializer);
            }
            return null; // fix later
        }
    }
}
