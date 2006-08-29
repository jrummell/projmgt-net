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

namespace PMT.PM
{
    /// <summary>
    /// Summary description for PMProjects.
    /// </summary>
    public class NewItem : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Button SubmitButton;
        protected System.Web.UI.WebControls.TextBox StartTextBox;
        protected System.Web.UI.WebControls.RegularExpressionValidator StartRegularExpressionValidator;
        protected System.Web.UI.WebControls.RequiredFieldValidator NameRequiredFieldValidator;
        protected System.Web.UI.WebControls.RequiredFieldValidator StartRequiredFieldValidator;
        protected System.Web.UI.WebControls.Label statusLabel;
        protected System.Web.UI.HtmlControls.HtmlTextArea descriptionTextArea;
        protected System.Web.UI.WebControls.TextBox NameTextBox;
        protected System.Web.UI.WebControls.Panel ChooseItemPanel;
        protected System.Web.UI.WebControls.Panel CreateItemPanel;
        protected PageNameControl pageNameControl;
        protected System.Web.UI.WebControls.HyperLink CreateProjectLink;
        protected System.Web.UI.WebControls.HyperLink CreateModuleLink;
        protected System.Web.UI.WebControls.HyperLink CreateTaskLink;
        protected System.Web.UI.WebControls.Panel creationSuccessPanel;
        protected System.Web.UI.WebControls.HyperLink addAnotherItemLink;
        protected System.Web.UI.WebControls.DropDownList ModuleDropDownList;
        protected System.Web.UI.WebControls.DropDownList ProjectDropDownList;
        protected System.Web.UI.WebControls.Label InProjectLabel;
        protected System.Web.UI.WebControls.Label InModuleLabel;
        protected System.Web.UI.WebControls.CustomValidator DescriptionCustomValidator;
        protected System.Web.UI.WebControls.CustomValidator ProjectDropDownValidator;
        protected System.Web.UI.WebControls.RequiredFieldValidator ProjectDropDownListRequiredFieldValidator;
        protected System.Web.UI.WebControls.RequiredFieldValidator ModuleDropDownListRequiredFieldValidator;
        // the id of the parent item
        protected string parentID;
        protected string itemType;
        protected Project parentProject;
        protected System.Web.UI.WebControls.CustomValidator StartDateCustomValidator;
        protected System.Web.UI.WebControls.Label ParentDateLabel;
        protected System.Web.UI.WebControls.DropDownList ComplexityDropDownList;
        protected System.Web.UI.WebControls.Label ComplexityLabel;
        protected System.Web.UI.WebControls.RequiredFieldValidator ComplexityDropDownListRequiredFieldValidator;
        protected System.Web.UI.WebControls.HyperLink AddItemToParentHyperLink;
        protected Module parentModule;
	
