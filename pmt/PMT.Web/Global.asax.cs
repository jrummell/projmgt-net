using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Security.Principal;
using System.Configuration;
using System.Collections.Specialized;
using System.Net.Mail;
using PMT.Configuration;
using PMTComponents;
using PMTDataProvider;

namespace PMT 
{
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
            /*
             * this code is somehow broken ... I want it email the exception to me
             * 
             * I may just go with ELMAH instead (http://www.gotdotnet.com/workspaces/releases/viewuploads.aspx?id=f18bab11-162c-4267-a46e-72438c38df6f)
             * 
            HttpContext context = HttpContext.Current;

            Exception exception = context.Server.GetLastError();

            string errorInfo =
               "<br>Offending URL: " + context.Request.Url.ToString() +
               "<br>Source: " + exception.Source +
               "<br>Message: " + exception.Message +
               "<br>Stack trace: " + exception.StackTrace;

            // let the page finish running we clear the error
            context.Server.ClearError();

            //AssemblyTitleAttribute title = (AssemblyTitleAttribute)AssemblyTitleAttribute.GetCustomAttribute(
            //    Assembly.GetExecutingAssembly(), typeof(AssemblyTitleAttribute));

            MailAddress from = new MailAddress(Config.ErrorFromEmail, "Project Management .Net");
            MailAddress to = new MailAddress(Config.ErrorToEmail, "Administrator");
            MailMessage mm = new MailMessage(from, to);
            mm.Subject = "Project Management .Net Error";
            mm.Body = errorInfo;

            SmtpClient client = new SmtpClient("127.0.0.1");
            client.Send(mm);
            */
        }

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

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

