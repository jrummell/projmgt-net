using System;
using System.Web;
using PMT.BLL;

namespace PMT.Web
{
    public class Global : HttpApplication
    {
        internal static User LoggedInUser
        {
            get
            {
                if (HttpContext.Current.Session["user"] == null && HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    UserService data = new UserService();
                    HttpContext.Current.Session["user"] = data.GetByUsername(HttpContext.Current.User.Identity.Name);
                }

                return (User) HttpContext.Current.Session["user"];
            }
        }

        #region HttpApplication Events

        private void Application_Start(Object sender, EventArgs e)
        {
            // make sure we have one admin and one manager
            UserService data = new UserService();
            if (!data.UsernameExists("admin"))
            {
                User admin = new User(UserRole.Administrator) {UserName = "admin", Password = "asdf"};

                data.Insert(admin);
            }

            if (!data.UsernameExists("manager"))
            {
                User manager = new User(UserRole.Manager) {UserName = "manager", Password = "asdf"};

                data.Insert(manager);
            }
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