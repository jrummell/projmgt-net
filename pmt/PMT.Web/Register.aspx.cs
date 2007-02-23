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
using PMTComponents;
using PMT.DAL;
using PMT.DAL.UsersDataSetTableAdapters;
using PMT.BLL;

namespace PMT
{
    public partial class Register : Page
    {
        private PMT.BLL.User user;
        private UserData userData;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
            if (!Page.IsPostBack)
            {
                ProfileControl1.AllowChangePassword = false;
                ProfileControl1.AllowNewPassword = true;
                ProfileControl1.AllowChangeSecurity = true;
                ProfileControl1.AllowChangeUsername = true;
            }
        }

        protected void SubmitButton_Click(object sender, System.EventArgs e)
        {
            if (!Page.IsValid)
                return;

            userData = new UserData();

            // clear the status label and display it, allowing for error messages
            StatusLabel.Text = "";
            StatusPanel.Visible = true;

            //username verification
            //this requires two parts, one to make sure said username does not already exist
            //second, make sure said username is not already requested
            if (userData.UsernameExists(ProfileControl1.Username))
            {
                //error out, username already exists
                StatusLabel.Text = "Username Not Available.";
                return;
            }

            // insert the new user
            user = PMT.BLL.User.CreateUser((UserRole)Enum.Parse(typeof(UserRole), ProfileControl1.Security));
            ProfileControl1.FillUser(user);
            user.Enabled = false;

            userData.InsertUser(user);
            RegisterPanel.Visible = false;
            StatusLabel.Text = "Thank you for registering.  Your account will be reviewed soon.";
        }

        private void TransactionFailed(Exception ex)
        {
            StatusLabel.Text = String.Format("Registration failed. Error: {0}", ex.Message);
        }
    }
}
