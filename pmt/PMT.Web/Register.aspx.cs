using System;
using System.Web.UI;
using PMT.BLL;

namespace PMT.Web
{
    public partial class Register : Page
    {
        private User user;
        private UserService userData;

        protected void Page_Load(object sender, EventArgs e)
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

            userData = new UserService();

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
            user = new User((UserRole) Enum.Parse(typeof (UserRole), ProfileControl1.Security), ProfileControl1.Username,
                            ProfileControl1.NewPassword1);
            ProfileControl1.FillUser(user);
            user.Enabled = false;

            userData.Insert(user);
            RegisterPanel.Visible = false;
            StatusLabel.Text = "Thank you for registering.  Your account will be reviewed soon.";
        }
    }
}