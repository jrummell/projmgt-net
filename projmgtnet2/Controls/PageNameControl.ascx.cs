namespace PMT.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for PageNameControl.
	/// </summary>
	public class PageNameControl : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label Label1;
		private string title;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Label1.Text = title;
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

		public string PageTitle
		{
			get
			{	return title;	}
			set
			{	title = value;	}
		}
	}
}
