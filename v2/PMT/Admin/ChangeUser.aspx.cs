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
    public partial class ChangeUser : Page
    {
        private PMTUser user;

        protected void Page_Load(object sender, System.EventArgs e)
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
                user = conn.GetPMTUser(this.UserID);
            }

            if(!Page.IsPostBack)
            {
                //what to do when the page is loaded fresh
                //set the control to show admin field set
                //then fill it with the appropriate user information
                ProfileControl1.AdminView = true;
                ProfileControl1.fillForm(conn.GetPMTUser(this.UserID));
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

        protected void Submit_Click(object sender, System.EventArgs e)
        {
            IDataProvider conn = DataProviderFactory.CreateInstance();

            //store new user information to database
            user = conn.GetPMTUser(this.UserID);
            ProfileControl1.fillUser(user);
            conn.UpdatePMTUser(user, new TransactionFailedHandler(this.TransactionFailed));
        }

        protected void Cancel_Click(object sender, System.EventArgs e)
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
