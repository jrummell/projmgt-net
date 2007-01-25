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
using PMT.DAL;
using PMT.DAL.UsersDataSetTableAdapters;
using PMT.BLL;

namespace PMT.Admin
{
    public partial class EditUser : Page
    {
        private PMT.BLL.User user;
        private UserData userData;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            userData = new UserData();
            user = userData.GetUser(this.UserID);

            if (this.UserType.Equals("new"))
            {
                userData.UpdateUser(user);
            }

            if (!Page.IsPostBack)
            {
                //what to do when the page is loaded fresh
                //set the control to show admin field set
                //then fill it with the appropriate user information
                ProfileControl1.AdminView = true;
                ProfileControl1.FillForm(userData.GetUser(this.UserID));
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
            //store new user information to database
            userData = new UserData();

            user = userData.GetUser(this.UserID);
            ProfileControl1.FillUser(user);
            userData.UpdateUser(user);
        }

        protected void Cancel_Click(object sender, System.EventArgs e)
        {
            //cancel user profile editing, return to user list page
            Response.Redirect("userList.aspx");
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
