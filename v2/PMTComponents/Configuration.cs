using System;
using System.Web;
using System.Web.Configuration;
using System.Collections.Specialized;

namespace PMTComponents
{
    /// <summary>
    /// A base configuration class that can read cached settings from the web.config.
    /// </summary>
    public abstract class ConfigBase
    {
        private static object lockObj;

        static ConfigBase()
        {
            lockObj = new Object();
        }

        protected ConfigBase() { }

        /// <summary>
        /// Gets the cached configuration settings.  
        /// </summary>
        /// <remarks>
        /// If the cached object is null it re-inserts it.
        /// Cache expires 30 minutes after last access.
        /// </remarks>
        protected static NameValueCollection GetSettings(string section)
        {
            NameValueCollection settings = (NameValueCollection)System.Web.HttpContext.Current.Cache[section];
            if (settings == null)
            {
                lock (lockObj)
                {
                    settings = (NameValueCollection)WebConfigurationManager.GetSection(section);
                    System.Web.HttpContext.Current.Cache.Insert(
                        section, settings, null,
                        System.Web.Caching.Cache.NoAbsoluteExpiration,
                        new TimeSpan(0, 30, 0));
                }
            }
            return settings;
        }
    }
}
