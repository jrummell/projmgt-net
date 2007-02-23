using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using PMT.Configuration;
using PMT.Web;

namespace PMT.Web.Controls
{
	public partial class Header : UserControl
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
            bool isLoggedIn = Context.User.Identity.IsAuthenticated;

            if (isLoggedIn)
            {
                litRole.Text = CookiesHelper.LoggedInUserRole.ToString();
                hlProfile.Text = CookiesHelper.LoggedInUserName;
            }

            spanLoggedIn.Visible = isLoggedIn;
            spanLoggedOut.Visible = !isLoggedIn;
		}
	}
}
