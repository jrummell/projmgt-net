using System;
using System.Web.UI;
using PMT.BLL;

namespace PMT.Web.PM
{
    public partial class Developers : Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            Load += Page_Load;
        }

        private void Page_Load(object sender, EventArgs e)
        {
            UserService data = new UserService();
            dvDevs.DataSource = data.GetDevelopersByManager(Global.LoggedInUser.ID);
            dvDevs.DataBind();
        }
    }
}