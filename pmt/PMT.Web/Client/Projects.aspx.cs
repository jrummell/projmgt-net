using System;
using System.Web.UI;
using PMT.BLL;

namespace PMT.Web.Client
{
    public partial class Projects : Page
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
        private void Page_Load(object sender, EventArgs e)
        {
            ProjectService service = new ProjectService();

            dgProjects.DataSource = service.GetByUser(Global.LoggedInUser.ID);
            dgProjects.DataBind();
        }
    }
}