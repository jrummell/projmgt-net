using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using PMT.Configuration;
using PMTComponents;
using PMTDataProvider;

namespace PMT.PM
{
    public partial class Assign : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // bind task threshold drop down list
                for (int i=1; i<=10; i++)
                    ddlTaskThreshold.Items.Add(i.ToString());
                
                ddlTaskThreshold.Items.Add(new ListItem(">10", "11"));
                ddlTaskThreshold.SelectedIndex = 4;

                BindGrids();
            }
        }

        private void BindGrids()
        {
            IDataProvider data = DataProviderFactory.CreateInstance();

            dgAssignments.DataSource = data.GetTaskAssignments(Config.LoggedInUserID);
            dgAssignments.DataBind();

            dgAvailableDevs.DataSource = data.GetAvailableDevelopers(Convert.ToInt32(ddlTaskThreshold.SelectedValue));
            dgAvailableDevs.DataBind();
        }

        #region dg ItemDataBound
        private void dgAvailableDevs_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
            {
                // display Comp Level description
                CompLevel level = (CompLevel)Convert.ToInt32(e.Item.Cells[3].Text);
                e.Item.Cells[3].Text = level.ToString();
            }
            
            if (e.Item.ItemType == ListItemType.EditItem)
            {
                // bind unassigned tasks ddl
                IDataProvider data = DataProviderFactory.CreateInstance();
                DataTable dt = data.GetTasks();
                DataView dv = dt.DefaultView;
                dv.RowFilter = "status=0";

                DropDownList ddl = e.Item.Cells[4].FindControl("ddlTasks") as DropDownList;
                ddl.DataSource = dv;
                ddl.DataTextField = "name";
                ddl.DataValueField = "id";
                ddl.DataBind();

                if (ddl.Items.Count == 0)
                {
                    e.Item.Cells[4].Text = "[no unassigned tasks]";
                    dg.UpdateCommand -= new DataGridCommandEventHandler(this.dgAvailableDevs_UpdateCommand);
                }
            }
        }

        private void dgAssignments_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // show status description
                TaskStatus status = TaskStatus.Unassigned;
                try
                {
                    status = (TaskStatus)Convert.ToInt32(e.Item.Cells[5].Text);
                }
                catch { }
                e.Item.Cells[5].Text = status.ToString();

                DateTime end = DateTime.MinValue;
                try
                {
                    Convert.ToDateTime(e.Item.Cells[7].Text);
                }
                catch { }
                if (end == DateTime.MinValue)
                {
                    e.Item.Cells[7].Text = String.Empty;
                }

                // init approve column if visible
                if (dg.Columns[dg.Columns.Count-1].Visible)
                {
                    CheckBox cb = e.Item.Cells[e.Item.Cells.Count-1].Controls[1] as CheckBox;
                   
                    if (status == TaskStatus.Approved)
                    {
                        cb.Checked = true;
                        cb.Enabled = false;
                    }
                    else if (status == TaskStatus.Complete)
                    {
                        cb.Checked = false;
                        cb.Enabled = true;
                    }
                    else 
                    {
                        cb.Checked = false;
                        cb.Enabled = false;
                    }
                }
            }
        }
        #endregion

        void dgAvailableDevs_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            DataGrid dg = source as DataGrid;
            dg.EditItemIndex = -1;
            dg.Columns[dg.Columns.Count - 2].Visible = false;
            BindGrids();
        }

        void dgAvailableDevs_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            DropDownList ddl = e.Item.Cells[4].FindControl("ddlTasks") as DropDownList;
            
            if (ddl.Items.Count > 0)
            {
                // assign the task
                int devID = Convert.ToInt32(e.Item.Cells[0].Text);
                int taskID = Convert.ToInt32(ddl.SelectedValue);
                IDataProvider data = DataProviderFactory.CreateInstance();
                data.AssignTask(taskID, devID, new TransactionFailedHandler(this.TransactionFailed));
            }
            else
            {
                ddl.Visible = false;
            }

            DataGrid dg = source as DataGrid;
            dg.EditItemIndex = -1;
            dg.Columns[dg.Columns.Count - 2].Visible = false;
            BindGrids();
        }

        private void dgAvailableDevs_EditCommand(object source, DataGridCommandEventArgs e)
        {
            DataGrid dg = source as DataGrid;
            dg.EditItemIndex = e.Item.ItemIndex;
            dg.Columns[dg.Columns.Count - 2].Visible = true;
            BindGrids();
        }

        private void ddlTaskThreshold_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrids();
        }

        #region Button Events
        private void Username_Click(object source, DataGridCommandEventArgs e)
        {
            //if (TaskID == -1)
            //    return;

            //int devID = Convert.ToInt32(e.Item.Cells[0].Text);
            //IDataProvider data = DataProviderFactory.CreateInstance();
            //data.AssignDeveloper(devID, TaskID, new TransactionFailedHandler(this.TransactionFailed));
            //BindGrids();
        }

        private void UpdateButton_Click(object sender, System.EventArgs e)
        {
            // show the complete column
            UpdateButton.Enabled = false;
            CommitButton.Enabled = true;
            CancelButton.Enabled = true;
            dgAssignments.Columns[dgAssignments.Columns.Count-1].Visible = true;
            BindGrids();
        }

        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            dgAssignments.Columns[dgAssignments.Columns.Count-1].Visible = false;
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
                    int id = Convert.ToInt32(item.Cells[1].Text);
                    TaskStatus status = cb.Checked ? TaskStatus.Approved : TaskStatus.Complete;
                    IDataProvider data = DataProviderFactory.CreateInstance();
                    data.UpdateTaskStatus(id, status, new TransactionFailedHandler(this.TransactionFailed));
                }
            }
            BindGrids();
        }
        #endregion

        private void TransactionFailed(Exception ex)
        {
            ErrorLabel.Text = ex.Message;
        }

        #region Properties
        //public int TaskID
        //{
        //    get 
        //    {
        //        int id = -1;
        //        try
        //        {
        //            id = Convert.ToInt32(Request["taskID"]);
        //        }
        //        catch { }
        //        return id;
        //    }
        //}
        #endregion

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
            ddlTaskThreshold.SelectedIndexChanged += new EventHandler(ddlTaskThreshold_SelectedIndexChanged);

            dgAvailableDevs.EditCommand += new DataGridCommandEventHandler(dgAvailableDevs_EditCommand);
            dgAvailableDevs.UpdateCommand += new DataGridCommandEventHandler(dgAvailableDevs_UpdateCommand);
            dgAvailableDevs.CancelCommand += new DataGridCommandEventHandler(dgAvailableDevs_CancelCommand);
            dgAvailableDevs.ItemDataBound += new DataGridItemEventHandler(dgAvailableDevs_ItemDataBound);
            
            dgAssignments.ItemDataBound += new DataGridItemEventHandler(dgAssignments_ItemDataBound);

            UpdateButton.Click += new EventHandler(UpdateButton_Click);
            CommitButton.Click += new EventHandler(CommitButton_Click);
            CancelButton.Click += new EventHandler(CancelButton_Click);
        }
        #endregion
    }
}
