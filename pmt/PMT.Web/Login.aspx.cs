using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMT.BLL;

namespace PMT.Web
{
    public partial class Login : Page
    {
        private User user;
        private UserData userData;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            // if the user is currently logged in, log them out
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }
        }

        bool CustomAuthenticate(string username, string password)
        {
            userData = new UserData();

            if (userData.AuthenticateUser(username, password))
            {
                user = userData.GetUser(username);
            }
            else
            {
                this.TransactionFailed(new Exception("User could not be authenticated"));
                return false;
            }

            // add the cookie
            Response.Cookies.Add(user.GetCookie());

            return true;
        }

        private void TransactionFailed(Exception ex)
        {
            Login1.FailureText = ex.Message;
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (!IsValid)
                return;

            string username = Login1.UserName;
            string password = Encryption.MD5Encrypt(Login1.Password);

            e.Authenticated = CustomAuthenticate(username, password);
            if (e.Authenticated)
            {
                bool persist = Login1.RememberMeSet;
                // second param is ignored ...
                string url = FormsAuthentication.GetRedirectUrl(user.UserName, false);
                // this actually creates the cookie
                FormsAuthentication.SetAuthCookie(user.UserName, persist);

                if (String.Compare(url, ResolveUrl("~/default.aspx"), true) == 0)
                {
                    url = PathHelper.GetUserDefaultPath(user.Role);
                }

                Response.Redirect(url);
            }
        }
    }
}