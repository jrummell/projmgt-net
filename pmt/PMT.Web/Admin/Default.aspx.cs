using System;
using System.Web.UI;
using PMT.BLL;

namespace PMT.Web.Admin
{
    public partial class Default : Page
    {
        private void Page_Load(object sender, EventArgs e)
        {
            var taUsers = new UserService();

            UserStatistics statistics = taUsers.GetStatistics();

            //TODO: make the labels a repeater
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Load += Page_Load;
        }
    }
}