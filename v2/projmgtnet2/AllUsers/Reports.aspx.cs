using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using PMTComponents;
using PMTDataProvider;

namespace PMT.AllUsers
{
    public class Reports : Page
    {
        protected DropDownList ProjectDropDownList;
        protected Button ViewProjectButton;
        protected DropDownList ModuleDropDownList;
        protected Button ViewModuleButton;
        protected DropDownList TaskDropDownList;
        protected Button ViewTaskButton;
        protected Label ModuleLabel;
        protected Label TaskLabel;
        protected Panel ReportPanel;
        protected Label ProjectLabel;
        protected string role;
        protected DataGrid DisplayGrid;
        protected PlaceHolder phReport;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here

            if (!this.IsPostBack)
            {
                if (UserRole.Equals(PMTUserRole.Manager))
                {
                    IDataProvider data = DataProvider.CreateInstance();
                    //fill the dropdown list
                    ProjectDropDownList.DataSource = data.GetProjects();
                    ProjectDropDownList.DataTextField="name";
                    ProjectDropDownList.DataValueField="ID";
                    ProjectDropDownList.DataBind();
                    ProjectDropDownList.Items.Insert(0,"");

                    enableModuleControls(false);
                    enableTaskControls(false);
                }
                else if (UserRole.Equals(PMTUserRole.Developer))
                {
                    // get all tasks assigned to a developer
                    DBDriver db = new DBDriver();
                    db.Query = "select t.id, t.name from assignments a, tasks t \n"
                        +"where a.devID = @devID and t.id = a.taskID";
                    db.addParam("@devID", UserID);
                    
                    DataSet ds = new DataSet();
                    db.createAdapter().Fill(ds);

                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];

                    // display tasks in the drop down list
                    TaskDropDownList.DataSource=dt.DefaultView;
                    TaskDropDownList.DataTextField="name";
                    TaskDropDownList.DataValueField="id";
                    TaskDropDownList.DataBind();
                    TaskDropDownList.Items.Insert(0,"");

                    enableModuleControls(false);
                    enableProjectControls(false);
                }
                else if (UserRole.Equals(PMTUserRole.Client))
                {
                    // get all projectes assigned to a client
                    DBDriver db = new DBDriver();
                    db.Query = 
                        "select * from projects p, clients c\n"
                        + "where p.id = c.projectID\n"
                        + "and c.clientID = @id;";
                    db.addParam("@id", UserID);

                    DataSet ds = new DataSet();
                    db.createAdapter().Fill(ds); 

                    //create a datatable to fill the dropdown list from
                    DataTable dt=new DataTable();
                    dt=ds.Tables[0];
                    //fill the dropdown list
                    ProjectDropDownList.DataSource=dt.DefaultView;
                    ProjectDropDownList.DataTextField="name";
                    ProjectDropDownList.DataValueField="ID";
                    ProjectDropDownList.DataBind();
                    ProjectDropDownList.Items.Insert(0,"");

                    enableModuleControls(false);
                    enableTaskControls(false);
                }
            }

