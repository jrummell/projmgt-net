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

namespace PMT.PM
{
    public partial class Matrix : Page
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                IDataProvider data = DataProviderFactory.CreateInstance();
                dgCompMatrix.DataSource = data.GetCompMatrix();
                dgCompMatrix.DataBind();
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

        }
        #endregion

        protected void dgCompMatrix_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // set comp level text
                e.Item.Cells[0].Text = Enum.GetName(typeof(CompLevel), Convert.ToInt32(e.Item.Cells[0].Text));
            }
        }
    }
}
