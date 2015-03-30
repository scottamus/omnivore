using OmnivoreClassLibrary.DataContracts.V01.Enums;
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
    public class Address
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public State State { get; set; }

        [JsonProperty("street1")]
        public string StreetLine1 { get; set; }

        [JsonProperty("street2")]
        public string StreetLine2 { get; set; }

        [JsonProperty("zip")]
        public string ZipCode { get; set; }
    }
}
