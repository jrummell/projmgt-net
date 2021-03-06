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

namespace PMT.Client
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class Projects : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.DataGrid DataGrid1;
        string clientID;
    
		private void Page_Load(object sender, System.EventArgs e)
		{
            clientID = Request.Cookies["user"]["id"];

            if (!Page.IsPostBack)
            {
                // show the projects datagrid
                DBDriver db = new DBDriver();
                db.Query = 
                    "select p.ID as projectID, p.Name as projectName, u.ID as managerID, u.userName as managerName\n"
                    + "from projects p, users u, clients c\n"
                    + "where p.ID = c.projectID\n"
                    + "and u.ID = c.managerID\n"
                    + "and c.clientID = @clientID;";
                db.addParam("@clientID", clientID);

                DataSet ds = new DataSet();

                db.createAdapter().Fill(ds);
            
                DataGrid1.DataSource = ds;
                DataGrid1.DataBind();
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
