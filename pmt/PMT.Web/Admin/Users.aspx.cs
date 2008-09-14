using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMT.BLL;

namespace PMT.Web.Admin
{
    public partial class Users : Page
    {
        protected UserRole Role
        {
            get
            {
                string s = Request["role"];

                if (s == null)
                {
                    return (UserRole) (-1);
                }
                return (UserRole) Enum.Parse(typeof (UserRole), s);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // bind roles ddl
                int[] values = (int[]) Enum.GetValues(typeof (UserRole));
                string[] names = Enum.GetNames(typeof (UserRole));
                for (int i = 0; i < values.Length; i++)
                {
                    ddlRoles.Items.Add(new ListItem(names[i], values[i].ToString()));
                }
                ddlRoles.Items.Insert(0, new ListItem("All", String.Empty));

                // bind users datagrid
                UserData userData = new UserData();
                ICollection<User> users;
                // filter by selected role
                UserRole role = Role;
                if (Enum.IsDefined(typeof (UserRole), role))
                {
                    users = userData.GetUsersByRole(role);
                    ddlRoles.SelectedValue = role.ToString("d");
                }
                else
                {
                    users = userData.GetUsers();
                }

                UserDataGrid.DataSource = users;
                UserDataGrid.DataBind();
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            UserDataGrid.ItemDataBound += UserDataGrid_ItemDataBound;
            Load += Page_Load;
        }

        private void UserDataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Cells[e.Item.Cells.Count - 1].Text = Enum.GetName(typeof (UserRole),
                                                                         Convert.ToInt32(
                                                                             e.Item.Cells[e.Item.Cells.Count - 1].Text));
            }
        }

        protected void ddlRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList) sender;
            string val = ddl.SelectedValue;

            string page = Request.AppRelativeCurrentExecutionFilePath;

            if (!String.IsNullOrEmpty(val))
            {
                page = String.Format(page + "?role={0}", val);
            }

            Response.Redirect(page);
        }
    }
}