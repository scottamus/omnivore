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
    public class ModifierGroup : OmnivoreBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("maximum")]
        public int? MaxAllowed { get; set; }

        [JsonProperty("minimum")]
        public int MinAllowed { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("_embedded")]
        public Dictionary<string, List<Modifier>> Modifiers { get; set; }
    }
}
