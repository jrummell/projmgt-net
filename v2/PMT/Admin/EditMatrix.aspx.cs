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
    public partial class EditMatrix : Page
    {
  
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //load the current competency matrix from the database
            if(!this.IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            IDataProvider data = DataProviderFactory.CreateInstance();
            compMatrixGrid.DataSource = data.GetCompMatrix();
            compMatrixGrid.DataBind();
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
            compMatrixGrid.ItemDataBound += new DataGridItemEventHandler(compMatrixGrid_ItemDataBound);
            compMatrixGrid.CancelCommand += new DataGridCommandEventHandler(this.compMatrixGrid_CancelCommand);
            compMatrixGrid.EditCommand += new DataGridCommandEventHandler(this.compMatrixGrid_EditCommand);
            compMatrixGrid.UpdateCommand += new DataGridCommandEventHandler(this.compMatrixGrid_UpdateCommand);

        }
        #endregion

        private void compMatrixGrid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            //edit the selected row
            compMatrixGrid.EditItemIndex = e.Item.ItemIndex;
            BindGrid();
        }

        private void compMatrixGrid_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            //cancel editing of the selected row
            compMatrixGrid.EditItemIndex = -1;
            BindGrid();
        }

        private void compMatrixGrid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            //retrieve the new values from the datagrid
            TextBox tb;

            tb = (TextBox)e.Item.Cells[1].Controls[0];
            double low = Convert.ToDouble(tb.Text);

            tb = (TextBox)e.Item.Cells[2].Controls[0];
            double med = Convert.ToDouble(tb.Text);

            tb = (TextBox)e.Item.Cells[3].Controls[0];
            double high = Convert.ToDouble(tb.Text);

            CompLevel level = (CompLevel)Convert.ToInt32(e.Item.Cells[0].Text);

            //store new values to DB
            IDataProvider data = DataProviderFactory.CreateInstance();
            if (data.UpdateCompMatrix(level, low, med, high, new TransactionFailedHandler(this.TransactionFailed)))
            {
                //make sure nothing is being edited, and reload the page
                compMatrixGrid.EditItemIndex = -1;
                BindGrid();
            }
        }

        private void TransactionFailed(Exception ex)
        {
            ResultLabel.Text = ex.Message;
        }

        private void compMatrixGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem 
                || e.Item.ItemType == ListItemType.EditItem)
            {
                e.Item.Cells[0].Text = Enum.GetName(typeof(CompLevel), Convert.ToInt32(e.Item.Cells[0].Text));
            }
        }
    }
}