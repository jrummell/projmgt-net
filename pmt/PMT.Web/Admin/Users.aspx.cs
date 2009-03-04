using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMT.BLL;

namespace PMT.Web.Admin
{
    public partial class Users : Page
    {
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // bind roles ddl
                foreach (UserRole userRole in Enum.GetValues(typeof (UserRole)))
                {
                    ddlRole.Items.Add(new ListItem(userRole.ToString(), userRole.ToString("d")));
                }
                ddlRole.Items.Insert(0, new ListItem("All", String.Empty));

                // bind users datagrid
                UserService userData = new UserService();
                ICollection<User> users;
                
                // filter by selected role
                string roleString = Request["role"];
                if (!String.IsNullOrEmpty(roleString))
                {
                    UserRole role = (UserRole) Enum.Parse(typeof(UserRole), roleString);
                    users = userData.GetByRole(role);
                    ddlRole.Items.FindByValue(role.ToString("d")).Selected = true;
                }
                else
                {
                    users = userData.GetAll();
                }

                UserDataGrid.DataSource = users;
                UserDataGrid.DataBind();
            }
        }
    }
}