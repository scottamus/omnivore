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
    public class TicketItem : OmnivoreBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price_per_unit")]
        [JsonConverter(typeof(CurrencyConverter))]
        public decimal PricePerUnit { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("sent")]
        public bool Sent { get; set; }

        [JsonProperty("_embedded")]
        public EmbeddedTicketItemSubclasses EmbeddedTicketItemSubclasses { get; set; }
    }

    public class EmbeddedTicketItemSubclasses
    {
        public List<Discount> discounts { get; set; }
        public MenuItem menu_item { get; set; }
        public List<TicketItemModifier> modifiers { get; set; }
    }
}
