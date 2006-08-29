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

namespace PMT
{
    /// <summary>
    /// Summary description for Login.
    /// </summary>
    public class Login : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.TextBox UserTextBox;
        protected System.Web.UI.WebControls.Button SubmitButton;
        protected System.Web.UI.WebControls.TextBox PasswordTextBox;
        protected System.Web.UI.WebControls.RequiredFieldValidator UserRequiredFieldValidator;
        protected System.Web.UI.WebControls.RequiredFieldValidator PasswordRequiredFieldValidator;
        protected System.Web.UI.WebControls.Label ErrorLabel;

        private PMT.User user;
    
        private void Page_Load(object sender, System.EventArgs e)
        {
            // if the user is currently logged in, log them out
            if (User.Identity.IsAuthenticated)
                FormsAuthentication.SignOut();
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
				string url = FormsAuthentication.GetRedirectUrl("", false);
				FormsAuthentication.SetAuthCookie(user.Role, false);

				if (url.Equals(Request.ApplicationPath + "/default.aspx"))
				{
					if (user.Role.Equals("Project Manager"))
						url = Request.ApplicationPath + "/PM";
					else if (user.Role.Equals("Developer"))
						url = Request.ApplicationPath + "/Dev";
					else if (user.Role.Equals("Administrator"))
						url = Request.ApplicationPath + "/Admin";
					else if (user.Role.Equals("Client"))
					   url = Request.ApplicationPath + "/Client";
				}
            
				Response.Redirect (url);
			}
        }

        bool CustomAuthenticate(string username, string password)
        {
            DBDriver db = new DBDriver();
            string q="select count(*) from softeng4.users where userName='"+username+"';";
            db.Query = q;
            int k=(int)db.scalar();
            if(k==0)
            {
                //user does not exist in DB
                ErrorLabel.Text = "You have entered an unknown username.";
                return false;
            }
            else
            {
                q="select count(*) from softeng4.users u where u.userName='"+username+"' and u.password='"+password+"'";
                db.Query = q;
                k=(int)db.scalar();
                if(k==0)
                {
                    //password incorrect
                    ErrorLabel.Text = "You have entered an incorrect password.";
                    return false;
                }
                else
                {
                    //successful authentication
                    q="select u.security s, u.ID id, p.firstName fname, p.lastName lname from softeng4.users u, softeng4.person p where u.ID = p.ID and u.username='"+username+"'";
                    db.Query = q;
                    SqlDataReader dr=db.createReader();
                    dr.Read();

                    user = new User(dr["id"].ToString());

                    db.close();

                    // create the cookie
                    Response.Cookies["user"].Values.Add("role",  user.Role);
                    Response.Cookies["user"].Values.Add("id",    user.ID);
					Response.Cookies["user"].Values.Add("name",  user.UserName);
                    Response.Cookies["user"].Values.Add("fname", user.FirstName);
					Response.Cookies["user"].Values.Add("lname", user.LastName);

                    return true;
                }
            }
        }
    }
}
