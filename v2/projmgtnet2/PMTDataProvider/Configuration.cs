using System;
using System.Configuration;

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
            get {   return ConfigurationSettings.AppSettings["ConnectionString"];   }
        }

        /// <summary>
        /// Gets the DataProvider name
        /// </summary>
        public static string DataProvider
        {
            get {   return ConfigurationSettings.AppSettings["DataProvider"];   }
        }
	}
}
