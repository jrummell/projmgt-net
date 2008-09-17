using System;
using System.Web.UI;
using PMT.BLL;

namespace PMT.Web.Controls
{
    public partial class Navigation : UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Load += Page_Load;
        }

        private void Page_Load(object sender, EventArgs e)
        {
            hlElmah.NavigateUrl = "~/Admin/elmah/default.aspx";

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