using System.Web;
using PMT.BLL;

namespace PMT.Web
{
    internal static class PathHelper
    {
        /// <summary>
        /// Gets the users default path based on their role.
        /// </summary>
        public static string GetUserDefaultPath()
        {
            string path;
            switch (Global.LoggedInUser.Role)
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

            return "~/" + path;
        }
    }
}