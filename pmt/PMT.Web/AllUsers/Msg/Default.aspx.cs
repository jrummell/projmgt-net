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
using PMT.Configuration;
using PMTComponents;
using PMTDataProvider;

namespace PMT.AllUsers.Msg
{
    /// <summary>
    /// Summary description for Messages.
    /// </summary>
    public partial class Messages : Page
    {
        protected ValidationSummary ComposeValidationSummary;
    
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindGrid();
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
            this.MessagesDataGrid.DeleteCommand += new DataGridCommandEventHandler(this.MessagesDataGrid_DeleteCommand);
            this.MessagesDataGrid.ItemDataBound += new DataGridItemEventHandler(MessagesDataGrid_ItemDataBound);

        }

        void MessagesDataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem item = e.Item;
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                // set unread messages to bold
                DataRowView drv = (DataRowView)item.DataItem;
                if ((ushort)drv["opened"] != 1)
                {
                    for (int i = 0; i < item.Cells.Count - 1; i++)
                        item.Cells[i].Font.Bold = true;
                }
            }
        }
        #endregion

        private void BindGrid()
        {
            IDataProvider data = DataProviderFactory.CreateInstance();
            MessagesDataGrid.DataSource = data.GetReceivedMessages(Config.LoggedInUserID);
            MessagesDataGrid.DataBind();
        }

        private void MessagesDataGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int delID = Convert.ToInt32(e.Item.Cells[0].Text);
            IDataProvider data = DataProviderFactory.CreateInstance();
            data.DeleteMessage(delID, Config.LoggedInUserID, null); 
            BindGrid();
        }
    }
}