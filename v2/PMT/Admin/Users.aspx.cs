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
using PMTDataProvider;
using PMTComponents;

namespace PMT.Admin
{
    public partial class Users : Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // bind roles ddl
                int[] values = (int[])Enum.GetValues(typeof(PMTUserRole));
                string[] names = Enum.GetNames(typeof(PMTUserRole));
                for (int i = 0; i < values.Length; i++)
                {
                    ddlRoles.Items.Add(new ListItem(names[i], values[i].ToString()));
                }
                ddlRoles.Items.Insert(0, new ListItem("All", String.Empty));

                // bind users datagrid
                IDataProvider data = DataProviderFactory.CreateInstance();
                DataTable dt = data.GetPMTUsers();

                // filter by selted role
                PMTUserRole role = Role;
                string filter;
                if (Enum.IsDefined(typeof(PMTUserRole), role))
                {
                    filter = String.Format("role={0} and enabled=1", (int)role);
                    ddlRoles.Items.FindByValue(role.ToString("d")).Selected = true; ;
                }
                else
                {
                    filter = "enabled=1";
                }

                dt.DefaultView.RowFilter = filter;

                UserDataGrid.DataSource = dt;
                UserDataGrid.DataBind();
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
            UserDataGrid.ItemDataBound += new DataGridItemEventHandler(UserDataGrid_ItemDataBound);
        }
        #endregion

        private void UserDataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Cells[e.Item.Cells.Count - 1].Text = Enum.GetName(typeof(PMTUserRole), Convert.ToInt32(e.Item.Cells[e.Item.Cells.Count - 1].Text));
            }
        }

        #region QueryString Properties
        protected PMTUserRole Role
        {
            get
            {
                string s = Request["role"];

                if (s == null)
                    return (PMTUserRole)(-1);
                else
                    return (PMTUserRole)Enum.Parse(typeof(PMTUserRole), s);
            }
        }
        #endregion

        protected void ddlRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            string val = ddl.SelectedValue;

            string page = "Users.aspx";

            if (val != String.Empty)
            {
                page = String.Format(page+"?role={0}", val);
            }

            Response.Redirect(page);
        }
    }
}
