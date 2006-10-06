using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using PMTComponents;
using PMTDataProvider;

namespace PMT
{
    public partial class Login : Page
    {
        private PMTUser user;
    
        protected void Page_Load(object sender, System.EventArgs e)
        {
            // if the user is currently logged in, log them out
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }
		
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {    

		}
        #endregion

        bool CustomAuthenticate(string username, string password)
        {            
            IDataProvider conn = DataProviderFactory.CreateInstance();
            if (conn.AuthenticateUser(username, password, new TransactionFailedHandler(this.TransactionFailed)))
                user = conn.GetPMTUser(username);
            else
                 return false;

            if (user == null)
            {
                this.TransactionFailed(new NullReferenceException("User could not be authenticated"));
                return false;
            }

            // create the cookie
            Response.Cookies["user"].Values.Add("role",  user.Role.ToString());
            Response.Cookies["user"].Values.Add("id",    user.ID.ToString());
            Response.Cookies["user"].Values.Add("name",  user.UserName);
            Response.Cookies["user"].Values.Add("fname", user.FirstName);
            Response.Cookies["user"].Values.Add("lname", user.LastName);

            return true;
        }

        private void TransactionFailed(Exception ex)
        {
            lblResult.Text = ex.Message;
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

                if (url.ToLower().EndsWith("default.aspx"))
                {
                    url = Global.GetUserDefaultPath(user.Role);
                }

                Response.Redirect(url);
			}
        }
}
}
