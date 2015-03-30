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
    public class Modifier : OmnivoreBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price_levels")]
        public List<PriceLevel> PriceLevels { get; set; }

        [JsonProperty("price_per_unit")]
        [JsonConverter(typeof(CurrencyConverter))]
        public decimal PricePerUnit { get; set; }
    }
}
