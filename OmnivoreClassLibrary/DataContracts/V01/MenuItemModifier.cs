using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using OmnivoreClassLibrary.JSONConverters;

namespace OmnivoreClassLibrary.DataContracts.V01
{
    public class MenuItemModifier : ModifierBase
    {
        [JsonProperty("price_levels")]
        public List<PriceLevel> PriceLevels { get; set; }
    }
}
