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
    public class Users : Page
    {
        protected DataGrid UserDataGrid;
  
        private void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
            if(!Page.IsPostBack)
            {
                IDataProvider data = DataProviderFactory.CreateInstance();
                UserDataGrid.DataSource = data.GetPMTUsers();
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
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion

        private void UserDataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Cells[e.Item.Cells.Count-1].Text = Enum.GetName(typeof(PMTUserRole), Convert.ToInt32(e.Item.Cells[e.Item.Cells.Count-1].Text));
            }
        }
    }
}
