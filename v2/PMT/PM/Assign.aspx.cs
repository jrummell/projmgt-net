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

namespace PMT.PM
{
	/// <summary>
	/// Summary description for Assign.
	/// </summary>
    public class Assign : Page
    {
        protected Label AvailDevLabel;
        protected Panel AvailableDevPanel;
        protected Panel AssignmentsPanel;
        protected Button UpdateButton;
        protected Button CommitButton;
        protected Button CancelButton;
        protected Label ErrorLabel;
        protected TextBox ThresholdTextBox;
        protected DataGrid dgAvailableDevs;
        protected DataGrid dgAssignments;
        protected RegularExpressionValidator ThreshholdTextBoxRegularExpressionValidator;

	
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (TaskID != -1)
                AvailDevLabel.Text = "Choose Developer to be assigned to Task " + TaskID;

            if (!IsPostBack)
                BindData();

            // fill available developers data grid
            //TODO: FINISH THIS

            //			int Threshold = Convert.ToInt32(ThresholdTextBox.Text);

            /*
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
                */

        }

        private void BindData()
        {
            IDataProvider data = DataProviderFactory.CreateInstance();
            
            dgAssignments.DataSource = data.GetDeveloperAssignments();
            dgAssignments.DataBind();

            //dgAvailableDevs.DataSource = data.GetAvailableDevelopers(numTasks);
            //dgAvailableDevs.DataBind();
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
            this.dgAvailableDevs.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Username_Click);
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            this.CommitButton.Click += new System.EventHandler(this.CommitButton_Click);
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion


        private void Username_Click(object source, DataGridCommandEventArgs e)
        {
            /*
            IDataProvider data = DataProviderFactory.CreateInstance();
                // get the developer ID
                //string devID = DataGrid1.Items[e.Item.ItemIndex].Cells[0].Text;

            // if the taskID is not defined, goto Dev Profile
            if (TaskID == -1)
            {
                //Response.Redirect("ViewDevProfile.aspx?devID="+devID);
                return;
            }

            // assign the developer to the selected task
            Task task = data.GetTask(TaskID);
            //if ( task.DeveloperID == null )
            {
                data.AssignDeveloper(devID, TaskID, new TransactionFailedHandler(this.TransactionFailed));
            }
//            else
//            {
//                ErrorLabel.Text = "'" + task.Name + "' has already been assigned.";
//                //Response.Redirect(Request.Url.AbsolutePath+"?error="+error);
//            }
            */
        }

        private void UpdateButton_Click(object sender, System.EventArgs e)
        {
            // show the complete column
            UpdateButton.Enabled = false;
            CommitButton.Enabled = true;
            CancelButton.Enabled = true;
            dgAssignments.Columns[8].Visible = true;

            // set check boxes to checked, not checked or checked and disabled
            foreach (DataGridItem item in dgAssignments.Items)
            {
                CheckBox cb = (CheckBox)item.FindControl("ApproveCheckBox");
                if (item.Cells[7].Text.Equals(TaskStatus.Approved))
                {
                    cb.Checked = true;
                    cb.Enabled = true;
                }
                if (item.Cells[7].Text.Equals(TaskStatus.Complete))
                {
                    cb.Checked = false;
                    cb.Enabled = true;
                }
                if (item.Cells[7].Text.Equals(TaskStatus.InProgress) )
                {
                    cb.Checked = false;
                    cb.Enabled = false;
                }
            }
        }

        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            dgAssignments.Columns[8].Visible = false;
            UpdateButton.Enabled = true;
            CommitButton.Enabled = false;
            CancelButton.Enabled = false;
        }

        private void CommitButton_Click(object sender, System.EventArgs e)
        {
            foreach (DataGridItem item in dgAssignments.Items)
            {
                CheckBox cb = (CheckBox)item.FindControl("ApproveCheckBox");
                if(cb.Enabled)
                {
                    IDataProvider data = DataProviderFactory.CreateInstance();
                    data.ApproveTask(Convert.ToInt32(item.Cells[1].Text), new TransactionFailedHandler(this.TransactionFailed));
                }
            }
            this.BindData();
        }

        private void TransactionFailed(Exception ex)
        {
            ErrorLabel.Text = ex.Message;
        }

        #region Properties
        public int TaskID
        {
            get 
            {
                try
                {
                    return Convert.ToInt32(Request["taskID"]);  
                }
                catch
                {
                    return -1;
                }
            }
        }
        #endregion
	}
}
