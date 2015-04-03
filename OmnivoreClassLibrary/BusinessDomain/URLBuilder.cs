using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmnivoreClassLibrary.BusinessDomain
{
    /// <summary>
    /// For constructing URLs we need
    /// </summary>
    public static class URLBuilder
    {
        // todo: do I put these in config?  What if they change?  This seems sucky...why are they giving me links, and shouldn't I use those??
        private const string _slash = "/";
        private const string _locations = "locations";
        private const string _menu = "menu";
        private const string _tickets = "tickets";

        // GETS

        /// <summary>
        /// Gets the base URL.
        /// This lives in the config so the client can easily point to a new root easily if needed.
        /// </summary>
        /// <value>
        /// The base URL.
        /// </value>
        public static string BaseUrl 
        { 
            get 
            {
                return AppSettings.RootAddress;
            }
        }

        /// <summary>
        /// Gets the version URL.
        /// Version also lives in the config so the client can update.
        /// </summary>
        /// <value>
        /// The version URL.
        /// </value>
        public static string VersionUrl
        {
            get
            {
                string apiVersion = AppSettings.API_Version;
                return String.Concat(BaseUrl, _slash, apiVersion);
            }
        }

        /// <summary>
        /// Gets the locations URL.
        /// </summary>
        /// <value>
        /// The locations URL.
        /// </value>
        public static string LocationsUrl
        {
            get
            {
                string apiVersion = AppSettings.API_Version;
                return String.Concat(BaseUrl, _slash, apiVersion, _slash, _locations);
            }
        }

        /// <summary>
        /// Gets the default location URL.
        /// Default location is stored in config, so a restaurant could configure iPads or something to 
        /// ONLY look at this location, and bypass the location selection part, if it's for devices on tables
        /// meant for ordering...
        /// </summary>
        /// <value>
        /// The default location URL.
        /// </value>
        public static string DefaultLocationUrl
        {
            get
            {
                string apiVersion = AppSettings.API_Version;
                string defaultLocationId = AppSettings.DefaultLocationId;
                return String.Concat(BaseUrl, _slash, apiVersion, _slash, _locations, _slash, defaultLocationId);
            }
        }

        /// <summary>
        /// Gets the URL for specified location.
        /// </summary>
        /// <param name="locationId">The location identifier.</param>
        /// <returns></returns>
        public static string LocationUrl(string locationId)
        {
            string apiVersion = AppSettings.API_Version;
            return String.Concat(BaseUrl, _slash, apiVersion, _slash, _locations, _slash, locationId);
        }

        /// <summary>
        /// Gets the default location menu URL.
        /// </summary>
        /// <value>
        /// The default location menu URL.
        /// </value>
        public static string DefaultLocationMenuUrl
        {
            get
            {
                string apiVersion = AppSettings.API_Version;
                string defaultLocationId = AppSettings.DefaultLocationId;
                return String.Concat(BaseUrl, _slash, apiVersion, _slash, _locations, _slash, defaultLocationId, _slash, _menu);
            }
        }

        /// <summary>
        /// Gets the menu URL for the specified location.
        /// </summary>
        /// <param name="locationId">The location identifier.</param>
        /// <returns></returns>
        public static string LocationMenuUrl(string locationId)
        {
            string apiVersion = AppSettings.API_Version;
            return String.Concat(BaseUrl, _slash, apiVersion, _slash, _locations, _slash, locationId, _slash, _menu);
        }

        /// <summary>
        /// Gets the default location tables URL.
        /// </summary>
        /// <value>
        /// The default location tables URL.
        /// </value>
        public static string DefaultLocationTablesUrl // todo: need parameterized version for non-default location later...
        {
            get
            {
                string apiVersion = AppSettings.API_Version;
                string defaultLocationId = AppSettings.DefaultLocationId;
                return String.Concat(BaseUrl, _slash, apiVersion, _slash, _locations, _slash, defaultLocationId, _slash, "tables");
            }
        }

        /// <summary>
        /// Gets the default location revenue centers URL.
        /// </summary>
        /// <value>
        /// The default location revenue centers URL.
        /// </value>
        public static string DefaultLocationRevenueCentersUrl // todo: need parameterized version for non-default location later...
        {
            get
            {
                string apiVersion = AppSettings.API_Version;
                string defaultLocationId = AppSettings.DefaultLocationId;
                return String.Concat(BaseUrl, _slash, apiVersion, _slash, _locations, _slash, defaultLocationId, _slash, "revenue_centers");
            }
        }

        /// <summary>
        /// Gets the default location order types URL.
        /// </summary>
        /// <value>
        /// The default location order types URL.
        /// </value>
        public static string DefaultLocationOrderTypesUrl // todo: need parameterized version for non-default location later...
        {
            get
            {
                string apiVersion = AppSettings.API_Version;
                string defaultLocationId = AppSettings.DefaultLocationId;
                return String.Concat(BaseUrl, _slash, apiVersion, _slash, _locations, _slash, defaultLocationId, _slash, "order_types");
            }
        }

        /// <summary>
        /// Gets the default location employees URL.
        /// </summary>
        /// <value>
        /// The default location employees URL.
        /// </value>
        public static string DefaultLocationEmployeesUrl // todo: need parameterized version for non-default location later...
        {
            get
            {
                string apiVersion = AppSettings.API_Version;
                string defaultLocationId = AppSettings.DefaultLocationId;
                return String.Concat(BaseUrl, _slash, apiVersion, _slash, _locations, _slash, defaultLocationId, _slash, "employees");
            }
        }

        /// <summary>
        /// Gets the default location tender types URL.
        /// </summary>
        /// <value>
        /// The default location tender types URL.
        /// </value>
        public static string DefaultLocationTenderTypesUrl // todo: need parameterized version for non-default location later...
        {
            get
            {
                string apiVersion = AppSettings.API_Version;
                string defaultLocationId = AppSettings.DefaultLocationId;
                return String.Concat(BaseUrl, _slash, apiVersion, _slash, _locations, _slash, defaultLocationId, _slash, "tender_types");
            }
        }

        /// <summary>
        /// Gets the ticket URL for the default location
        /// </summary>
        /// <param name="ticketId">The ticket identifier.</param>
        /// <returns></returns>
        public static string DefaultLocationTicketUrl(string ticketId) // todo: need parameterized version for non-default location later...
        {
            string apiVersion = AppSettings.API_Version;
            string defaultLocationId = AppSettings.DefaultLocationId;
            return String.Concat(BaseUrl, _slash, apiVersion, _slash, _locations, _slash, defaultLocationId, _slash, _tickets, _slash, ticketId);
        }

        /// <summary>
        /// Gets the default location menu categories URL.
        /// </summary>
        /// <value>
        /// The default location menu categories URL.
        /// </value>
        public static string DefaultLocationMenuCategoriesUrl // todo: need parameterized version for non-default location later...
        {
            get
            {
                string apiVersion = AppSettings.API_Version;
                string defaultLocationId = AppSettings.DefaultLocationId;
                return String.Concat(BaseUrl, _slash, apiVersion, _slash, _locations, _slash, defaultLocationId, _slash, _menu, _slash, "categories");
            }
        }

        /// <summary>
        /// Gets the location menu item modifier groups URL.
        /// </summary>
        /// <param name="menuItemId">The menu item identifier.</param>
        /// <returns></returns>
        public static string DefaultLocationMenuItemModifierGroupsUrl(string menuItemId) // todo: need parameterized version for non-default location later...
        {
            string apiVersion = AppSettings.API_Version;
            string defaultLocationId = AppSettings.DefaultLocationId;
            return String.Concat(BaseUrl, _slash, apiVersion, _slash, _locations, _slash, defaultLocationId, _slash, _menu, _slash, "items", _slash, menuItemId, _slash, "modifier_groups");
        }

        // POSTS

        /// <summary>
        /// Gets the default location open ticket URL.
        /// </summary>
        /// <value>
        /// The default location open ticket URL.
        /// </value>
        public static string DefaultLocationOpenTicketUrl // todo: need parameterized version for non-default location later...
        {
            get
            {
                string apiVersion = AppSettings.API_Version;
                string defaultLocationId = AppSettings.DefaultLocationId;
                return String.Concat(BaseUrl, _slash, apiVersion, _slash, _locations, _slash, defaultLocationId, _slash, _tickets);
            }
        }

        /// <summary>
        /// Gets the default location add ticket items URL.
        /// </summary>
        /// <param name="ticketId">The ticket identifier.</param>
        /// <returns></returns>
        public static string DefaultLocationAddTicketItemsUrl(string ticketId) // todo: need parameterized version for non-default location later...
        {
            string apiVersion = AppSettings.API_Version;
            string defaultLocationId = AppSettings.DefaultLocationId;
            return String.Concat(BaseUrl, _slash, apiVersion, _slash, _locations, _slash, defaultLocationId, _slash, _tickets, _slash, ticketId, _slash, "items");
        }

        /// <summary>
        /// Defaults the location make payment URL.
        /// </summary>
        /// <param name="ticketId">The ticket identifier.</param>
        /// <returns></returns>
        public static string DefaultLocationMakePaymentUrl(string ticketId) // todo: need parameterized version for non-default location later...
        {
            string apiVersion = AppSettings.API_Version;
            string defaultLocationId = AppSettings.DefaultLocationId;
            return String.Concat(BaseUrl, _slash, apiVersion, _slash, _locations, _slash, defaultLocationId, _slash, _tickets, _slash, ticketId, _slash, "payments");
        }
    }
}
