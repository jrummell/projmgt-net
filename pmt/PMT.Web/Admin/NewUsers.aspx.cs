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
using PMTComponents;
using PMTDataProvider;

namespace PMT.Admin
{
    /// <summary>
    /// Summary description for newUser.
    /// </summary>
    public partial class NewUser : Page
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
            if(!Page.IsPostBack)
            {
                //fill the datagrid with wannabe users
                IDataProvider data = DataProviderFactory.CreateInstance();
                NewUserDataGrid.DataSource = data.GetEnabledPMTUsers(false);
                NewUserDataGrid.DataBind();
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
            NewUserDataGrid.ItemDataBound += new DataGridItemEventHandler(NewUserDataGrid_ItemDataBound);
            this.NewUserDataGrid.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.NewUserDataGrid_DeleteCommand);

        }
        #endregion

        private void NewUserDataGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string delID = (NewUserDataGrid.Items[e.Item.ItemIndex].Cells[0].Text);
            IDataProvider conn = DataProviderFactory.CreateInstance();
            conn.DeletePMTUser(Convert.ToInt32(delID), null);
            NewUserDataGrid.DataBind();
        }

        private void NewUserDataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Cells[5].Text = Enum.GetName(typeof(PMTUserRole), Convert.ToInt32(e.Item.Cells[5].Text));
            }
        }
    }
}
