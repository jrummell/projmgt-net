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
using PMT.DAL;
using PMT.DAL.UsersDataSetTableAdapters;
using PMT.BLL;

namespace PMT.Admin
{
    public partial class Users : Page
    {
        private CompleteUserInfoTableAdapter taUsers;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                // bind roles ddl
                int[] values = (int[])Enum.GetValues(typeof(UserRole));
                string[] names = Enum.GetNames(typeof(UserRole));
                for (int i = 0; i < values.Length; i++)
                {
                    ddlRoles.Items.Add(new ListItem(names[i], values[i].ToString()));
                }
                ddlRoles.Items.Insert(0, new ListItem("All", String.Empty));

                // bind users datagrid
                taUsers = new CompleteUserInfoTableAdapter();
                UsersDataSet.CompleteUserInfoDataTable dt = taUsers.GetCompleteUserInfo();

                // filter by selted role
                UserRole role = Role;
                string filter;
                if (Enum.IsDefined(typeof(UserRole), role))
                {
                    filter = String.Format("Role={0} and Enabled=1", (int)role);
                    ddlRoles.Items.FindByValue(role.ToString("d")).Selected = true; ;
                }
                else
                {
                    filter = "Enabled=1";
                }

                dt.DefaultView.RowFilter = filter;

                UserDataGrid.DataSource = dt;
                UserDataGrid.DataBind();
            }
        }

        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);
            UserDataGrid.ItemDataBound += new DataGridItemEventHandler(UserDataGrid_ItemDataBound);
            this.Load += new EventHandler(Page_Load);
        }

        private void UserDataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Cells[e.Item.Cells.Count - 1].Text = Enum.GetName(typeof(UserRole), Convert.ToInt32(e.Item.Cells[e.Item.Cells.Count - 1].Text));
            }
        }

        #region QueryString Properties
        protected UserRole Role
        {
            get
            {
                string s = Request["role"];

                if (s == null)
                    return (UserRole)(-1);
                else
                    return (UserRole)Enum.Parse(typeof(UserRole), s);
            }
        }
        #endregion

        protected void ddlRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            string val = ddl.SelectedValue;

            string page = Request.AppRelativeCurrentExecutionFilePath;

            if (val != String.Empty)
            {
                page = String.Format(page+"?role={0}", val);
            }

            Response.Redirect(page);
        }
    }
}
