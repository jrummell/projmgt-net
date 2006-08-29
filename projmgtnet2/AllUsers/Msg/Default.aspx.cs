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

namespace PMT.AllUsers.Msg
{
    /// <summary>
    /// Summary description for Messages.
    /// </summary>
    public class Messages : Page
    {
        protected ValidationSummary ComposeValidationSummary;
        protected Panel MessagesPanel;
        protected DataGrid MessagesDataGrid;
    
        private void Page_Load(object sender, System.EventArgs e)
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
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void BindGrid()
        {
            IDataProvider data = DataProviderFactory.CreateInstance();
            MessagesDataGrid.DataSource = data.GetReceivedMessages(UserID);
            MessagesDataGrid.DataBind();
        }

        private void MessagesDataGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int delID = Convert.ToInt32(e.Item.Cells[0].Text);
            IDataProvider data = DataProviderFactory.CreateInstance();
            data.DeleteMessage(delID, UserID, null); 
            BindGrid();
        }

        private int UserID
        {
            get 
            {
                int user = 0;
                try
                {
                    user = Convert.ToInt32(Request.Cookies["user"]["id"]);
                }
                catch {}
                return user;
            }
        }
    }
}