using System;
using System.Web;
using PMT.BLL;

namespace PMT.Web
{
    public class Global : HttpApplication
    {
        public static User LoggedInUser
        {
            get
            {
                if (HttpContext.Current.Session["user"] == null && HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    UserData data = new UserData();
                    HttpContext.Current.Session["user"] = data.GetUser(HttpContext.Current.User.Identity.Name);
                }

                return (User) HttpContext.Current.Session["user"];
            }
        }

        #region HttpApplication Events

        private void Application_Start(Object sender, EventArgs e)
        {
        }

        private void Session_Start(Object sender, EventArgs e)
        {
        }

        private void Application_BeginRequest(Object sender, EventArgs e)
        {
        }

        private void Application_EndRequest(Object sender, EventArgs e)
        {
        }

        private void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
        }

        private void Session_End(Object sender, EventArgs e)
        {
        }

        private void Application_End(Object sender, EventArgs e)
        {
        }

        #endregion
    }
}