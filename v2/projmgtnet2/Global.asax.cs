using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Security.Principal;

namespace PMT 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : HttpApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{

		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

        void Application_AuthenticateRequest (Object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication) sender;

            if (app.Request.IsAuthenticated &&
                app.User.Identity is FormsIdentity) 
            {
                FormsIdentity identity = (FormsIdentity) app.User.Identity;

                // Find out what role (if any) the user belongs to
                //string role = identity.Name;

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

		protected void Application_Error(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}

    	#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

