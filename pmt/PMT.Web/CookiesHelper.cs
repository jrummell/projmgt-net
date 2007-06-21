using System;
using System.Web;
using PMT.BLL;

namespace PMT.Web
{
    /// <summary>
    /// Provides methods to extract information from the UserCookie
    /// </summary>
    internal static class CookiesHelper
    {
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
    }
}
