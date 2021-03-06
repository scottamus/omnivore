﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using OmnivoreClassLibrary.JSONConverters;
using OmnivoreClassLibrary.DataContracts.V01.Enums;

namespace OmnivoreClassLibrary.DataContracts.V01
{
    public abstract class PaymentBaseDTO
    {
        [JsonProperty("type")]
        public string PaymentType { get; set; }

        [JsonProperty("amount")]
        [JsonConverter(typeof(CurrencyConverter))]
        public decimal Amount { get; set; }

        [JsonProperty("tip")]
        [JsonConverter(typeof(CurrencyConverter))]
        public decimal Tip { get; set; }
    }
}
