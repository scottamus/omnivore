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
    public class Totals
    {
        [JsonProperty("due")]
        [JsonConverter(typeof(CurrencyConverter))]
        public decimal Due { get; set; }

        [JsonProperty("other_charges")]
        [JsonConverter(typeof(CurrencyConverter))]
        public decimal OtherCharges { get; set; }

        [JsonProperty("service_charges")]
        [JsonConverter(typeof(CurrencyConverter))]
        public decimal ServiceCharges { get; set; }

        [JsonProperty("sub_total")]
        [JsonConverter(typeof(CurrencyConverter))]
        public decimal SubTotal { get; set; }

        [JsonProperty("tax")]
        [JsonConverter(typeof(CurrencyConverter))]
        public decimal Tax { get; set; }

        [JsonProperty("total")]
        [JsonConverter(typeof(CurrencyConverter))]
        public decimal Total { get; set; }
    }

}
