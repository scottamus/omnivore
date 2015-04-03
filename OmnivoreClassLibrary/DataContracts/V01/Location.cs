using OmnivoreClassLibrary.DataContracts.V01.Enums;
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
    /// <summary>
    /// Location class
    /// NOTE: Because of how it was versioned, I toyed with the idea of creating a set of classes which were 
    /// for talking to JSON only, and a set of classes which were for the client app developer to use.  
    /// Then they would each be able to convert to and from the one set of client app dev classes, so it would 
    /// be more seamless to the client app developer.  But the class structures wound up being largely identical,
    /// so I decided against that.  
    /// The whole point of publishing a new version would be to add some new functionality and/or data, which would 
    /// necessitate new objects and/or properties, and the client app dev would WANT those in the new version, 
    /// so the client app dev classes would need to be versioned as well, and then we're back in the same boat of 
    /// it not making sense because they are largely identical.
    /// </summary>
    public class Location : OmnivoreBase
    {
        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreatedDateTime { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("modified")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime ModifiedDateTime { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string PhoneNumber { get; set; } // could get fancier here - parse into area code, number, and add extension, etc., but leaving for now due to time

        [JsonProperty("status")]
        public LocationStatus LocationStatus { get; set; }

        [JsonProperty("website")]
        public string WebsiteURL { get; set; }
    }
}
