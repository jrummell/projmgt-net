using System;
using System.Web.UI;
using PMT.BLL;

namespace PMT.Web.AllUsers
{
    public partial class Profile : Page
    {
        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init"/> event to initialize the page.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            Load += Page_Load;
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProfileControl1.FillForm(Global.LoggedInUser);
            }
            StatusLabel.Visible = false;
        }

        /// <summary>
        /// Handles the Click event of the SubmitButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
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