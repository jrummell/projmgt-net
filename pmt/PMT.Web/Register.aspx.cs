using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMT.BLL;

namespace PMT.Web
{
    public partial class Register : Page
    {
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!IsValid)
            {
                return;
            }

            UserRole role = (UserRole) Enum.Parse(typeof (UserRole), ProfileControl1.Security);
            User user = new User(role, ProfileControl1.Username, ProfileControl1.NewPassword1);
            ProfileControl1.FillUser(user);

            UserService userService = new UserService();
            userService.Insert(user);

            RegisterPanel.Visible = false;

            StatusLabel.Text = "Thank you for registering.  Your account will be reviewed soon.";
        }

        protected void cvUsernameExists_ServerValidate(object source, ServerValidateEventArgs args)
        {
            UserService service = new UserService();
            args.IsValid = !service.Exists(ProfileControl1.Username);
        }
    }
}