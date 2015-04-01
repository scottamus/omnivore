using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using OmnivoreClassLibrary.Helpers;
using OmnivoreClassLibrary.DataContracts.V01.Enums;

namespace OmnivoreClassLibrary.DataContracts.V01
{
    public class Discount : OmnivoreBase
    {
        [JsonProperty("applies_to")]
        public AppliesTo AppliesTo { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("max_value")]
        [JsonConverter(typeof(CurrencyConverter))]
        public decimal? MaxValue { get; set; }

        [JsonProperty("min_ticket_total")]
        [JsonConverter(typeof(CurrencyConverter))]
        public decimal MinTicketTotal { get; set; }

        [JsonProperty("min_value")]
        [JsonConverter(typeof(CurrencyConverter))]
        public decimal MinValue { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("open")]
        public bool Open { get; set; }

        [JsonProperty("type")]
        public DiscountType DiscountType { get; set; }

        [JsonProperty("value")]
        [JsonConverter(typeof(CurrencyConverter))]
        public decimal? Value { get; set; }
    }

}
