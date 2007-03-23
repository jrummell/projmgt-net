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
	public partial class Tasks : System.Web.UI.Page
	{
	
        protected void Page_Load(object sender, System.EventArgs e)
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

        protected void UpdateButton_Click(object sender, System.EventArgs e)
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

        protected void CancelButton_Click(object sender, System.EventArgs e)
        {
            DataGrid1.Columns[6].Visible = false;
            UpdateButton.Enabled = true;
            CommitButton.Enabled = false;
            CancelButton.Enabled = false;
        }

        protected void CommitButton_Click(object sender, System.EventArgs e)
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
