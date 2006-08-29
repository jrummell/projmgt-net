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
using PMT.Controls;

namespace PMT.AllUsers
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class Profile : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.Button SubmitButton;
        protected System.Web.UI.WebControls.Label StatusLabel;
        protected ProfileControl ProfileControl1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
            if (!Page.IsPostBack)
            {
                ProfileControl1.AllowChangeUsername = false;
                ProfileControl1.AllowChangePassword = true;
                ProfileControl1.AllowChangeSecurity = false;

                // fill the form with the user's information
                ProfileControl1.fillForm(new User(Request.Cookies["user"]["id"]));
            }
            StatusLabel.Visible = false;
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void SubmitButton_Click(object sender, System.EventArgs e)
        {
            StatusLabel.Visible = false;
            if (!Page.IsValid)
                return;

            // create a user obj, fill it from the profile control, 
            //  and update the database
            PMT.User user = new User(Request.Cookies["user"]["id"]);
            ProfileControl1.fillUser(user);
            user.updateProfile();

            StatusLabel.Text = "Your profile has been updated.";
            StatusLabel.Visible = true;
        }
	}
}
