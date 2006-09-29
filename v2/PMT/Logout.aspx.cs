using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;

namespace PMT
{
	/// <summary>
	/// Logout the user and redirect to pmt root on page load
	/// </summary>
	public partial class Logout : Page
	{
		override protected void OnInit(EventArgs e)
		{
            FormsAuthentication.SignOut();
            Response.Redirect(Request.ApplicationPath);
		}
	}
}
