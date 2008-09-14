using System;
using System.Web.UI;
using PMT.BLL;

namespace PMT.Web.PM
{
    public partial class Developers : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserData data = new UserData();
            dvDevs.DataSource = data.GetDevelopersByManager(Global.LoggedInUser.ID);
            dvDevs.DataBind();
        }
    }
}