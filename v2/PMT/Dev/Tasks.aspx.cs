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

namespace PMT.Dev
{
	/// <summary>
	/// Summary description for DevTasks.
	/// </summary>
	public class Tasks : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.DataGrid DataGrid1;
        protected System.Web.UI.WebControls.Button UpdateButton;
        protected System.Web.UI.WebControls.Button CancelButton;
        protected System.Web.UI.WebControls.Button CommitButton;
	
        private void Page_Load(object sender, System.EventArgs e)
        {
//            //initialize the DB object
//            DBDriver myDB=new DBDriver();
//            //set the appropriate SQL query
//			myDB.Query = "select t.ID as taskID, t.name as name, m.name as moduleName, p.name as projectName,\n"
//					   + "t.actEndDate as actEndDate, t.complete as complete, a.dateAss as dateAss, a.devID, a.taskID\n"
//					   + "from tasks t, assignments a, modules m, projects p\n" 
//					   + "where t.ID = a.taskID and a.devID = @devID\n"
//                       + "and t.moduleID = m.ID\n"
//                       + "and m.projectID = p.ID\n"
//                       + "order by p.name, m.name, t.name;";
//            myDB.addParam("@devID", Request.Cookies["user"]["id"]);					  
//
//            //initialize the dataset
//            DataSet ds=new DataSet();
//            //initialize the data adapter
//            //fill the dataset;this is updated
//            myDB.createAdapter().Fill(ds);
//            //fill the display grid
//            DataGrid1.DataSource=ds;
//            if (!Page.IsPostBack)
//                DataGrid1.DataBind();
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
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            this.CommitButton.Click += new System.EventHandler(this.CommitButton_Click);
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void UpdateButton_Click(object sender, System.EventArgs e)
        {
            // show the complete column
            UpdateButton.Enabled = false;
            CommitButton.Enabled = true;
            CancelButton.Enabled = true;
            DataGrid1.Columns[6].Visible = true;

            // set check boxes to checked, not checked or checked and disabled
            foreach (DataGridItem item in DataGrid1.Items)
            {
                CheckBox cb = (CheckBox)item.FindControl("CompleteCheckBox");
                if (item.Cells[7].Text.Equals(TaskStatus.Approved.ToString()))
                {
                    cb.Checked = true;
                    cb.Enabled = false;
                }
                if (item.Cells[7].Text.Equals(TaskStatus.Complete.ToString()))
                {
                    cb.Checked = true;
                }
            }
        }

        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            DataGrid1.Columns[6].Visible = false;
            UpdateButton.Enabled = true;
            CommitButton.Enabled = false;
            CancelButton.Enabled = false;
        }

        private void CommitButton_Click(object sender, System.EventArgs e)
        {
            /*
            DBDriver db = new DBDriver();

            foreach (DataGridItem itm in DataGrid1.Items)
            {
                CheckBox cb = (CheckBox)itm.FindControl("CompleteCheckBox");
                if(cb.Enabled)
                {
                    db.Query = "update tasks set complete=@complete\n"
                        + "where id=@id;";
                    db.addParam("@complete", cb.Checked?TaskStatus.Complete:TaskStatus.INPROGRESS);
                    db.addParam("@id", itm.Cells[0].Text);
                    db.nonQuery();
                }
            }
            Server.Transfer(Request.Url.AbsolutePath);
            */
        }
	}
}
