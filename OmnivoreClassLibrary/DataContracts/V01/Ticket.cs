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
    public class Ticket : OmnivoreBase
    {
        //public Embedded2 _embedded { get; set; }

        [JsonProperty("auto_send")]
        public bool AutoSend { get; set; }

        [JsonProperty("closed_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime ClosedAt { get; set; }

        [JsonProperty("guest_count")]
        public int GuestCount { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("open")]
        public bool Open { get; set; }

        [JsonProperty("opened_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime OpenedAt { get; set; }

        [JsonProperty("ticket_number")]
        public int TicketNumber { get; set; }

        [JsonProperty("totals")]
        public Totals Totals { get; set; }

        [JsonProperty("@void")]
        public bool Void { get; set; }
    }

}
