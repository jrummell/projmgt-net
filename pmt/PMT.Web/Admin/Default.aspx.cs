using System;
using System.Web.UI;
using PMT.BLL;

namespace PMT.Web.Admin
{
    public partial class Default : Page
    {
        private void Page_Load(object sender, EventArgs e)
        {
            var taUsers = new UserData();

            UserStatistics statistics = taUsers.GetStatistics();

            lblAdmins.Text = statistics.Admins.ToString();
            lblManagers.Text = statistics.Managers.ToString();
            lblDevelopers.Text = statistics.Developers.ToString();
            lblClients.Text = statistics.Clients.ToString();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Load += Page_Load;
        }
    }
}