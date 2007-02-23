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
using PMT.Web.Controls;
using PMT.BLL;
using PMT.DAL.UsersDataSetTableAdapters;
using PMT.Configuration;
using PMT.Web;

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
                user = userData.GetUser(CookiesHelper.LoggedInUserID);

                // fill the form with the user's information
                ProfileControl1.FillForm(user);
            }
            StatusLabel.Visible = false;
		}

        protected void SubmitButton_Click(object sender, System.EventArgs e)
        {
            StatusLabel.Visible = false;
            if (!Page.IsValid)
                return;

            // create a user obj, fill it from the profile control, 
            //  and update the database
            user = userData.GetUser(CookiesHelper.LoggedInUserID);

            ProfileControl1.FillUser(user);

            if (userData.UpdateUser(user))
            {
                StatusLabel.Text = "Your profile has been updated.";
                StatusLabel.Visible = true;
            }
        }
	}
}
