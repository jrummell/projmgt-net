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
using PMT.Controls;
using PMTComponents;
using PMTDataProvider;

namespace PMT.PM
{
    /// <summary>
    /// Summary description for PMProjects.
    /// </summary>
    public class NewItem : Page
    {
        protected Button SubmitButton;
        protected TextBox StartTextBox;
        protected RegularExpressionValidator StartRegularExpressionValidator;
        protected RequiredFieldValidator NameRequiredFieldValidator;
        protected RequiredFieldValidator StartRequiredFieldValidator;
        protected Label statusLabel;
        protected System.Web.UI.HtmlControls.HtmlTextArea descriptionTextArea;
        protected TextBox NameTextBox;
        protected Panel ChooseItemPanel;
        protected Panel CreateItemPanel;
        protected PageNameControl pageNameControl;
        protected HyperLink CreateProjectLink;
        protected HyperLink CreateModuleLink;
        protected HyperLink CreateTaskLink;
        protected Panel creationSuccessPanel;
        protected HyperLink addAnotherItemLink;
        protected DropDownList ModuleDropDownList;
        protected DropDownList ProjectDropDownList;
        protected Label InProjectLabel;
        protected Label InModuleLabel;
        protected CustomValidator DescriptionCustomValidator;
        protected CustomValidator ProjectDropDownValidator;
        protected RequiredFieldValidator ProjectDropDownListRequiredFieldValidator;
        protected RequiredFieldValidator ModuleDropDownListRequiredFieldValidator;
        // the id of the parent item
        protected Project parentProject;
        protected CustomValidator StartDateCustomValidator;
        protected Label ParentDateLabel;
        protected DropDownList ComplexityDropDownList;
        protected Label ComplexityLabel;
        protected RequiredFieldValidator ComplexityDropDownListRequiredFieldValidator;
        protected HyperLink AddItemToParentHyperLink;
        protected Module parentModule;
	
