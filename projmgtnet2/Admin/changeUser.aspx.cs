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

namespace PMT.Admin
{
    public class ChangeUser : Page
    {
        protected ProfileControl ProfileControl1;
        protected Button Submit;
        protected Button Cancel;
        private PMTUser user;

        private void Page_Load(object sender, System.EventArgs e)
        {
            IDataProvider conn = DataProviderFactory.CreateInstance();

            if (this.UserType.Equals("new"))
            {
                //new user handling here
                //need to move the new user info to the users table
                conn.EnablePMTUser(this.UserID, new TransactionFailedHandler(this.TransactionFailed));
            }
            else if (this.UserType.Equals("current"))
            {
                //current user handling here
                user = conn.GetPMTUserById(this.UserID);
            }

            if(!Page.IsPostBack)
            {
                //what to do when the page is loaded fresh
                //set the control to show admin field set
                //then fill it with the appropriate user information
                ProfileControl1.AdminView = true;
                ProfileControl1.fillForm(conn.GetPMTUserById(this.UserID));
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
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void Submit_Click(object sender, System.EventArgs e)
        {
            IDataProvider conn = DataProviderFactory.CreateInstance();

            //store new user information to database
            user = conn.GetPMTUserById(this.UserID);
            ProfileControl1.fillUser(user);
            conn.UpdatePMTUser(user, new TransactionFailedHandler(this.TransactionFailed));
        }

        private void Cancel_Click(object sender, System.EventArgs e)
        {
            //cancel user profile editing, return to user list page
            Response.Redirect("userList.aspx");
        }

        private void TransactionFailed(Exception ex)
        {
            Response.WriteFile(String.Format("Update failed. Error {0}", ex.Message));
        }

        /// <summary>
        /// Gets the user id from the query string
        /// </summary>
        public int UserID
        {
            get {   return Convert.ToInt32(Request.QueryString["id"]);  }
        }

        /// <summary>
        /// Gets the user type from the query string
        /// </summary>
        public string UserType
        {
            get {   return Request.QueryString["type"]; }
        }
    }
}