        private void Page_Load(object sender, System.EventArgs e)
        {
            // get the item to create from the GET query string
            itemType = this.Request["item"];

            // get parent item id, this will be useful when you would click
            //  a link like PMNewItem.aspx?item=task&parentID=5.  This will avoid
            //  using the drop down lists
            parentID = this.Request["parentID"];

            // initialize parent item(s)
            if (parentID != null) 
            {
                if (itemType.Equals(ProjectItem.ItemType.MODULE))
                {
                    parentProject = new Project(parentID);
                }
                else if (itemType.Equals(ProjectItem.ItemType.TASK))
                {
                    parentModule = new Module(parentID);
                    parentProject = new Project(parentModule.ProjectID);
                }
            }

            // set the page title
            if (!itemType.Equals(String.Empty))
            {
                pageNameControl.PageTitle = "New " + itemType;
            }
            

            // if there is no request item, or is not a valid option, 
            //  ask what to create
            if (itemType == null || 
                !(itemType.Equals(ProjectItem.ItemType.PROJECT) || 
                itemType.Equals(ProjectItem.ItemType.MODULE) || 
                itemType.Equals(ProjectItem.ItemType.TASK)))
            {
                pageNameControl.PageTitle = "What do you want to create?";
                ChooseItemPanel.Visible = true;
            }
                // show create selected item panel
            else if (!Page.IsPostBack)
            {
                

                // show the create item panel
                CreateItemPanel.Visible = true;

                // hide project or module drop down if not needed
                if (itemType.Equals(ProjectItem.ItemType.PROJECT))
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
                else if (itemType.Equals(ProjectItem.ItemType.MODULE))
                {
                    ModuleDropDownList.Visible = false;
                    InModuleLabel.Visible = false;
                    ModuleDropDownListRequiredFieldValidator.Enabled = false;
                    ComplexityLabel.Visible = false;
                    ComplexityDropDownList.Visible = false;
                    ComplexityDropDownListRequiredFieldValidator.Enabled = false;

                    fillProjectDropDownList();
                }
                else if (itemType.Equals(ProjectItem.ItemType.TASK))
                {
                    // set auto post back to true for the project drop down list
                    // so that when it changes, it will update the module drop down
                    ProjectDropDownList.AutoPostBack = true;
                    ComplexityLabel.Visible = true;
                    ComplexityDropDownList.Visible = true;
                    ComplexityDropDownListRequiredFieldValidator.Enabled = true;
                    
                    ComplexityDropDownList.Items.Insert(0,"");
                    ComplexityDropDownList.Items.Insert(1,"Low");
                    ComplexityDropDownList.Items[1].Value= "Low";
                    ComplexityDropDownList.Items.Insert(2,"Medium");
                    ComplexityDropDownList.Items[2].Value= "Medium";
                    ComplexityDropDownList.Items.Insert(3,"High");
                    ComplexityDropDownList.Items[3].Value= "High";


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
            DataSet ds=new DataSet();
			ds = Project.getProjectsDataSet(Request.Cookies["user"]["id"]);
            //create a datatable to fill the dropdown list from
            DataTable dt=ds.Tables[0];
            //fill the dropdown list
            ProjectDropDownList.DataSource=dt.DefaultView;
            ProjectDropDownList.DataTextField="name";
            ProjectDropDownList.DataValueField="id";
            ProjectDropDownList.DataBind();
            ProjectDropDownList.Items.Insert(0,"");

            // select parent Project
            if (parentID != null)
            {
                ProjectDropDownList.SelectedIndex 
                    = ProjectDropDownList.Items.IndexOf(
                    ProjectDropDownList.Items.FindByValue(parentProject.ID));
                ProjectDropDownList.Enabled = false;

                if (itemType.Equals(ProjectItem.ItemType.TASK))
                    fillModuleDropDownList();
            }
        }

        private void fillModuleDropDownList()
        {
            //build the module list
            //create a data set
            DataSet ds=new DataSet();
			//ds = Module.getModulesDataSet(ProjectDropDownList.SelectedValue);
            ds = parentProject.getModulesDataSet();
            //create a datatable to fill the dropdown list from
            DataTable dt=ds.Tables[0];
            //fill the dropdown list
            ModuleDropDownList.DataSource=dt.DefaultView;
            ModuleDropDownList.DataTextField="name";
            ModuleDropDownList.DataValueField="id";
            ModuleDropDownList.DataBind();
            ModuleDropDownList.Items.Insert(0, "");

            // select parent Module
            if (parentID != null)
            {
                ModuleDropDownList.SelectedIndex 
                    = ModuleDropDownList.Items.IndexOf(
                    ModuleDropDownList.Items.FindByValue(parentModule.ID));
                ModuleDropDownList.Enabled = false;
            }
        }

        private void SubmitButton_Click(object sender, System.EventArgs e)
        {
            // return if the form did not pass validation
            if (!Page.IsValid)
                return;

            ProjectItem item;

            if (itemType.Equals(ProjectItem.ItemType.PROJECT))
            {
                item = new Project(
                            NameTextBox.Text,
                            Request.Cookies["user"]["id"],
                            descriptionTextArea.InnerText,
                            StartTextBox.Text);
                // set the link for adding a child item
                addAnotherItemLink.NavigateUrl += "?item="+ProjectItem.ItemType.MODULE+"&parentID="+item.ID;
                addAnotherItemLink.Text = "Add a Module to " + NameTextBox.Text;
                // set the link for adding another item to parent item
                AddItemToParentHyperLink.Text = "Create another Project";
                AddItemToParentHyperLink.NavigateUrl += "?item="+ProjectItem.ItemType.PROJECT;
            }
            else if (itemType.Equals(ProjectItem.ItemType.MODULE))
            {
                item = new Module(
                            NameTextBox.Text, 
                            ProjectDropDownList.SelectedValue,
                            descriptionTextArea.InnerText,
                            StartTextBox.Text);
                // set the link for adding a child item
                addAnotherItemLink.NavigateUrl += "?item="+ProjectItem.ItemType.TASK+"&parentID="+item.ID;
                addAnotherItemLink.Text = "Add a Task to " + NameTextBox.Text;
                // set the link for adding another item to parent item
                AddItemToParentHyperLink.Text = "Add another Module to " + ProjectDropDownList.SelectedItem.Text;
                AddItemToParentHyperLink.NavigateUrl += "?item="+ProjectItem.ItemType.MODULE+"&parentID="+ProjectDropDownList.SelectedValue;
            }
            else //(itemType.Equals(ProjectItemType.TASK))
            {
                item = new Task(
                            NameTextBox.Text, 
                            ModuleDropDownList.SelectedValue,
                            descriptionTextArea.InnerText,
                            StartTextBox.Text,
                            ComplexityDropDownList.SelectedValue);
                // hide the add child item link
                addAnotherItemLink.Visible = false;
                // set the link for adding another item to parent item
                AddItemToParentHyperLink.Text = "Add another Task to " + ModuleDropDownList.SelectedItem.Text;
                AddItemToParentHyperLink.NavigateUrl += "?item="+ProjectItem.ItemType.TASK+"&parentID="+ModuleDropDownList.SelectedValue;
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
            if (!itemType.Equals(ProjectItem.ItemType.PROJECT))
            {
                if (itemType.Equals(ProjectItem.ItemType.MODULE))
                {
                    if (parentID == null)
                        parentProject = new Project(ProjectDropDownList.SelectedValue);
                    parentStart = Convert.ToDateTime(parentProject.StartDate);
                }
                else //if (itemType.Equals(ProjectItemType.TASK))
                {
                    if (parentID == null)
                        parentModule = new Module(ModuleDropDownList.SelectedValue);
                    parentStart = Convert.ToDateTime(parentModule.StartDate);
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
            if (itemType.Equals(ProjectItem.ItemType.TASK))
            {
                fillModuleDropDownList();
            }
        }

        private void ComplexityDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        
        }
    }
}
