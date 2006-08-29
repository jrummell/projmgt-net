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
	/// Summary description for users.
	/// </summary>
	public class Users : System.Web.UI.Page
	{
    protected System.Web.UI.WebControls.DataGrid UserDataGrid;
  
		private void Page_Load(object sender, System.EventArgs e)
		{
      // Put user code to initialize the page here
      if(!Page.IsPostBack)
      {
        //fill the datagrid with wannabe users
        DBDriver myDB=new DBDriver();
        myDB.Query="select u.id id, u.username username, u.security security, p.firstname first, p.lastname last from users u, person p where p.id=u.id;";
        //initialize the dataset
        DataSet ds=new DataSet();
        //initialize the data adapter
        //fill the dataset
        myDB.createAdapter().Fill(ds);
        //fill the display grid
        UserDataGrid.DataSource=ds;
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
      this.Load += new System.EventHandler(this.Page_Load);

    }
		#endregion
	}
}
