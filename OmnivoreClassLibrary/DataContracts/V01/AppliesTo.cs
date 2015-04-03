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
    public class AppliesTo
    {
        [JsonProperty("item")]
        public bool Item { get; set; }

        [JsonProperty("ticket")]
        public bool Ticket { get; set; }
    }
}
