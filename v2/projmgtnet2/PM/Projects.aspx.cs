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

namespace PMT.PM
{
	public class Projects : Page
	{
		protected HyperLink newProjectLink;
        protected Label lblResult;
		protected Panel projectPanel;
        protected HyperLink AddItemHyperLink;
        protected DataGrid DataGrid1;
        protected Label ItemLabel;
        protected string id;
	
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            IDataProvider data = DataProvider.CreateInstance();
            // the project item to display
            ProjectItem item;
            
            //create a data set
            DataTable dt = new DataTable();

            // list all projects assigned to logged in PM
            if (ItemType.Equals(ProjectItemType.Project))
            {
                dt = data.GetManagerProjects(UserID);
                item = null;
            }
                // list all modules in specified project
            else if (ItemType.Equals(ProjectItemType.Module))
            {
                item = data.GetProject(ItemID);
                dt = data.GetProjectModules(item.ID);
            }
                // list all tasks in specified module
            else //if (itemType.Equals(ProjectItemType.TASK))
            {
                item = data.GetModule(ItemID);
                dt = data.GetModuleTasks(item.ID);
                BoundColumn ComplexityColumn = new BoundColumn();
                ComplexityColumn.HeaderText = "Complexity";
                ComplexityColumn.DataField = "complexity";
                ComplexityColumn.ReadOnly = true;
                DataGrid1.Columns.AddAt(3, ComplexityColumn);
            }

            // set the display grid data source
            setDisplayItemType();
            DataGrid1.DataSource = dt;
            DataGrid1.DataBind();

            // set the create/add new item link and item label
            if (item != null)
            {
                AddItemHyperLink.NavigateUrl 
                    = "NewItem.aspx?item=" + ItemType + "&parentID=" + item.ID;
                AddItemHyperLink.Text = "Add a " + ItemType.ToString() + " to " + item.Name;
                ItemLabel.Text = ItemType +"s in " + item.Name;
            }
            else
            {
                AddItemHyperLink.NavigateUrl = String.Format("NewItem.aspx?item={0}", ProjectItemType.Project);
                AddItemHyperLink.Text = "Create a new project";
                ItemLabel.Text = "Your projects";
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
            this.DataGrid1.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.CancelCommand_Clicked);
            this.DataGrid1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.EditButton_Pushed);
            this.DataGrid1.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.UpdateCommand_Pushed);
            this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DeleteButton_Pushed);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        /// <summary>
        /// Delete the clicked row
        /// </summary>
        private void DeleteButton_Pushed(object source, DataGridCommandEventArgs e)
        {
            int delID = Convert.ToInt32(DataGrid1.Items[e.Item.ItemIndex].Cells[0].Text);
            IDataProvider data = DataProvider.CreateInstance();

            if (ItemType.Equals(ProjectItemType.Project))
                data.DeleteProject(delID, new TransactionFailedHandler(this.TransactionFailed));
            else if (ItemType.Equals(ProjectItemType.Module))
                data.DeleteModule(delID, new TransactionFailedHandler(this.TransactionFailed));
            else if (ItemType.Equals(ProjectItemType.Task))
                data.DeleteTask(delID, new TransactionFailedHandler(this.TransactionFailed));

            BindData();
        }

        /// <summary>
        /// Display a hyperlink name column for project and modules, and a regular column for tasks
        /// </summary>
        private void setDisplayItemType()
        {
            // change the name column to a BoundColumn instead of a HypLinkColumn
            if (ItemType.Equals(ProjectItemType.Task))
            {
                // set the link url for the name column
                ((HyperLinkColumn)DataGrid1.Columns[1]).DataNavigateUrlFormatString = "Assign.aspx?taskID={0}";
                DataGrid1.Columns[1].HeaderText = ItemType + " Name (Click to assign)";

                return;
            }

            // set the link url for the name column
            ((HyperLinkColumn)DataGrid1.Columns[1]).DataNavigateUrlFormatString = "Projects.aspx?item="+ItemType+"&id={0}";
            DataGrid1.Columns[1].HeaderText = ItemType + " Name";
        }

        /// <summary>
        /// Make the row editable
        /// </summary>
        private void EditButton_Pushed(object source, DataGridCommandEventArgs e)
        {
            DataGrid1.EditItemIndex = e.Item.ItemIndex;
            BindData();
        }

        private void UpdateCommand_Pushed(object source, DataGridCommandEventArgs e)
        {
            TextBox tb;
            string name = ((HyperLink)e.Item.Cells[1].Controls[0]).Text;
            tb = (TextBox)e.Item.Cells[2].Controls[0];
            string desc = tb.Text;
            tb = (TextBox)e.Item.Cells[3].Controls[0];
            DateTime start = Convert.ToDateTime(tb.Text);

            int id = Convert.ToInt32(DataGrid1.Items[e.Item.ItemIndex].Cells[0].Text);

            IDataProvider data = DataProvider.CreateInstance();
            
            ProjectItem item;

            if(ItemType.Equals(ProjectItemType.Project))
            {
                item = data.GetProject(id);
                item.Name = name;
                item.Description = desc;
                item.StartDate = start;
                data.UpdateProject(item as Project, new TransactionFailedHandler(this.TransactionFailed));
            }
            else if (ItemType.Equals(ProjectItemType.Module))
            {
                item = data.GetModule(id);
                item.Name = name;
                item.Description = desc;
                item.StartDate = start;
                data.UpdateModule(item as Module, new TransactionFailedHandler(this.TransactionFailed));
            }
            else //if (itemType.Equals(ProjectItemType.Task))
            {
                item = data.GetTask(id);
                item.Name = name;
                item.Description = desc;
                item.StartDate = start;
                data.UpdateTask(item as Task, new TransactionFailedHandler(this.TransactionFailed));
            }

            DataGrid1.EditItemIndex = -1;
            DataGrid1.DataBind();
        }

        private void CancelCommand_Clicked(object source, DataGridCommandEventArgs e)
        {
            DataGrid1.EditItemIndex = -1;
            BindData();
        }

        private void TransactionFailed(Exception ex)
        {
            lblResult.Text = ex.Message;
        }

        public ProjectItemType ItemType
        {
            get 
            {
                try
                {
                    return (ProjectItemType)Enum.Parse(typeof(ProjectItemType), Request["item"]);     
                }
                catch
                {
                    //throw new Exception("Invalid Item Type");
                    // default to project
                    return ProjectItemType.Project;
                }
            }
        }
        public int ItemID
        {
            get
            {
                try
                {
                    return Convert.ToInt32(Request["id"]);   
                }
                catch
                {
                    throw new Exception("Invalid Item ID");
                }
            }
        }
        public int UserID
        {
            get
            {
                try
                {
                    return Convert.ToInt32(Request.Cookies["user"]["id"]);   
                }
                catch
                {
                    throw new Exception("Invalid Cookie");
                }
            }
        }
	}
}
