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
    public class Employee : OmnivoreBase
    {
        [JsonProperty("check_name")]
        public string CheckName { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }
    }
}
