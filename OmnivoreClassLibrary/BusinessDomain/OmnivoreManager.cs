using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using OmnivoreClassLibrary.DataContracts.V01;
using OmnivoreClassLibrary.DataContracts.V01.Enums;
using OmnivoreClassLibrary.DataAccess;
using OmnivoreClassLibrary.Interfaces;

namespace OmnivoreClassLibrary.BusinessDomain
{
    public class OmnivoreManager
    {
        private OmnivoreDataManager _dataMgr;

        /// <summary>
        /// Initializes a new instance of the <see cref="OmnivoreDataManager"/> class.
        /// Note, this one uses a real OmnivoreRepository behind the scenes, to make it
        /// easier on the client application.
        /// </summary>
        public OmnivoreManager() 
            : this(new OmnivoreDataManager())
        {
            // use the real one by default.  
            // I might refactor later to use IoC with Unity, but I'm not sure how bootstrapping Únity works in a 
            // class library, as opposed to a web site or console app, so Im leaving that alone for now and will revisit if I have time.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OmnivoreDataManager"/> class.
        /// This allows other assemblies/classes to inject dependencies as needed.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public OmnivoreManager(OmnivoreDataManager dataManager)
        {
            this._dataMgr = dataManager;
        }

        // GETs

        /// <summary>
        /// Gets the main interface_ asynchronous.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public async Task<MainInterface> GetMainInterface_Async(string url)
        {
            return await this._dataMgr.GetOmnivoreObject<MainInterface>(url);
        }

        /// <summary>
        /// Gets the location collection_ asynchronous.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public async Task<OmnivoreCollection<Location>> GetLocationCollection_Async(string url)
        {
            return await this._dataMgr.GetOmnivoreObject<OmnivoreCollection<Location>>(url);
        }

        /// <summary>
        /// Gets the location_ asynchronous.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public async Task<Location> GetLocation_Async(string url)
        {
            return await this._dataMgr.GetOmnivoreObject<Location>(url);
        }

        /// <summary>
        /// Gets the menu_ asynchronous.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public async Task<Menu> GetMenu_Async(string url)
        {
            return await this._dataMgr.GetOmnivoreObject<Menu>(url);
        }

        /// <summary>
        /// Gets the menu categories and items_ asynchronous.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public async Task<OmnivoreCollection<Category>> GetMenuCategoriesAndItems_Async(string url)
        {
            return await this._dataMgr.GetOmnivoreObject<OmnivoreCollection<Category>>(url);
        }

        /// <summary>
        /// Gets the menu item modifier group collection_ asynchronous.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public async Task<OmnivoreCollection<MenuItemModifierGroup>> GetMenuItemModifierGroupCollection_Async(string url)
        {
            return await this._dataMgr.GetOmnivoreObject<OmnivoreCollection<MenuItemModifierGroup>>(url);
        }

        /// <summary>
        /// Gets the table collection_ asynchronous.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public async Task<OmnivoreCollection<Table>> GetTableCollection_Async(string url)
        {
            return await this._dataMgr.GetOmnivoreObject<OmnivoreCollection<Table>>(url);
        }

        /// <summary>
        /// Gets the revenue center collection_ asynchronous.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public async Task<OmnivoreCollection<RevenueCenter>> GetRevenueCenterCollection_Async(string url)
        {
            return await this._dataMgr.GetOmnivoreObject<OmnivoreCollection<RevenueCenter>>(url);
        }

        /// <summary>
        /// Gets the order type collection_ asynchronous.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public async Task<OmnivoreCollection<OrderType>> GetOrderTypeCollection_Async(string url)
        {
            return await this._dataMgr.GetOmnivoreObject<OmnivoreCollection<OrderType>>(url);
        }

        /// <summary>
        /// Gets the employee collection_ asynchronous.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public async Task<OmnivoreCollection<Employee>> GetEmployeeCollection_Async(string url)
        {
            return await this._dataMgr.GetOmnivoreObject<OmnivoreCollection<Employee>>(url);
        }

        /// <summary>
        /// Gets the tender type collection_ asynchronous.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public async Task<OmnivoreCollection<TenderType>> GetTenderTypeCollection_Async(string url)
        {
            return await this._dataMgr.GetOmnivoreObject<OmnivoreCollection<TenderType>>(url);
        }

        /// <summary>
        /// Gets the ticket.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public async Task<Ticket> GetTicket(string url)
        {
            return await this._dataMgr.GetOmnivoreObject<Ticket>(url);
        }

        // POSTs

        /// <summary>
        /// Opens the ticket.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <returns></returns>
        public async Task<Ticket> OpenTicket(Ticket ticket)
        {
            // convert to DTO
            TicketOpenDTO ticketToCreate = new TicketOpenDTO(ticket); // todo: generic converter?

            // make the call and return
            return await this._dataMgr.PostOmnivoreObject<TicketOpenDTO, Ticket>(URLBuilder.DefaultLocationOpenTicketUrl, ticketToCreate);
        }

        /// <summary>
        /// Adds the ticket items.
        /// </summary>
        /// <param name="ticketId">The ticket identifier.</param>
        /// <param name="ticketItemsToAdd">The ticket items to add.</param>
        /// <returns></returns>
        public async Task<Ticket> AddTicketItems(string ticketId, List<TicketItem> ticketItemsToAdd)
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
                return await this._dataMgr.PostOmnivoreObject<List<TicketItemOpenDTO>, Ticket>(URLBuilder.DefaultLocationAddTicketItemsUrl(ticketId), ticketItemDTOs);
            }

            return null; // todo: fix this later
        }

        /// <summary>
        /// Makes the payment.
        /// Does not cover third party payments.
        /// </summary>
        /// <param name="ticketId">The ticket identifier.</param>
        /// <param name="payment">The payment.</param>
        /// <returns></returns>
        public async Task<PaymentStatus> MakePayment(string ticketId, PaymentDTO payment)
        {
            // make the call and return
            return await this._dataMgr.PostOmnivoreObject<PaymentDTO, PaymentStatus>(URLBuilder.DefaultLocationMakePaymentUrl(ticketId), payment);
        }

        /// <summary>
        /// Makes the third party payment.
        /// </summary>
        /// <param name="ticketId">The ticket identifier.</param>
        /// <param name="payment">The payment.</param>
        /// <returns></returns>
        public async Task<PaymentStatus> MakePaymentThirdParty(string ticketId, PaymentThirdPartyDTO payment)
        {
            // make the call and return
            return await this._dataMgr.PostOmnivoreObject<PaymentThirdPartyDTO, PaymentStatus>(URLBuilder.DefaultLocationMakePaymentUrl(ticketId), payment);
        }
    }
}
