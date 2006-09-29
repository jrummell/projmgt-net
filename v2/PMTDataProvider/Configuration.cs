using System;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.Xml;
using System.Collections.Specialized;

namespace PMTDataProvider.Configuration
{
	/// <summary>
	/// Provides Configuration Information
	/// </summary>
	public class Config
	{
        private static string section = "pmtSettings/data";
        /// <summary>
        /// Hiding the constructor ...
        /// </summary>
		private Config() {}

        /// <summary>
        /// Gets or sets the Connection String
        /// </summary>
        public static string ConnectionString
        {
            get {   return WebConfigurationManager.ConnectionStrings["default"].ConnectionString; }
            set {   WebConfigurationManager.ConnectionStrings["default"].ConnectionString = value; }
        }

        /// <summary>
        /// Gets the DataProvider name
        /// </summary>
        public static string DataProvider
        {
            get { return Settings["DataProvider"]; }
        }

        /// <summary>
        /// Gets the cached configuration settings.  
        /// </summary>
        /// <remarks>
        /// If the cached object is null it re-inserts it.
        /// Cache expires 30 minutes after last access.
        /// </remarks>
        private static NameValueCollection Settings
        {
            get
            {
                NameValueCollection settings = System.Web.HttpContext.Current.Cache[section] as NameValueCollection;
                if (settings == null)
                {
                    settings = WebConfigurationManager.GetSection(section) as NameValueCollection;
                    System.Web.HttpContext.Current.Cache.Insert(
                        section, settings, null, 
                        System.Web.Caching.Cache.NoAbsoluteExpiration, 
                        new TimeSpan(0, 30, 0));
                }
                return settings;
            }
        }
	}
}
