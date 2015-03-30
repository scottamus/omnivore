using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using OmnivoreClassLibrary.Helpers;

namespace OmnivoreClassLibrary.DataContracts.V01
{
    public class PriceLevel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("price")]
        [JsonConverter(typeof(CurrencyConverter))]
        public decimal Price { get; set; }
    }
}