        private void Page_Load(object sender, System.EventArgs e)
        {
            // get parent item id, this will be useful when you would click
            //  a link like PMNewItem.aspx?item=task&parentID=5.  This will avoid
            //  using the drop down lists

            IDataProvider data = DataProviderFactory.CreateInstance();
            // initialize parent item(s)
            if (ParentID != -1) 
            {
                if (ItemType.Equals(ProjectItemType.Module))
                {
                    parentProject = data.GetProject(ParentID);
                }
                else if (ItemType.Equals(ProjectItemType.Task))
                {
                    parentModule = data.GetModule(ParentID);
                    parentProject = data.GetProject(parentModule.ProjectID);
                }
            }

            // set the page title
            //if (!ItemType.Equals(String.Empty))
            {
                pageNameControl.PageTitle = "New " + ItemType.ToString();
            }
            

            // if there is no request item, or is not a valid option, 
            //  ask what to create
//            if (ItemType == -1 )
//            {
//                pageNameControl.PageTitle = "What do you want to create?";
//                ChooseItemPanel.Visible = true;
//            }
                // show create selected item panel
            //else 
            if (!IsPostBack)
            {
                // show the create item panel
                CreateItemPanel.Visible = true;

                // hide project or module drop down if not needed
                if (ItemType == ProjectItemType.Project)
                {
                    ProjectDropDownList.Visible = false;
                    InProjectLabel.Visible = false;
                    ProjectDropDownListRequiredFieldValidator.Enabled = false;
                    ModuleDropDownList.Visible = false;
                    InModuleLabel.Visible = false;
                    ModuleDropDownListRequiredFieldValidator.Enabled = false;
                    ComplexityLabel.Visible = false;
                    ComplexityDropDownList.Visible = false;
                    ComplexityDropDownListRequiredFieldValidator.Enabled = false;
                }
                else if (ItemType == ProjectItemType.Module)
                {
                    ModuleDropDownList.Visible = false;
                    InModuleLabel.Visible = false;
                    ModuleDropDownListRequiredFieldValidator.Enabled = false;
                    ComplexityLabel.Visible = false;
                    ComplexityDropDownList.Visible = false;
                    ComplexityDropDownListRequiredFieldValidator.Enabled = false;

                    fillProjectDropDownList();
                }
                else if (ItemType == ProjectItemType.Task)
                {
                    // set auto post back to true for the project drop down list
                    // so that when it changes, it will update the module drop down
                    ProjectDropDownList.AutoPostBack = true;
                    ComplexityLabel.Visible = true;
                    ComplexityDropDownList.Visible = true;
                    ComplexityDropDownListRequiredFieldValidator.Enabled = true;
                    ComplexityDropDownList.DataSource = Enum.GetNames(typeof(TaskComplexity));

                    fillProjectDropDownList();
                }
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
            this.ProjectDropDownList.SelectedIndexChanged += new System.EventHandler(this.ProjectDropDownList_SelectedIndexChanged);
            this.StartDateCustomValidator.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.ValidateStartDate);
            this.ComplexityDropDownList.SelectedIndexChanged += new System.EventHandler(this.ComplexityDropDownList_SelectedIndexChanged);
            this.DescriptionCustomValidator.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.ValidateDescription);
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void fillProjectDropDownList()
        {
            // build project drop down list and
            // select list item that has value = id (if value != null)
            IDataProvider data = DataProviderFactory.CreateInstance();
            //fill the dropdown list
            ProjectDropDownList.DataSource = data.GetManagerProjects(UserID);
            ProjectDropDownList.DataTextField="name";
            ProjectDropDownList.DataValueField="id";
            ProjectDropDownList.DataBind();
            ProjectDropDownList.Items.Insert(0,"");

            // select parent Project
            if (ParentID != -1)
            {
                ProjectDropDownList.SelectedIndex 
                    = ProjectDropDownList.Items.IndexOf(
                    ProjectDropDownList.Items.FindByValue(parentProject.ID.ToString()));
                ProjectDropDownList.Enabled = false;

                if (ItemType.Equals(ProjectItemType.Task))
                    fillModuleDropDownList();
            }
        }

        private void fillModuleDropDownList()
        {
            //build the module list
            IDataProvider data = DataProviderFactory.CreateInstance();
            //fill the dropdown list
            ModuleDropDownList.DataSource = data.GetProjectModules(Convert.ToInt32(ProjectDropDownList.SelectedValue));
            ModuleDropDownList.DataTextField="name";
            ModuleDropDownList.DataValueField="id";
            ModuleDropDownList.DataBind();
            ModuleDropDownList.Items.Insert(0, "");

            // select parent Module
            if (ParentID != -1)
            {
                ModuleDropDownList.SelectedIndex 
                    = ModuleDropDownList.Items.IndexOf(
                    ModuleDropDownList.Items.FindByValue(parentModule.ID.ToString()));
                ModuleDropDownList.Enabled = false;
            }
        }

