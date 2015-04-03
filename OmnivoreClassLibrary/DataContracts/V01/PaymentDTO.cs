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
    public class PaymentDTO : PaymentBaseDTO
    {
        // todo: need validation for valid entries in dictionary before creating DTO
        [JsonProperty("card_info")]
        public Dictionary<string, object> CardInfo { get; set; }
    }
}
