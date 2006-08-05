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
using PMTComponents;
using PMTDataProvider;

namespace PMT.AllUsers
{
	public class Profile : Page
	{
        protected Button SubmitButton;
        protected Label StatusLabel;
        protected ProfileControl ProfileControl1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
            if (!Page.IsPostBack)
            {
                ProfileControl1.AllowChangeUsername = false;
                ProfileControl1.AllowChangePassword = true;
                ProfileControl1.AllowChangeSecurity = false;

                IDataProvider conn = DataProvider.CreateInstance();
                PMTUser user = conn.GetPMTUserById(Convert.ToInt32(Request.Cookies["user"]["id"]));

                // fill the form with the user's information
                ProfileControl1.fillForm(user);
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
            IDataProvider conn = DataProvider.CreateInstance();
            PMTUser user = conn.GetPMTUserById(Convert.ToInt32(Request.Cookies["user"]["id"]));

            ProfileControl1.fillUser(user);
            bool success = conn.UpdatePMTUser(user, new TransactionFailedHandler(this.TransactionFailed));

            if (success)
            {
                StatusLabel.Text = "Your profile has been updated.";
                StatusLabel.Visible = true;
            }
        }

        private void TransactionFailed(Exception ex)
        {
            StatusLabel.Text = String.Format("Update failed.  Error {0}", ex.Message);
            StatusLabel.ForeColor = Color.Red;
            StatusLabel.Visible = true;
        }
	}
}
