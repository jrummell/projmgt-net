using System;
using System.Data;
using System.Web;
using System.Web.Configuration;
using System.Collections.Specialized;
using PMT.BLL;

namespace PMT.Configuration 
{
    public class Config : PMT.BLL.ConfigBase
    {
        protected static string section = "pmtSettings/pmt";

        /// <summary>
        /// Gets the application path ending with a "/".
        /// </summary>
        public static string ApplicationPath
        {
            get
            {
                string path = HttpContext.Current.Request.ApplicationPath;
                if (!path.EndsWith("/"))
                {
                    path += "/";
                }
                return path;
            }
        }

        /// <summary>
        /// Gets the users default path based on their role.
        /// </summary>
        public static string GetUserDefaultPath(UserRole role)
        {
#warning I don't like having the folder names as string literals, perhaps they could be moved into Properties.Settings?
            string path;
            switch (role)
            {
                case UserRole.Administrator:
                    path = "Admin/";
                    break;
                case UserRole.Manager:
                    path = "PM/";
                    break;
                case UserRole.Developer:
                    path = "Dev/";
                    break;
                case UserRole.Client:
                    path = "Client/";
                    break;
                default:
                    return null;
            }

            return Config.ApplicationPath + path;
        }

        #region User Cookie Info
        /// <summary>
        /// Gets the logged in user's id from their cookie
        /// </summary>
        public static int LoggedInUserID
        {
            get
            {
                return Convert.ToInt32(HttpContext.Current.Request.Cookies["user"]["id"]);
            }
        }

        /// <summary>
        /// Gets the logged in user's role from their cookie
        /// </summary>
        public static UserRole LoggedInUserRole
        {
            get
            {
                return (UserRole)Enum.Parse(typeof(UserRole), HttpContext.Current.Request.Cookies["user"]["role"]);
            }
        }

        /// <summary>
        /// Gets the logged in user's username from their cookie
        /// </summary>
        public static string LoggedInUserName
        {
            get
            {
                return HttpContext.Current.Request.Cookies["user"]["name"];
            }
        }
        #endregion
    }
}
