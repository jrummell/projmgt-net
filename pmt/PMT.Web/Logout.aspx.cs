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
	public partial class Logout : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
            FormsAuthentication.SignOut();
            Response.Redirect(Request.ApplicationPath);
		}
	}
}
