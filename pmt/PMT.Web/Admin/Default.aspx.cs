using System;
using System.Data;
using System.Web.UI;
using PMT.BLL;

namespace PMT.Web.Admin
{
    public partial class Default : Page
    {
        private void Page_Load(object sender, EventArgs e)
        {
            UserData taUsers = new UserData();
            DataTable dtUsers = taUsers.GetUserProfiles();

            string count = "count(ID)";
            string filter = "Enabled=0";
            int newUsers = (int)dtUsers.Compute(count, filter);
            lblNewUsers.Text = newUsers.ToString();

            filter = "Enabled=1";
            int users = (int)dtUsers.Compute(count, filter);
            lblTotalUsers.Text = users.ToString();

            filter += " and Role={0}";
            int admins = (int)dtUsers.Compute(count, String.Format(filter, (int)UserRole.Administrator));
            int managers = (int)dtUsers.Compute(count, String.Format(filter, (int)UserRole.Manager));
            int devs = (int)dtUsers.Compute(count, String.Format(filter, (int)UserRole.Developer));
            int clients = (int)dtUsers.Compute(count, String.Format(filter, (int)UserRole.Client));

            lblAdmins.Text = admins.ToString();
            lblManagers.Text = managers.ToString();
            lblDevelopers.Text = devs.ToString();
            lblClients.Text = clients.ToString();
        }

        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(Page_Load);
        }
    }
}