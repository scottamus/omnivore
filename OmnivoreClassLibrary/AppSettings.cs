using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace OmnivoreClassLibrary
{
    public static class AppSettings
    {
        /// <summary>
        /// Gets the API version.
        /// </summary>
        /// <value>
        /// The ap i_ version.
        /// </value>
        public static string API_Version
        {
            get { return ConfigurationManager.AppSettings["API_Version"]; }
        }

        /// <summary>
        /// Gets the API key.
        /// </summary>
        /// <value>
        /// The ap i_ key.
        /// </value>
        public static string API_Key
        {
            get { return ConfigurationManager.AppSettings["API_Key"]; }
        }

        /// <summary>
        /// Gets the default location identifier.
        /// </summary>
        /// <value>
        /// The default location identifier.
        /// </value>
        public static string DefaultLocationId
        {
            get { return ConfigurationManager.AppSettings["DefaultLocationId"]; }
        }

        /// <summary>
        /// Gets the root address.
        /// </summary>
        /// <value>
        /// The root address.
        /// </value>
        public static string RootAddress
        {
            get { return ConfigurationManager.AppSettings["RootAddress"]; }
        }
    }
}
