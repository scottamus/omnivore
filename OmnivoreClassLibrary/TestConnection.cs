using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using OmnivoreClassLibrary.DataContracts.V01;
using OmnivoreClassLibrary.DataContracts.V01.Enums;
using OmnivoreClassLibrary.DataAccess;
using OmnivoreClassLibrary.BusinessDomain;

namespace OmnivoreClassLibrary
{
    public static class TestConnection
    {
        

        public static async Task<Ticket> TestOpenTicket(Ticket ticket)
        {
            // convert to DTO
            TicketOpenDTO ticketToCreate = new TicketOpenDTO(ticket); // todo: generic converter?

            // make the call and return
            OmnivoreDataManager mgr = new OmnivoreDataManager();
            return await mgr.PostOmnivoreObject<TicketOpenDTO, Ticket>(URLBuilder.DefaultLocationOpenTicketUrl, ticketToCreate);
        }

        public static async Task<Ticket> AddTicketItems(string ticketId, List<TicketItem> ticketItemsToAdd)
        {
            //sanity check
            if (!String.IsNullOrEmpty(ticketId) && ticketItemsToAdd != null && ticketItemsToAdd.Count > 0)
            {
                // convert to DTO
                List<TicketItemOpenDTO> ticketItemDTOs = new List<TicketItemOpenDTO>();
                foreach (TicketItem item in ticketItemsToAdd)
                {
                    ticketItemDTOs.Add(new TicketItemOpenDTO(item));
                }

                // make the call and return
                OmnivoreDataManager mgr = new OmnivoreDataManager();
                return await mgr.PostOmnivoreObject<List<TicketItemOpenDTO>, Ticket>(URLBuilder.DefaultLocationOpenTicketUrl, ticketItemDTOs);
            }

            return null; // todo: fix this later
        }

        public static async Task<PaymentStatus> MakePayment(string url, PaymentDTO payment)
        {
            // make the call and return
            OmnivoreDataManager mgr = new OmnivoreDataManager();
            return await mgr.PostOmnivoreObject<PaymentDTO, PaymentStatus>(URLBuilder.DefaultLocationOpenTicketUrl, payment);
        }

        public static async Task<PaymentStatus> MakePaymentThirdParty(string url, PaymentThirdPartyDTO payment)
        {
            // make the call and return
            OmnivoreDataManager mgr = new OmnivoreDataManager();
            return await mgr.PostOmnivoreObject<PaymentThirdPartyDTO, PaymentStatus>(URLBuilder.DefaultLocationOpenTicketUrl, payment);
        }
    }
}