            ReportPanel.Visible = false;
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
            this.ProjectDropDownList.SelectedIndexChanged += new System.EventHandler(this.ProjectDropDownList_SelectedIndexChanged);
            this.ViewProjectButton.Click += new System.EventHandler(this.ViewReportButton_Click);
            this.ModuleDropDownList.SelectedIndexChanged += new System.EventHandler(this.ModuleDropDownList_SelectedIndexChanged);
            this.ViewModuleButton.Click += new System.EventHandler(this.ViewReportButton_Click);
            this.TaskDropDownList.SelectedIndexChanged += new System.EventHandler(this.TaskDropDownList_SelectedIndexChanged);
            this.ViewTaskButton.Click += new System.EventHandler(this.ViewReportButton_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        /// <summary>
        /// Handle View Report button clicks
        /// </summary>
        private void ViewReportButton_Click(object sender, System.EventArgs e)
        {
            string buttonID = ((Button)sender).ID;

            if (!Page.IsValid)
                return;

            IDataProvider data = DataProvider.CreateInstance();
            //DataTable dt = new DataTable();

            if ( buttonID.Equals( "ViewProjectButton" ) )
            {
                Project project = data.GetProject(Convert.ToInt32(ProjectDropDownList.SelectedValue));

                ModuleLabel.Visible = false;
                TaskLabel.Visible = false;

                Label lbl = new Label();
                lbl.Text = project.Name + " " + project.Description;
                phReport.Controls.Add(lbl);
            }
            else if ( buttonID.Equals( "ViewModuleButton" ) )
            {
                /*
                dt = Module.getByID(ModuleDropDownList.SelectedValue);

                ModuleLabel.Text = ModuleDropDownList.SelectedItem.Text;
                ModuleLabel.Visible = true;
                TaskLabel.Visible = false;

                DisplayGrid.DataSource = ds;
                DisplayGrid.DataBind();

                // find percent complete
                Module m = new Module(DisplayGrid.Items[0].Cells[0].Text);
                DisplayGrid.Items[0].Cells[7].Text = m.PercentComplete;

                setReportType(ProjectItem.ItemType.MODULE);
                */
            }
            else //( buttonID.Equals( "ViewTaskButton" ) )
            {
                /*
                dt = Task.getByID(TaskDropDownList.SelectedValue);

                if (!role.Equals(PMTUserRole.Developer))
                {
                    ModuleLabel.Visible = true;
                    ModuleLabel.Text = ModuleDropDownList.SelectedItem.Text;
                }
                TaskLabel.Visible = true;
                TaskLabel.Text = TaskDropDownList.SelectedItem.Text;

                DisplayGrid.DataSource = ds;
                DisplayGrid.DataBind();

                // find percent complete
                Task t = new Task(DisplayGrid.Items[0].Cells[0].Text);
                DisplayGrid.Items[0].Cells[7].Text = t.PercentComplete;

                setReportType(ProjectItem.ItemType.TASK);
                */
            }
            if (!UserRole.Equals(PMTUserRole.Developer))
            {
                ProjectLabel.Text = ProjectDropDownList.SelectedItem.Text;
            }

            ReportPanel.Visible = true;
            DisplayGrid.Visible = true;
        }


        private void ProjectDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            /*
            //create a data set
            DataSet ds = Module.getModulesDataSet(ProjectDropDownList.SelectedValue);

            DataTable dt=new DataTable();
            dt=ds.Tables[0];

            enableProjectControls(true);
            enableModuleControls(true);

            //fill the dropdown list
            ModuleDropDownList.DataSource=dt.DefaultView;
            ModuleDropDownList.DataTextField="name";
            ModuleDropDownList.DataValueField="ID";
            ModuleDropDownList.DataBind();
            ModuleDropDownList.Items.Insert(0,"");

            // disable and clear the task drop down
            enableTaskControls(false);
            if (TaskDropDownList.Items.Count > 0)
                TaskDropDownList.Items.Clear();
                */
        }

        private void ModuleDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            /*
            DataSet ds = Task.getTasksDataSet(ModuleDropDownList.SelectedValue);

            //create a datatable to fill the dropdown list from
            DataTable dt = new DataTable();
            dt=ds.Tables[0];

            enableModuleControls(true);
            enableTaskControls(true);

            //fill the dropdown list
            TaskDropDownList.Enabled = true;
            TaskDropDownList.DataSource=dt.DefaultView;
            TaskDropDownList.DataTextField="name";
            TaskDropDownList.DataValueField="ID";
            TaskDropDownList.DataBind();
            TaskDropDownList.Items.Insert(0,"");
            */
        }

        private void TaskDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            enableTaskControls(true);
        }

        private void setReportType(string type)
        {
            /*
            if (type.Equals(ProjectItem.ItemType.TASK))
                return;

            HyperLinkColumn col = new HyperLinkColumn();
            col.DataTextField = "name";
            col.DataNavigateUrlField = "id";

            // set item type to be displayed
            string item = "";

            if (type.Equals(ProjectItem.ItemType.PROJECT))
                item = ProjectItem.ItemType.MODULE;
            else if(type.Equals(ProjectItem.ItemType.MODULE))
                item = ProjectItem.ItemType.TASK;                

            col.DataNavigateUrlFormatString = Request.ApplicationPath + "/PM/Projects.aspx?item="+item+"&id={0}";
            DisplayGrid.Columns.Remove(DisplayGrid.Columns[1]);
            DisplayGrid.Columns.AddAt(1, col);
            */
        }

        private void enableTaskControls(bool val)
        {
            TaskDropDownList.Enabled = val;

            if (TaskDropDownList.SelectedIndex > 0)
            {
                ViewTaskButton.Enabled = val;
            }
            else
            {
                ViewTaskButton.Enabled = false;
            }
        }

        private void enableModuleControls(bool val)
        {
            ModuleDropDownList.Enabled = val;

            if (ModuleDropDownList.SelectedIndex > 0)
            {
                ViewModuleButton.Enabled = val;
            }
            else
            {
                ViewModuleButton.Enabled = false;
            }
        }

        private void enableProjectControls(bool val)
        {
            ProjectDropDownList.Enabled = val;

            if(ProjectDropDownList.SelectedIndex > 0)
            {
                ViewProjectButton.Enabled = val;
            }
            else
            {
                ViewProjectButton.Enabled = false;
            }
        }

        #region Properties
        public int UserID
        {
            get {   return Convert.ToInt32(Request.Cookies["user"]["id"]);   }
        }
        public PMTUserRole UserRole
        {
            get {   return (PMTUserRole)Enum.Parse(typeof(PMTUserRole), Request.Cookies["user"]["role"]);   }
        }
        #endregion
    }
}
