using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Security.Principal;
using System.Configuration;
using System.Collections.Specialized;
using PMTComponents;

namespace PMT 
{
    public enum DatabaseType { MySql, SqlServer }

	public class Global : HttpApplication
	{
        private static string section = "pmtSettings/pmt";
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}

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
        /// Gets the users default path base on their role.
        /// </summary>
        public static string GetUserDefaultPath(PMTUserRole role)
        {
            string path;
            switch (role)
            {
                case PMTUserRole.Administrator:
                    path = "Admin/";
                    break;
                case PMTUserRole.Manager:
                    path = "PM/";
                    break;
                case PMTUserRole.Developer:
                    path = "Dev/";
                    break;
                case PMTUserRole.Client:
                    path = "Client/";
                    break;
                default:
                    return null;
            }

            return Global.ApplicationPath + path;
        }
		
        #region HttpApplication Events
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
        #endregion

        #region Web.config Settings
        /// <summary>
        /// Gets a Configuration Setting from web.config.
        /// </summary>
        /// <param name="setting">Configuration setting key</param>
        /// <returns>Configuration setting value</returns>
        private static string GetConfigSetting(string setting)
        {
            return ((NameValueCollection)ConfigurationSettings.GetConfig(section))[setting];
        }
        #endregion

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

