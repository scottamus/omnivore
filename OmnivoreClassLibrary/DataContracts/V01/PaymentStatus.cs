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
    public class PaymentStatus : OmnivoreBase
    {
        [JsonProperty("amount_paid")]
        [JsonConverter(typeof(CurrencyConverter))]
        public decimal AmountPaid { get; set; }

        [JsonProperty("accepted")]
        public bool Accepted { get; set; }

        [JsonProperty("ticket_closed")]
        public bool TicketClosed { get; set; }

        [JsonProperty("balance_remaining")]
        [JsonConverter(typeof(CurrencyConverter))]
        public decimal BalanceRemaining { get; set; }

        [JsonProperty("ticket")]
        public Ticket Ticket { get; set; }
    }
}
