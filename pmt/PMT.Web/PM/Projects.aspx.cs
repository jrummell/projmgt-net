using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMT.BLL;

namespace PMT.Web.PM
{
    public partial class Projects : Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            //TODO: ~/PM/Projects.aspx

            throw new NotImplementedException();

            //IDataProvider data = DataProviderFactory.CreateInstance();
            //DataTable dt = new DataTable();

            //try
            //{
            //    ProjectItemType type = ItemType;
            //}
            //catch
            //{
            //    // default to project
            //    DataGrid1.DataSource = data.GetManagerProjects(UserID);
            //    DataGrid1.DataBind();

            //    AddItemHyperLink.NavigateUrl = String.Format("NewItem.aspx?item={0}", ProjectItemType.Project);
            //    AddItemHyperLink.Text = "Create a new project";
            //    ItemLabel.Text = "Your projects";
            //    return;
            //}

            //// the parent item whose sub items we are viewing
            //ProjectItem item;
            //ProjectItemType childType = ProjectItemType.Module;

            //if (ItemType.Equals(ProjectItemType.Project))
            //{
            //    item = data.GetProject(UserID, ItemID);
            //    dt = data.GetProjectModules(ItemID);
            //    childType = ProjectItemType.Module;
            //}
            //else if (ItemType.Equals(ProjectItemType.Module))
            //{
            //    item = data.GetModule(ItemID);
            //    dt = data.GetModuleTasks(ItemID);
            //    childType = ProjectItemType.Task;
            //}
            //else //if (ItemType.Equals(ProjectItemType.Task))
            //{
            //    item = data.GetModule(ItemID);
            //    dt = data.GetModuleTasks(item.ID);
            //    BoundColumn ComplexityColumn = new BoundColumn();
            //    ComplexityColumn.HeaderText = "Complexity";
            //    ComplexityColumn.DataField = "complexity";
            //    ComplexityColumn.ReadOnly = true;
            //    DataGrid1.Columns.AddAt(3, ComplexityColumn);
            //}

            //DataGrid1.DataSource = dt;
            //DataGrid1.DataBind();

            //if (ItemType != ProjectItemType.Task)
            //{
            //    // set the create/add new item link and item label
            //    AddItemHyperLink.NavigateUrl = 
            //        String.Format("NewItem.aspx?item={0}&parentID={1}", childType, item.ID);
            //    AddItemHyperLink.Text = 
            //        String.Format("Add a {0} to {1}", childType, item.Name);
            //    ItemLabel.Text = String.Format("{0}s in {1} {2}", childType, item.Type, item.Name);
            //}
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
            DataGrid1.ItemDataBound += new DataGridItemEventHandler(DataGrid1_ItemDataBound);
            DataGrid1.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.CancelCommand_Clicked);
            DataGrid1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.EditButton_Pushed);
            DataGrid1.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.UpdateCommand_Pushed);
            DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DeleteButton_Pushed);

        }
        #endregion

        /// <summary>
        /// Delete the clicked row
        /// </summary>
        private void DeleteButton_Pushed(object source, DataGridCommandEventArgs e)
        {
            int delID = Convert.ToInt32(DataGrid1.Items[e.Item.ItemIndex].Cells[0].Text);
            //IDataProvider data = DataProviderFactory.CreateInstance();

            //if (ItemType.Equals(ProjectItemType.Project))
            //    data.DeleteProject(delID, new TransactionFailedHandler(this.TransactionFailed));
            //else if (ItemType.Equals(ProjectItemType.Module))
            //    data.DeleteModule(delID, new TransactionFailedHandler(this.TransactionFailed));
            //else if (ItemType.Equals(ProjectItemType.Task))
            //    data.DeleteTask(delID, new TransactionFailedHandler(this.TransactionFailed));

            BindData();
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
            int id = Convert.ToInt32(e.Item.Cells[0].Text);
            //string name = e.Item.Cells[1].Text;
            tb = (TextBox)e.Item.Cells[2].Controls[0];
            string desc = tb.Text;
            tb = (TextBox)e.Item.Cells[3].Controls[0];
            DateTime start = Convert.ToDateTime(tb.Text);
            
            //IDataProvider data = DataProviderFactory.CreateInstance();
            
            //ProjectItem item;

            //if(ItemType.Equals(ProjectItemType.Project))
            //{
            //    item = data.GetProject(UserID, id);
            //    //item.Name = name;
            //    item.Description = desc;
            //    item.StartDate = start;
            //    data.UpdateProject(item as Project, new TransactionFailedHandler(this.TransactionFailed));
            //}
            //else if (ItemType.Equals(ProjectItemType.Module))
            //{
            //    item = data.GetModule(id);
            //    //item.Name = name;
            //    item.Description = desc;
            //    item.StartDate = start;
            //    data.UpdateModule(item as Module, new TransactionFailedHandler(this.TransactionFailed));
            //}
            //else if (ItemType.Equals(ProjectItemType.Task))
            //{
            //    item = data.GetTask(id);
            //    //item.Name = name;
            //    item.Description = desc;
            //    item.StartDate = start;
            //    data.UpdateTask(item as Task, new TransactionFailedHandler(this.TransactionFailed));
            //}

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

        #region Properties
        private ProjectItemType ItemType
        {
            get 
            {
                try
                {
                    return (ProjectItemType)Enum.Parse(typeof(ProjectItemType), Request["item"]);     
                }
                catch
                {
                    throw new Exception("Invalid Item Type");
                }
            }
        }
        private int ItemID
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
        private int UserID
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
        #endregion

        /// <summary>
        /// Display a hyperlink name column for project and modules
        /// </summary>
        private void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem item = e.Item;
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                ProjectItemType type;
                try
                {
                    if (ItemType == ProjectItemType.Project)
                        type = ProjectItemType.Module;
                    else //if (ItemType == ProjectItemType.Module)
                        type = ProjectItemType.Task;
                }
                catch
                {
                    type = ProjectItemType.Project;
                }

                // set the hyperlink
                HyperLink hl = item.Cells[1].Controls[0] as HyperLink;
                int id = Convert.ToInt32(DataBinder.Eval(item.DataItem, "id"));
                if (type != ProjectItemType.Task)
                    hl.NavigateUrl = String.Format("Projects.aspx?item={0}&id={1}", type, id);
            }
        }
    }
}