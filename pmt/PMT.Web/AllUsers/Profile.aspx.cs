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
//using PMTComponents;
//using PMTDataProvider;
using PMT.BLL;
using PMT.DAL.UsersDataSetTableAdapters;
using PMT.Configuration;

namespace PMT.AllUsers
{
	public partial class UserProfile : Page
	{
        private PMT.BLL.User user;
        private UserData userData;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
            if (!Page.IsPostBack)
            {
                ProfileControl1.AllowChangeUsername = false;
                ProfileControl1.AllowChangePassword = true;
                ProfileControl1.AllowChangeSecurity = false;

                userData = new UserData();
                user = userData.GetUser(Config.LoggedInUserID);

                // fill the form with the user's information
                ProfileControl1.FillForm(user);
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

        }
		#endregion

        protected void SubmitButton_Click(object sender, System.EventArgs e)
        {
            StatusLabel.Visible = false;
            if (!Page.IsValid)
                return;

            // create a user obj, fill it from the profile control, 
            //  and update the database
            user = userData.GetUser(Config.LoggedInUserID);

            ProfileControl1.FillUser(user);

            if (userData.UpdateUser(user))
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
