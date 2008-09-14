using System.Web.UI;
using PMT.BLL;

namespace PMT.Web.AllUsers
{
    public partial class UserProfile : Page
    {
        private User user;
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
                user = userData.GetUser(Global.LoggedInUser.ID);

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
            user = userData.GetUser(Global.LoggedInUser.ID);

            ProfileControl1.FillUser(user);

           StatusLabel.Text = "Your profile has been updated.";
            StatusLabel.Visible = true;
        }
    }
}