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

namespace PMT.Admin
{
  /// <summary>
  /// Summary description for editMatrix.
  /// </summary>
  public class EditMatrix : System.Web.UI.Page
  {
    protected System.Web.UI.WebControls.DataGrid compMatrixGrid;
  
    private void Page_Load(object sender, System.EventArgs e)
    {
      // Put user code to initialize the page here
      //load the current competency matrix from the database
      DBDriver myDB=new DBDriver();
      myDB.Query="select * from compMatrix;";
      DataSet ds=new DataSet();
      myDB.createAdapter().Fill(ds);
      this.compMatrixGrid.DataSource=ds;
      if(!this.IsPostBack)
      {
        this.compMatrixGrid.DataBind();
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
      this.compMatrixGrid.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.compMatrixGrid_CancelCommand);
      this.compMatrixGrid.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.compMatrixGrid_EditCommand);
      this.compMatrixGrid.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.compMatrixGrid_UpdateCommand);
      this.Load += new System.EventHandler(this.Page_Load);

    }
    #endregion

    private void compMatrixGrid_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
      //edit the selected row
      this.compMatrixGrid.EditItemIndex=e.Item.ItemIndex;
      this.compMatrixGrid.DataBind();
    }

    private void compMatrixGrid_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
      //cancel editing of the selected row
      this.compMatrixGrid.EditItemIndex=-1;
      this.compMatrixGrid.DataBind();
    }

    private void compMatrixGrid_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
      DBDriver myDB=new DBDriver();
      //retrieve the new values from the datagrid
      TextBox tb;
      tb=(TextBox)e.Item.Cells[1].Controls[0];
      string low=tb.Text;
      tb=(TextBox)e.Item.Cells[2].Controls[0];
      string med=tb.Text;
      tb=(TextBox)e.Item.Cells[3].Controls[0];
      string high=tb.Text;
      string level = e.Item.Cells[0].Text;

      //store new values to DB
      myDB.Query="update compMatrix set lowComplexity=@low, medComplexity=@med, highComplexity=@high where compLevel=@level;";
      myDB.addParam("@low", low);
      myDB.addParam("@med", med);
      myDB.addParam("@high", high);
      myDB.addParam("@level", level);
      myDB.nonQuery();

      //make sure nothing is being edited, and reload the page
      this.compMatrixGrid.EditItemIndex=-1;
      Response.Redirect(Request.Url.AbsolutePath);
    }
  }
}