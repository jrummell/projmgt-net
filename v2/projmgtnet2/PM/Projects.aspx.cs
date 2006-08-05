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

namespace PMT.PM
{
	/// <summary>
	/// Summary description for PMProjects.
	/// </summary>
	public class Projects : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink newProjectLink;
		protected System.Web.UI.WebControls.Panel projectPanel;
        protected string itemType;
        protected System.Web.UI.WebControls.HyperLink AddItemHyperLink;
        protected System.Web.UI.WebControls.DataGrid DataGrid1;
        protected System.Web.UI.WebControls.Label ItemLabel;
        protected string id;
	
        private void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here

            // the item type and id
            itemType = Request["item"];
            id   = Request["id"];

            // default to displaying projects
            if (itemType == null)
                itemType = ProjectItem.ItemType.PROJECT;

            // the project item to display
            ProjectItem item;

            // id is the project manager's id if item is project
            if (itemType.Equals(ProjectItem.ItemType.PROJECT))
                id = Request.Cookies["user"]["id"];
            
            //create a data set
            DataSet ds=new DataSet();

            // list all projects assigned to logged in PM
            if (itemType.Equals(ProjectItem.ItemType.PROJECT))
            {
                ds = Project.getProjectsDataSet(id);
                item = null;
            }
                // list all modules in specified project
            else if (itemType.Equals(ProjectItem.ItemType.MODULE))
            {
                item = new Project(id);
                ds = ((Project)item).getModulesDataSet();
            }
                // list all tasks in specified module
            else //if (itemType.Equals(ProjectItemType.TASK))
            {
                item = new Module(id);
                ds = ((Module)item).getTasksDataSet();
                BoundColumn ComplexityColumn = new BoundColumn();
                ComplexityColumn.HeaderText = "Complexity";
                ComplexityColumn.DataField = "complexity";
                ComplexityColumn.ReadOnly = true;
                DataGrid1.Columns.AddAt(3, ComplexityColumn);
            }

            // set the display grid data source
            setDisplayItemType();
            DataGrid1.DataSource = ds;
            if (!Page.IsPostBack)
            {
                DataGrid1.DataBind();
            }

            // set the create/add new item link and item label
            if (item != null)
            {
                AddItemHyperLink.NavigateUrl 
                    = "NewItem.aspx?item=" + itemType + "&parentID=" + item.ID;
                AddItemHyperLink.Text = "Add a " + itemType + " to " + item.Name;
                ItemLabel.Text = itemType +"s in " + item.Name;
            }
            else
            {
                AddItemHyperLink.NavigateUrl = "NewItem.aspx?item=Project";
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
        private void DeleteButton_Pushed(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            string delID = DataGrid1.Items[e.Item.ItemIndex].Cells[0].Text;

            if (itemType.Equals(ProjectItem.ItemType.PROJECT))
                Project.remove(delID);
            else if (itemType.Equals(ProjectItem.ItemType.MODULE))
                Module.remove(delID);
            else if (itemType.Equals(ProjectItem.ItemType.TASK))
                Task.remove(delID);

            Response.Redirect(Request.Url.PathAndQuery);
        }

        /// <summary>
        /// Display a hyperlink name column for project and modules, and a regular column for tasks
        /// </summary>
        private void setDisplayItemType()
        {
            // change the name column to a BoundColumn instead of a HypLinkColumn
            if (itemType.Equals(ProjectItem.ItemType.TASK))
            {
                // set the link url for the name column
                ((HyperLinkColumn)DataGrid1.Columns[1]).DataNavigateUrlFormatString = "Assign.aspx?taskID={0}";
                DataGrid1.Columns[1].HeaderText = itemType + " Name (Click to assign)";

                return;
            }

            string item = "";

            // set item type to be displayed
            if (itemType.Equals(ProjectItem.ItemType.PROJECT))
                item = ProjectItem.ItemType.MODULE;
            else if(itemType.Equals(ProjectItem.ItemType.MODULE))
                item = ProjectItem.ItemType.TASK;

            // set the link url for the name column
            ((HyperLinkColumn)DataGrid1.Columns[1]).DataNavigateUrlFormatString = "Projects.aspx?item="+item+"&id={0}";
            DataGrid1.Columns[1].HeaderText = itemType + " Name";
        }

        /// <summary>
        /// Make the row editable
        /// </summary>
        private void EditButton_Pushed(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            DataGrid1.EditItemIndex=e.Item.ItemIndex;
            DataGrid1.DataBind();
        }

        private void UpdateCommand_Pushed(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            TextBox tb;
            string name = ((HyperLink)e.Item.Cells[1].Controls[0]).Text;
            tb = (TextBox)e.Item.Cells[2].Controls[0];
            string desc = tb.Text;
            tb = (TextBox)e.Item.Cells[3].Controls[0];
            string start = tb.Text;

            string id = DataGrid1.Items[e.Item.ItemIndex].Cells[0].Text;

            
            ProjectItem item;

            if(itemType.Equals(ProjectItem.ItemType.PROJECT))
            {
                item = new Project(id);
                ((Project)item).update(name, desc, start);
            }
            else if (itemType.Equals(ProjectItem.ItemType.MODULE))
            {
                item = new Module(id);
                ((Module)item).update(name, desc, start);
            }
            else //if (itemType.Equals(ProjectItem.ItemType.TASK))
            {
                item = new Task(id);
                ((Task)item).update(name, desc, start);
            }

            item.update(name, desc, start);

            DataGrid1.EditItemIndex=-1;
            Server.Transfer(Request.Url.AbsolutePath);
        }

        private void CancelCommand_Clicked(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            DataGrid1.EditItemIndex=-1;
            Server.Transfer(Request.Url.AbsolutePath);
        }
	}
}
