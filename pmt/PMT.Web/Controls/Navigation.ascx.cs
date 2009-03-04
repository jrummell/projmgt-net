using System;
using System.Web.UI;
using PMT.BLL;

namespace PMT.Web.Controls
{
    public partial class Navigation : UserControl
    {
        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> object that contains the event data.</param>
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
            hlElmah.NavigateUrl = "~/Admin/elmah.axd";

            if (Context.User.Identity.IsAuthenticated)
            {
                switch (Global.LoggedInUser.Role)
                {
                    case UserRole.Client:
                        divClient.Visible = true;
                        break;
                    case UserRole.Developer:
                        divDevloper.Visible = true;
                        break;
                    case UserRole.Manager:
                        divManager.Visible = true;
                        break;
                    case UserRole.Administrator:
                        divAdministrator.Visible = true;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Visible = false;
            }
        }
    }
}