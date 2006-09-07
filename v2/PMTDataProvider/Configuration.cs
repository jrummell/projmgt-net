using System;
using System.Configuration;
using System.Data;
using System.Xml;

namespace PMTDataProvider
{
	/// <summary>
	/// Provides Configuration Information
	/// </summary>
	public class Configuration
	{
        /// <summary>
        /// Hiding the constructor ...
        /// </summary>
		private Configuration()	{}

        /// <summary>
        /// Gets the Connection String
        /// </summary>
        public static string ConnectionString
        {
            get {   return GetConfigSetting("ConnectionString");    }
            set {   SetValue("ConnectionString", value);            }
        }

        /// <summary>
        /// Gets the DataProvider name
        /// </summary>
        public static string DataProvider
        {
            get {   return GetConfigSetting("DataProvider");   }
        }

        private static string GetConfigSetting(string setting)
        {
            return ConfigurationSettings.AppSettings[setting];
        }

        private static void SetValue(string key, string val)
        {
            string path = System.Web.HttpRuntime.AppDomainAppPath + "conn.xml";
            DataSet ds = new DataSet();

            ds.ReadXml(path);
            DataRow[] dr = ds.Tables["add"].Select(String.Format("key='{0}'", key));
            dr[0]["value"] = val;
            ds.WriteXml(path);
        }
	}
}
