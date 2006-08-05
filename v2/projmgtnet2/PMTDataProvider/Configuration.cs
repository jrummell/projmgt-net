using System;
using System.Configuration;

namespace PMTDataProvider
{
	/// <summary>
	/// Summary description for Configuration.
	/// </summary>
	public class Configuration
	{
        // hide constructor
		private Configuration()	{}

        public static string ConnectionString
        {
            get {   return ConfigurationSettings.AppSettings["ConnectionString"];   }
        }

        public static string DataProvider
        {
            get {   return ConfigurationSettings.AppSettings["DataProvider"];   }
        }
	}
}
