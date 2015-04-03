using System;
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
    public class PaymentThirdPartyDTO : PaymentBaseDTO
    {
        [JsonProperty("tender_type")]
        public string TenderType { get; set; }

        [JsonProperty("payment_source")]
        public string PaymentSource { get; set; }
    }
}
