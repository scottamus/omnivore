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
    public class Link
    {
        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("href")]
        public string URL { get; set; }

        [JsonProperty("profile")]
        public string Profile { get; set; }
    }
}
