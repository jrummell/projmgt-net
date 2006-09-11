using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;

namespace PMT.Controls
{
	public class HeaderControl : UserControl
	{
        protected Label lblRole;
        protected Label lblUsername;
        protected HyperLink hlProfile;
        protected HyperLink hlLogout;
        protected HyperLink hlMessages;
        protected HyperLink hlRegister;
        protected HyperLink hlLogin;
        protected Panel pnlLoggedIn;
        protected Panel pnlLoggedOut;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
            if(Context.User.Identity.IsAuthenticated)
            {
                lblRole.Text = Request.Cookies["user"]["role"];
				lblUsername.Text = Request.Cookies["user"]["name"];
                hlProfile.NavigateUrl = Global.ApplicationPath + "AllUsers/Profile.aspx";
                hlMessages.NavigateUrl = Global.ApplicationPath + "AllUsers/Msg";
                hlLogout.NavigateUrl = Global.ApplicationPath + "Logout.aspx";

                pnlLoggedIn.Visible = true;
                pnlLoggedOut.Visible = false;
            }
            else
            {
                lblRole.Text = String.Empty;
                hlRegister.NavigateUrl = Global.ApplicationPath + "Register.aspx";
                hlLogin.NavigateUrl = Global.ApplicationPath + "Login.aspx";

                pnlLoggedIn.Visible = false;
                pnlLoggedOut.Visible = true;
            }
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion
	}
}
