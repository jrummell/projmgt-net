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
using PMT.BLL;

namespace PMT.Admin
{
    public partial class NewUser : Page
    {
        UserData users;

        public NewUser()
        {
            users = new UserData();
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
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
            this.NewUserDataGrid.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.NewUserDataGrid_DeleteCommand);
        }
        #endregion

        private void NewUserDataGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string delID = (NewUserDataGrid.Items[e.Item.ItemIndex].Cells[0].Text);
            users.DeleteUser(Convert.ToInt32(delID));
            BindData();
        }

        protected void cbEnabled_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            string id = ((DataGridItem)cb.Parent.Parent).Cells[0].Text;
            users.UpdateEnabled(Convert.ToInt32(id), cb.Checked);
            BindData();
        }

        private void BindData()
        {
            //fill the datagrid with wannabe users
            NewUserDataGrid.DataSource = users.GetUsers(false);
            NewUserDataGrid.DataBind();
        }
    }
}