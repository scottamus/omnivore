using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmnivoreClassLibrary.DataContracts.V01.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using OmnivoreClassLibrary.Helpers;

namespace OmnivoreClassLibrary.DataContracts.V01
{
    public class Version // (https://api.omnivore.io/0.1)
    {
        [JsonProperty("deprecation_date")]
        public DateTime DeprecationDate { get; set; }

        [JsonProperty("href")]
        public string URL { get; set; }

        [JsonProperty("major")]
        public int MajorVersion { get; set; }

        [JsonProperty("minor")]
        public int MinorVersion { get; set; }

        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty("retirement_date")]
        public DateTime RetirementDate { get; set; }

        [JsonProperty("status")]
        public ApiVersionStatus ApiVersionStatus { get; set; }
    }
}
