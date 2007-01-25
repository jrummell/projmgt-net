using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PMT.DAL;
using PMT.DAL.UsersDataSetTableAdapters;
using PMT.BLL;

namespace PMT.Admin
{
    public partial class Default : Page
    {
        private void Page_Load(object sender, EventArgs e)
        {
            UsersTableAdapter taUsers = new UsersTableAdapter();
            UsersDataSet.UsersDataTable dtUsers = taUsers.GetUsers();

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
