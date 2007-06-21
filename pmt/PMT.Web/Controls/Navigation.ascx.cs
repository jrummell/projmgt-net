using System.Web.UI;
using PMT.BLL;

namespace PMT.Web.Controls
{
    public partial class Navigation : UserControl
    {
        protected static UserRole GetRole()
        {
            return CookiesHelper.LoggedInUserRole;
        }
    }
}
