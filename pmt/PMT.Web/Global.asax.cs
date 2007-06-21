using System;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace PMT.Web 
{
	public class Global : HttpApplication
	{
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
            HttpApplication app = (HttpApplication) sender;

            if (app.Request.IsAuthenticated &&
                app.User.Identity is FormsIdentity) 
            {
                FormsIdentity identity = (FormsIdentity) app.User.Identity;

                if (Request.Cookies["user"] != null)
                {
                    string role = Request.Cookies["user"]["role"];

                    // Create a GenericPrincipal containing the role name
                    // and assign it to the current request
                    app.Context.User = 
                        new GenericPrincipal(identity, new string[] { role });
                }
            }
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

