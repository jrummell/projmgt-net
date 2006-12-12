using System;
using System.Web.Configuration;
using System.Collections.Specialized;

namespace PMTDataProvider.Configuration
{
    /// <summary>
    /// Databases that are (will) be supported.
    /// </summary>
    public enum DatabaseType { MySql, SqlServer }

	/// <summary>
	/// Provides Configuration Information
	/// </summary>
    public class Config : PMTComponents.ConfigBase
	{
        protected static string section = "pmtSettings/pmtDataProvider";

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
        public static Type DataProvider
        {
            //get { return Settings["DataProvider"]; }
            get
            {
                switch (DatabaseType)
                {
                    case DatabaseType.MySql:
                        return typeof(MySqlDataProvider);
                    //case DatabaseType.SqlServer:
                    //    return typeof(SqlDataProvider);
                    //    break;
                    default:
                        throw new Exception("DatabaseType has an incorrect value.");
                }
            }
        }

        /// <summary>
        /// Gets the DatabaseType
        /// </summary>
        public static DatabaseType DatabaseType
        {
            get { return (DatabaseType)Enum.Parse(typeof(DatabaseType), Settings["DatabaseType"], true); }
        }

        private static NameValueCollection Settings
        {
            get { return GetSettings(section); }
        }
	}
}
