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
        public static string API_Version
        {
            get { return ConfigurationManager.AppSettings["API_Version"]; }
        }

        public static string API_Key
        {
            get { return ConfigurationManager.AppSettings["API_Key"]; }
        }

        public static string DefaultLocationId
        {
            get { return ConfigurationManager.AppSettings["DefaultLocationId"]; }
        }

        public static string RootAddress
        {
            get { return ConfigurationManager.AppSettings["RootAddress"]; }
        }
    }
}
