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
	/// View developer assignments or assign a task.
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
        protected DropDownList ddlTaskThreshold;
        protected DataGrid dgAvailableDevs;
        protected DataGrid dgAssignments;

	
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (TaskID != -1)
                AvailDevLabel.Text = "Choose Developer to be assigned to Task " + TaskID;

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
            
            dgAssignments.DataSource = data.GetDeveloperAssignments();
            dgAssignments.DataBind();

            dgAvailableDevs.DataSource = data.GetAvailableDevelopers(Convert.ToInt32(ddlTaskThreshold.SelectedValue));
            dgAvailableDevs.DataBind();
        }

        #region dg ItemDataBound
        private void dgAvailableDevs_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // display Comp Level description
                CompLevel level = (CompLevel)Convert.ToInt32(e.Item.Cells[3].Text);
                e.Item.Cells[3].Text = level.ToString();
            }
        }

        private void dgAssignments_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // show status description
                TaskStatus status = (TaskStatus)Convert.ToInt32(e.Item.Cells[5].Text);
                e.Item.Cells[5].Text = status.ToString();

                DateTime date = Convert.ToDateTime(e.Item.Cells[7].Text);
                if (date == DateTime.MinValue)
                {
                    e.Item.Cells[7].Text = String.Empty;
                }
                date = Convert.ToDateTime(e.Item.Cells[6].Text);
                if (date == DateTime.MinValue)
                {
                    e.Item.Cells[6].Text = String.Empty;
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

        private void ddlTaskThreshold_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrids();
        }

        #region Button Events
        private void Username_Click(object source, DataGridCommandEventArgs e)
        {
            if (TaskID == -1)
                return;

            int devID = Convert.ToInt32(e.Item.Cells[0].Text);
            IDataProvider data = DataProviderFactory.CreateInstance();
            data.AssignDeveloper(devID, TaskID, new TransactionFailedHandler(this.TransactionFailed));
            BindGrids();
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
        public int TaskID
        {
            get 
            {
                if (Request["taskID"] == null)
                    return -1;

                int id = -1;
                try
                {
                    id = Convert.ToInt32(Request["taskID"]);  
                }
                catch{}
                return id;
            }
        }
        #endregion

        override protected void OnInit(EventArgs e)
        {
            ddlTaskThreshold.SelectedIndexChanged += new EventHandler(ddlTaskThreshold_SelectedIndexChanged);
            dgAvailableDevs.ItemDataBound += new DataGridItemEventHandler(dgAvailableDevs_ItemDataBound);
            dgAssignments.ItemDataBound += new DataGridItemEventHandler(dgAssignments_ItemDataBound);
            dgAvailableDevs.ItemCommand += new DataGridCommandEventHandler(Username_Click);
            UpdateButton.Click += new EventHandler(UpdateButton_Click);
            CommitButton.Click += new EventHandler(CommitButton_Click);
            CancelButton.Click += new EventHandler(CancelButton_Click);
            Load += new System.EventHandler(Page_Load);
            base.OnInit(e);
        }
    }
}
