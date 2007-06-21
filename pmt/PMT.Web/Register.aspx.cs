using System;
using System.Web.UI;
using PMT.BLL;

namespace PMT.Web
{
    public partial class Register : Page
    {
        private User user;
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

        protected void SubmitButton_Click(object sender, EventArgs e)
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
    }
}