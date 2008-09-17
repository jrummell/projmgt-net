using System;
using System.Web.UI;
using PMT.BLL;

namespace PMT.Web.Admin
{
    public partial class EditUser : Page
    {
        private User user;
        private UserService userData;

        public EditUser()
        {
            userData = new UserService();
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //what to do when the page is loaded fresh
                //set the control to show admin field set
                //then fill it with the appropriate user information
                ProfileControl1.AdminView = true;
                ProfileControl1.FillForm(userData.GetByID(this.UserID));
            }
        }

        protected void Submit_Click(object sender, System.EventArgs e)
        {
            //store new user information to database
            user = userData.GetByID(this.UserID);
            ProfileControl1.FillUser(user);
            userData.Update(user);
        }

        protected void Cancel_Click(object sender, System.EventArgs e)
        {
            //cancel user profile editing, return to user list page
            Response.Redirect("Users.aspx");
        }

        /// <summary>
        /// Gets the user id from the query string
        /// </summary>
        public int UserID
        {
            get {   return Convert.ToInt32(Request.QueryString["id"]);  }
        }
    }
}