using System;
using System.Web.UI;
using PMT.BLL;

namespace PMT.Web.PM
{
    public partial class Developers : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserService data = new UserService();
            dvDevs.DataSource = data.GetByManager(Global.LoggedInUser.ID);
            dvDevs.DataBind();
        }
    }
}