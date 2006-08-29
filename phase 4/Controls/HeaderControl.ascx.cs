namespace PMT.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Text;

	/// <summary>
	///		Summary description for WebUserControl1.
	/// </summary>
	public class HeaderControl : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label userTypeLabel;
		protected System.Web.UI.WebControls.Label PMTLabel;
        protected System.Web.UI.WebControls.Label userNameLabel;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
            if(Context.User.Identity.IsAuthenticated)
            {
                userTypeLabel.Text = Request.Cookies["user"]["role"];
                
				StringBuilder s = new StringBuilder();
				s.Append("Welcome ");
				s.Append(Request.Cookies["user"]["fname"]);
				s.Append(" ");
				s.Append(Request.Cookies["user"]["lname"]);
				s.Append(", you are logged in as ");
				s.Append(Request.Cookies["user"]["name"]);
				s.Append(".");

				userNameLabel.Text = s.ToString();
            }
            else
            {
                userTypeLabel.Text = "";
                userNameLabel.Text = "";
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
