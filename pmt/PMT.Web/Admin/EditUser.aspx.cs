using System;
using System.Web.UI;
using PMT.BLL;

namespace PMT.Web.Admin
{
    public partial class EditUser : Page
    {
        /// <summary>
        /// Gets the user id from the query string
        /// </summary>
        public int UserID
        {
            get { return Convert.ToInt32(Request.QueryString["id"]); }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init"/> event to initialize the page.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            Load += Page_Load;
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserService service = new UserService();
                ProfileControl1.AdminView = true;
                ProfileControl1.FillForm(service.GetByID(UserID));
            }
        }

        /// <summary>
        /// Handles the Click event of the Submit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Submit_Click(object sender, EventArgs e)
        {
            if (!IsValid)
            {
                return;
            }

            //store new user information to database
            UserService service = new UserService();
            User user = service.GetByID(UserID);
            ProfileControl1.FillUser(user);
            service.Update(user);
        }
    }
}