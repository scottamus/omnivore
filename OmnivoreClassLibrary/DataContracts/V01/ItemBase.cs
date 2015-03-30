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
    public abstract class ItemBase : OmnivoreBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("in_stock")]
        public bool InStock { get; set; }

        [JsonProperty("modifier_groups_count")]
        public int ModifierGroupsCount { get; set; } // necessary?  guess I'll find out

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        [JsonConverter(typeof(CurrencyConverter))]
        public decimal Price { get; set; }

        [JsonProperty("price_levels")]
        public List<PriceLevel> PriceLevels { get; set; }
    }
}
