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

namespace PMT
{
    /// <summary>
    /// Summary description for Register.
    /// </summary>
    public class Register : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Panel RegisterPanel;
        protected System.Web.UI.WebControls.Panel StatusPanel;
        protected System.Web.UI.WebControls.Label StatusLabel;
        protected System.Web.UI.WebControls.Button SubmitButton;
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

            //BEFORE WE INSERT ANYTHING, verify email address and username do not exist already
            //email address verification
            if(PMT.User.verifyEmailExists(ProfileControl1.Email))
            {
                //error out, email already exists
                StatusLabel.Text = "Email already exists.";
                return;
            }
            //username verification
            //this requires two parts, one to make sure said username does not already exist
            //second, make sure said username is not already requested
            if(PMT.User.verifyUserNameExists(ProfileControl1.Username, true))
            {
                //error out, username already exists
                StatusLabel.Text = "Username Not Available.";
                return;
            }

            // create the new user
            User user=new User(ProfileControl1.Username, ProfileControl1.NewPassword1,
                ProfileControl1.Security, ProfileControl1.FirstName,
                ProfileControl1.LastName, ProfileControl1.Email,
                ProfileControl1.Phone, ProfileControl1.Address,
                ProfileControl1.City, ProfileControl1.State,
                ProfileControl1.Zip);
            RegisterPanel.Visible = false;
            StatusLabel.Text = "Thank you for registering.  Your account will be reviewed soon.";
        }
    }
}
