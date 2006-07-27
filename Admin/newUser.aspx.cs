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
	/// Summary description for newUser.
	/// </summary>
	public class NewUser : System.Web.UI.Page
	{
    protected System.Web.UI.WebControls.Label Label1;
    protected System.Web.UI.WebControls.DataGrid NewUserDataGrid;
    private DataSet ds;

    private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
      if(!Page.IsPostBack)
      {
        //fill the datagrid with wannabe users
        DBDriver myDB=new DBDriver();
        myDB.Query="select u.id id, u.username usr, u.security security, p.firstname first, p.lastname last, p.email email from newUsers u, person p where p.id=u.id;";
        //initialize the dataset
        ds=new DataSet();
        //initialize the data adapter
        //fill the dataset
        myDB.createAdapter().Fill(ds);
        //fill the display grid
        NewUserDataGrid.DataSource=ds;
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
      this.NewUserDataGrid.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.NewUserDataGrid_DeleteCommand);
      this.Load += new System.EventHandler(this.Page_Load);

    }
		#endregion

    private void NewUserDataGrid_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
      string delID=(this.NewUserDataGrid.Items[e.Item.ItemIndex].Cells[0].Text);
      PMT.User.declineNewUser(delID);
      Response.Redirect(Request.Url.AbsolutePath);
    }
	}
}
