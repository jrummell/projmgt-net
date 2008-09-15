using System;

namespace PMT.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect(PathHelper.GetUserDefaultPath());
            }
        }
    }
}
