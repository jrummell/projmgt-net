using System;
using System.Data;
using System.Web;
using System.Web.Configuration;
using System.Collections.Specialized;
using PMT.BLL;

namespace PMT.Configuration 
{
    internal static class PathHelper
    {
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

            return PathHelper.ApplicationPath + path;
        }
    }
}
