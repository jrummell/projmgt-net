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
    public class Login : Page
    {
        protected TextBox UserTextBox;
        protected Button SubmitButton;
        protected TextBox PasswordTextBox;
        protected RequiredFieldValidator UserRequiredFieldValidator;
        protected RequiredFieldValidator PasswordRequiredFieldValidator;
        protected Label ErrorLabel;

        private PMTUser user;
    
        private void Page_Load(object sender, System.EventArgs e)
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
			this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
        #endregion

        private void SubmitButton_Click(object sender, System.EventArgs e)
        {
            if (!this.IsValid)
                return;

            string username = UserTextBox.Text;
            string password = Encryption.encrypt(PasswordTextBox.Text);

			if (CustomAuthenticate(username, password)) 
			{
				// WTF does the first param do ???
				string url = FormsAuthentication.GetRedirectUrl(user.UserName, false);
				FormsAuthentication.SetAuthCookie(user.Role.ToString(), false);

				if (url.Equals(Request.ApplicationPath + "/default.aspx"))
				{
					if (user.Role.Equals(PMTUserRole.Manager))
						url = Request.ApplicationPath + "/PM";
					else if (user.Role.Equals(PMTUserRole.Developer))
						url = Request.ApplicationPath + "/Dev";
					else if (user.Role.Equals(PMTUserRole.Administrator))
						url = Request.ApplicationPath + "/Admin";
					else if (user.Role.Equals(PMTUserRole.Client))
					   url = Request.ApplicationPath + "/Client";
				}
            
				Response.Redirect (url);
			}
        }

        bool CustomAuthenticate(string username, string password)
        {
            
            IDataProvider conn = DataProvider.CreateInstance();
            if (conn.AuthenticateUser(username, password, new TransactionFailedHandler(this.TransactionFailed)))
                user = conn.GetPMTUserByUsername(username);
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
            ErrorLabel.Text = ex.Message;
        }
    }
}
