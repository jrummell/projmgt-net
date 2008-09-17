using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMT.BLL;

namespace PMT.Web.Admin
{
    public partial class NewUser : Page
    {
        private readonly UserService users = new UserService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void NewUserDataGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string delID = (NewUserDataGrid.Items[e.Item.ItemIndex].Cells[0].Text);
            users.Delete(Convert.ToInt32(delID));
            BindData();
        }

        protected void cbEnabled_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox) sender;
            string id = ((DataGridItem) cb.Parent.Parent).Cells[0].Text;
            users.Enable(Convert.ToInt32(id), cb.Checked);
            BindData();
        }

        private void BindData()
        {
            //fill the datagrid with wannabe users
            NewUserDataGrid.DataSource = users.GetByEnabled(false);
            NewUserDataGrid.DataBind();
        }

        #region Web Form Designer generated code

        protected override void OnInit(EventArgs e)
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
            this.NewUserDataGrid.DeleteCommand +=
                new System.Web.UI.WebControls.DataGridCommandEventHandler(this.NewUserDataGrid_DeleteCommand);
        }

        #endregion
    }
}