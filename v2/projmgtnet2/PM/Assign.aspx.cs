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

namespace PMT.PM
{
	/// <summary>
	/// Summary description for Assign.
	/// </summary>
	public class Assign : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.Label AvailDevLabel;
        protected System.Web.UI.WebControls.DataGrid DataGrid2;
        protected System.Web.UI.WebControls.Panel AvailableDevPanel;
        protected System.Web.UI.WebControls.Panel AssignmentsPanel;
		protected System.Web.UI.WebControls.Button UpdateButton;
		protected System.Web.UI.WebControls.Button CommitButton;
		protected System.Web.UI.WebControls.Button CancelButton;
        protected System.Web.UI.WebControls.Label ErrorLabel;
		protected System.Web.UI.WebControls.TextBox ThresholdTextBox;
		protected System.Web.UI.WebControls.RegularExpressionValidator ThreshholdTextBoxRegularExpressionValidator;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
            string taskID = Request["taskID"];
            string error = Request["error"];

            if (error != null)
            {
                //Response.Write("<script type=\"text/javascript\">alert(\""+ error +"\");</script>");
                ErrorLabel.Text = error;
            }

            if (taskID != null)
                AvailDevLabel.Text = "Choose Developer to be assigned to Task " + taskID;

            // fill available developers data grid
			//TODO: FINISH THIS

//			int Threshold = Convert.ToInt32(ThresholdTextBox.Text);

			DBDriver myDB = new DBDriver();
            string s = "select p.ID as ID, p.lastName as lastName, p.firstName as firstName,\n"
                + "u.username as username, c.competence as competence, count(a.devID) as taskCount\n"
                + "from person p, compLevels c, assignments a, users u\n"
                + "where p.ID = u.ID\n"
                + "and u.security = 'Developer'\n"
                + "and p.ID = a.devID\n"
                + "and p.ID = c.ID\n"
                + "group by p.ID, p.lastName, p.firstName, u.userName, c.competence\n"
                + "having count(a.devID) < 10"  // set to 10 for testing
                + "order by p.lastName;";


//				if(Threshold != -1 )
//					s +="having count(a.devID) < @Threshold";
//
//                    s += "order by p.lastName;";

			myDB.Query = s;
//			if( Threshold != -1 )
//				myDB.addParam( "@Threshold", Threshold );

            
			DataSet ds = new DataSet();
			myDB.createAdapter().Fill(ds);
			DataGrid1.DataSource = ds;
			DataGrid1.DataBind();

            // fill assignments data grid
            DBDriver myDB2 = new DBDriver();
            s = "select assignments.taskID as taskID, users.ID as devID, users.username as username, tasks.name as taskName, \n"
				+ "modules.name as moduleName, projects.name as projectName, assignments.dateAss as date, tasks.complete as complete\n"
                + "from assignments, users, tasks, modules, projects\n"
                + "where users.ID = assignments.devID\n"
                + "and users.security = 'Developer'\n"
                + "and assignments.taskID = tasks.ID\n"
				+ "and tasks.moduleID = modules.ID\n"
				+ "and modules.projectID = projects.ID\n"
                + "and projects.managerID = @mgrID \n"
				+ "order by projects.name, modules.name, tasks.name, users.username;";

            myDB2.Query = s;
            myDB2.addParam("@mgrID", Request.Cookies["user"]["id"]);
            DataSet ads = new DataSet();
            myDB2.createAdapter().Fill(ads);
            DataGrid2.DataSource = ads;
			if( !Page.IsPostBack )
                DataGrid2.DataBind();

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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Username_Click);
			this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
			this.CommitButton.Click += new System.EventHandler(this.CommitButton_Click);
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


        private void Username_Click(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            string taskID = Request["taskID"];

            // get the developer ID
            string devID = DataGrid1.Items[e.Item.ItemIndex].Cells[0].Text;

            // if the taskID is not defined, goto Dev Profile
            if (taskID == null)
            {
                Response.Redirect("ViewDevProfile.aspx?devID="+devID);
                return;
            }

            // assign the developer to the selected task
            Task task = new Task(taskID);
            if ( task.DeveloperID == null )
            {
                task.assignDeveloper(devID);
                Response.Redirect(Request.Url.AbsolutePath);
            }
            else
            {
                string error = "'" + task.Name + "' has already been assigned.";
                Response.Redirect(Request.Url.AbsolutePath+"?error="+error);
            }
        }

		private void UpdateButton_Click(object sender, System.EventArgs e)
		{
			// show the complete column
			UpdateButton.Enabled = false;
			CommitButton.Enabled = true;
			CancelButton.Enabled = true;
			DataGrid2.Columns[8].Visible = true;

			// set check boxes to checked, not checked or checked and disabled
			foreach (DataGridItem item in DataGrid2.Items)
			{
				CheckBox cb = (CheckBox)item.FindControl("ApproveCheckBox");
				if (item.Cells[7].Text.Equals(TaskStatus.APPROVED))
				{
					cb.Checked = true;
					cb.Enabled = true;
				}
				if (item.Cells[7].Text.Equals(TaskStatus.COMPLETE))
				{
					cb.Checked = false;
					cb.Enabled = true;
				}
				if (item.Cells[7].Text.Equals(TaskStatus.INPROGRESS) )
				{
					cb.Checked = false;
					cb.Enabled = false;
				}
			}
		}

		private void CancelButton_Click(object sender, System.EventArgs e)
		{
			DataGrid2.Columns[8].Visible = false;
			UpdateButton.Enabled = true;
			CommitButton.Enabled = false;
			CancelButton.Enabled = false;
		}

		private void CommitButton_Click(object sender, System.EventArgs e)
		{
			DBDriver db = new DBDriver();

			foreach (DataGridItem itm in DataGrid2.Items)
			{
				CheckBox cb = (CheckBox)itm.FindControl("ApproveCheckBox");
				if(cb.Enabled)
				{
					db.Query = 
                        "update tasks\n"
                        + "set complete=@complete, actEndDate=@date\n"
						+ "where id=@id;";
					db.addParam("@complete", cb.Checked?TaskStatus.APPROVED:TaskStatus.COMPLETE);
                    db.addParam("@date", cb.Checked?Convert.ToString(DateTime.Now):"");
					db.addParam("@id", itm.Cells[1].Text);
					db.nonQuery();
				}
			}
			Server.Transfer(Request.Url.AbsolutePath);
		}
	}
}
