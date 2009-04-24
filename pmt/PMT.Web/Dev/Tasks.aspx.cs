using System;
using System.Web.UI;
using PMT.BLL;

namespace PMT.Web.Dev
{
    /// <summary>
    /// Summary description for DevTasks.
    /// </summary>
    public partial class Tasks : Page
    {
        //TODO: finish and test ~/Dev/Tasks.aspx. UpdateButton_Click and CancelButton_Click could be easily handled with javascript (jQuery).

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init"/> event to initialize the page.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            Load += Page_Load;
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TaskService service = new TaskService();
                dgTasks.DataSource = service.GetByUser(Global.LoggedInUser.ID);
                dgTasks.DataBind();
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            //TODO: this can be done with jQuery
            throw new NotImplementedException();
            /*
            // show the complete column
            btnUpdate.Enabled = false;
            btnCommit.Enabled = true;
            btnCancel.Enabled = true;
            dgTasks.Columns[6].Visible = true;

            // set check boxes to checked, not checked or checked and disabled
            foreach (DataGridItem item in dgTasks.Items)
            {
                CheckBox cb = (CheckBox) item.FindControl("CompleteCheckBox");
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
            */
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            //TODO: this can be done with jQuery

            throw new NotImplementedException();
            /*
            dgTasks.Columns[6].Visible = false;
            btnUpdate.Enabled = true;
            btnCommit.Enabled = false;
            btnCancel.Enabled = false;
            */
        }

        protected void CommitButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();

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