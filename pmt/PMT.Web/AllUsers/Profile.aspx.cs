using System;
using System.Web.UI;
using PMT.BLL;

namespace PMT.Web.AllUsers
{
    public partial class Profile : Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            Load += Page_Load;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProfileControl1.FillForm(Global.LoggedInUser);
            }
            StatusLabel.Visible = false;
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            StatusLabel.Visible = false;
            if (!Page.IsValid)
            {
                return;
            }

            ProfileControl1.FillUser(Global.LoggedInUser);

            UserService service = new UserService();
            service.Update(Global.LoggedInUser);

            StatusLabel.Text = "Your profile has been updated.";
            StatusLabel.Visible = true;
        }
    }
}