        private void SubmitButton_Click(object sender, System.EventArgs e)
        {
            // return if the form did not pass validation
            if (!Page.IsValid)
                return;

            IDataProvider data = DataProviderFactory.CreateInstance();
            ProjectItem item;

            if (ItemType.Equals(ProjectItemType.Project))
            {
                item = new Project(
                            UserID, 
                            NameTextBox.Text, 
                            descriptionTextArea.InnerText, 
                            Convert.ToDateTime(StartTextBox.Text));
                int id = data.InsertProject(item as Project, new TransactionFailedHandler(this.TransactionFailed));
                // set the link for adding a child item
                addAnotherItemLink.NavigateUrl += "?item="+ProjectItemType.Module+"&parentID="+id;
                addAnotherItemLink.Text = "Add a Module to " + NameTextBox.Text;
                // set the link for adding another item to parent item
                AddItemToParentHyperLink.Text = "Create another Project";
                AddItemToParentHyperLink.NavigateUrl += "?item="+ProjectItemType.Project;
            }
            else if (ItemType.Equals(ProjectItemType.Module))
            {
                item = new Module(
                            Convert.ToInt32(ProjectDropDownList.SelectedValue),
                            NameTextBox.Text, 
                            descriptionTextArea.InnerText,
                            Convert.ToDateTime(StartTextBox.Text));
                int id = data.InsertModule(item as Module, new TransactionFailedHandler(this.TransactionFailed));
                // set the link for adding a child item
                addAnotherItemLink.NavigateUrl += "?item="+ProjectItemType.Task+"&parentID="+id;
                addAnotherItemLink.Text = "Add a Task to " + NameTextBox.Text;
                // set the link for adding another item to parent item
                AddItemToParentHyperLink.Text = "Add another Module to " + ProjectDropDownList.SelectedItem.Text;
                AddItemToParentHyperLink.NavigateUrl += "?item="+ProjectItemType.Module+"&parentID="+ProjectDropDownList.SelectedValue;
            }
            else //(itemType.Equals(ProjectItemType.TASK))
            {
                item = new Task(
                            Convert.ToInt32(ModuleDropDownList.SelectedValue),
                            Convert.ToInt32(ProjectDropDownList.SelectedValue),
                            NameTextBox.Text, 
                            descriptionTextArea.InnerText,
                            (TaskComplexity)ComplexityDropDownList.SelectedIndex,
                            Convert.ToDateTime(StartTextBox.Text));
                data.InsertTask(item as Task, new TransactionFailedHandler(this.TransactionFailed));
                // hide the add child item link
                addAnotherItemLink.Visible = false;
                // set the link for adding another item to parent item
                AddItemToParentHyperLink.Text = "Add another Task to " + ModuleDropDownList.SelectedItem.Text;
                AddItemToParentHyperLink.NavigateUrl += "?item="+ProjectItemType.Task+"&parentID="+ModuleDropDownList.SelectedValue;
            }

            statusLabel.Text = NameTextBox.Text + " created.";

            CreateItemPanel.Visible = false;
            creationSuccessPanel.Visible = true;
        }
        /// <summary>
        /// Validates if the start date is after its parent start date
        /// </summary>
        private void ValidateStartDate(object sender, ServerValidateEventArgs args)
        {
            // ignore error if start or end date is not in valid form
            if (!StartRegularExpressionValidator.IsValid)
            {
                args.IsValid = true;
                return;
            }

            // initially set to true
            args.IsValid = true;

            DateTime start = Convert.ToDateTime(StartTextBox.Text);
            DateTime parentStart = new DateTime();

            // check parent's start date against start date if not a project
            if (!ItemType.Equals(ProjectItemType.Project))
            {
                if (ItemType.Equals(ProjectItemType.Module))
                {
                    parentStart = parentProject.StartDate;
                }
                else //if (itemType.Equals(ProjectItemType.TASK))
                {
                    parentStart = parentModule.StartDate;
                }

                if (start < parentStart)
                {
                    args.IsValid = false;
                    this.StartDateCustomValidator.ErrorMessage
                        += " (" + parentStart.ToShortDateString() + ")";
                }
            }
        }


        /// <summary>
        /// Validates if the description is less than 256 characters
        /// </summary>
        private void ValidateDescription(object sender, ServerValidateEventArgs args)
        {
            if (descriptionTextArea.InnerText.Length < 256)
                args.IsValid = true;
            else
                args.IsValid = false;
        }

        private void ProjectDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ItemType.Equals(ProjectItemType.Task))
            {
                fillModuleDropDownList();
            }
        }

        private void ComplexityDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        
        }

        private void TransactionFailed(Exception ex)
        {
            statusLabel.Text = ex.Message;
        }

        #region Properties
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
                    throw new Exception("Invalid Item Type");
                }
            }
        }
        public int ParentID
        {
            get 
            {
                try
                {
                    return Convert.ToInt32(Request["parentID"]);    
                }
                catch
                {
                    return -1;
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
                    return -1;
                }
            }

        }
        #endregion
    }
}
