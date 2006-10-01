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
	public partial class Header : UserControl
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
            bool isLoggedIn = Context.User.Identity.IsAuthenticated;

            if (isLoggedIn)
            {
                lblRole.Text = Request.Cookies["user"]["role"];
                lblUsername.Text = Request.Cookies["user"]["name"];
            }

            pnlLoggedIn.Visible = isLoggedIn;
            pnlLoggedOut.Visible = !isLoggedIn;
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

        }
		#endregion
	}
}
