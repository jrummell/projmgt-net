using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMT.BLL;

namespace PMT.Web
{
    public partial class Login : Page
    {
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (!IsValid)
            {
                return;
            }

            // if the user is currently logged in, log them out
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }

            string username = Login1.UserName;
            string password = Login1.Password;

            e.Authenticated = CustomAuthenticate(username, password);
        }

        private static bool CustomAuthenticate(string username, string password)
        {
            UserData userData = new UserData();
            return userData.AuthenticateUser(username, password);
        }
    }
}