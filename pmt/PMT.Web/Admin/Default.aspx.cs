using System;
using System.Web.UI;
using PMT.BLL;

namespace PMT.Web.Admin
{
    public partial class Default : Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Load += Page_Load;
        }

        private void Page_Load(object sender, EventArgs e)
        {
            UserService service = new UserService();
            UserStatistics statistics = service.GetStatistics();

            lblNewUsers.Text = statistics.NewUsers.ToString();
            lblTotalUsers.Text = statistics.TotalUsers.ToString();

            rptUsers.DataSource = statistics.RoleCounts;
            rptUsers.DataBind();
        }
    }
}