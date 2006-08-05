using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using PMT.Controls;
using PMTComponents;
using PMTDataProvider;

namespace PMT
{
    /// <summary>
    /// Summary description for Register.
    /// </summary>
    public class Register : Page
    {
        protected Panel RegisterPanel;
        protected Panel StatusPanel;
        protected Label StatusLabel;
        protected Button SubmitButton;
        protected ProfileControl ProfileControl1;
    
        private void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
            if (!Page.IsPostBack)
            {
                ProfileControl1.AllowChangePassword = false;
                ProfileControl1.AllowNewPassword = true;
                ProfileControl1.AllowChangeSecurity = true;
                ProfileControl1.AllowChangeUsername = true;
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
            if (!Page.IsValid)
                return;

            // clear the status label and display it, allowing for error messages
            StatusLabel.Text = "";
            StatusPanel.Visible = true;

            IDataProvider conn = DataProvider.CreateInstance();
            //BEFORE WE INSERT ANYTHING, verify email address and username do not exist already
            //email address verification
            if(conn.VerifyEmailExists(ProfileControl1.Email))
            {
                //error out, email already exists
                StatusLabel.Text = "Email already exists.";
                return;
            }

            //username verification
            //this requires two parts, one to make sure said username does not already exist
            //second, make sure said username is not already requested
            if(conn.GetPMTUserByUsername(ProfileControl1.Username) != null)
            {
                //error out, username already exists
                StatusLabel.Text = "Username Not Available.";
                return;
            }

            // insert the new user
            PMTUser user = new PMTUser();
            ProfileControl1.fillUser(user);
            user.Enabled = false;
            if (conn.InsertPMTUser(user, new TransactionFailedHandler(this.TransactionFailed)))
            {
                RegisterPanel.Visible = false;
                StatusLabel.Text = "Thank you for registering.  Your account will be reviewed soon.";
            }
        }

        private void TransactionFailed(Exception ex)
        {
            StatusLabel.Text = String.Format("Registration failed. Error: {0}", ex.Message);
        }
    }
}
