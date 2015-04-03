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
    public class TicketOpenDTO
    {
        public TicketOpenDTO(Ticket ticketToOpen)
        {
            // TODO: move this to a validation rule checker of some sort...
            if (ticketToOpen != null && ticketToOpen.EmbeddedTicketItems != null &&
                ticketToOpen.EmbeddedTicketItems.employee != null && !String.IsNullOrEmpty(ticketToOpen.EmbeddedTicketItems.employee.Id) && // required for open ticket POST call
                ticketToOpen.EmbeddedTicketItems.order_type != null && !String.IsNullOrEmpty(ticketToOpen.EmbeddedTicketItems.order_type.Id) && // required for open ticket POST call
                ticketToOpen.EmbeddedTicketItems.revenue_center != null && !String.IsNullOrEmpty(ticketToOpen.EmbeddedTicketItems.revenue_center.Id)) // required for open ticket POST call
            { // TODO: maybe move this part to a converter instead of this constructor?
                EmployeeId = ticketToOpen.EmbeddedTicketItems.employee.Id;
                OrderTypeId = ticketToOpen.EmbeddedTicketItems.order_type.Id;
                RevenueCenterId = ticketToOpen.EmbeddedTicketItems.revenue_center.Id;

                // optional items now
                if (ticketToOpen.EmbeddedTicketItems.table != null && !String.IsNullOrEmpty(ticketToOpen.EmbeddedTicketItems.table.Id)) // optional
                {
                    TableId = ticketToOpen.EmbeddedTicketItems.table.Id;
                }

                if (ticketToOpen.GuestCount.HasValue) // optional
                {
                    GuestCount = ticketToOpen.GuestCount.Value;
                }

                if (!String.IsNullOrEmpty(ticketToOpen.Name)) // optional
                {
                    Name = ticketToOpen.Name;
                }

                AutoSend = ticketToOpen.AutoSend; // optional - should default this to true?
            }
        }

        [JsonProperty("employee")]
        public string EmployeeId { get; set; }

        [JsonProperty("order_type")]
        public string OrderTypeId { get; set; }

        [JsonProperty("revenue_center")]
        public string RevenueCenterId { get; set; }

        [JsonProperty("table")]
        public string TableId { get; set; }

        [JsonProperty("guest_count")]
        public int GuestCount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("auto_send")]
        public bool AutoSend { get; set; }
    }
}
