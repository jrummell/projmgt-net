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
using PMT.Web.Controls;
using PMT.Configuration;
using PMTComponents;
using PMTDataProvider;
using PMT.BLL;
using PMT.Web;

namespace PMT.AllUsers
{
    public partial class Reports : Page
    {
        protected string role;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            IDataProvider data = DataProviderFactory.CreateInstance();

            if (!this.IsPostBack)
            {
                int id = CookiesHelper.LoggedInUserID;
                UserRole role = CookiesHelper.LoggedInUserRole;

                if (role.Equals(UserRole.Manager))
                {
                    ProjectDropDownList.DataSource = data.GetManagerProjects(id);
                    ProjectDropDownList.DataTextField="name";
                    ProjectDropDownList.DataValueField="ID";
                    ProjectDropDownList.DataBind();
                    ProjectDropDownList.Items.Insert(0,"");

                    enableModuleControls(false);
                    enableTaskControls(false);
                }
                else if (role.Equals(UserRole.Developer))
                {
                    // get all tasks assigned to a developer
                    TaskDropDownList.DataSource = data.GetDeveloperTasks(id);
                    TaskDropDownList.DataTextField="Name";
                    TaskDropDownList.DataValueField="ID";
                    TaskDropDownList.DataBind();
                    TaskDropDownList.Items.Insert(0,"");

                    enableModuleControls(false);
                    enableProjectControls(false);
                }
                else if (role.Equals(UserRole.Client))
                {
                    // get all projectes assigned to a client
                    ProjectDropDownList.DataSource = data.GetClientProjects(id);
                    ProjectDropDownList.DataTextField = "Name";
                    ProjectDropDownList.DataValueField = "ID";
                    ProjectDropDownList.DataBind();
                    ProjectDropDownList.Items.Insert(0,"");

                    ModuleDropDownList.Visible = false;
                    TaskDropDownList.Visible = false;
                }
            }

            ReportPanel.Visible = false;
        }

        /// <summary>
        /// Handle View Report button clicks
        /// </summary>
        protected void ViewReportButton_Click(object sender, System.EventArgs e)
        {
            string buttonID = ((Button)sender).ID;

            if (!Page.IsValid)
                return;

            IDataProvider data = DataProviderFactory.CreateInstance();
            if (buttonID.Equals("ViewProjectButton"))
            {
                PMTComponents.Project project = data.GetProject(CookiesHelper.LoggedInUserID, Convert.ToInt32(ProjectDropDownList.SelectedValue));

                report.Item = project;
                report.FillForm();
            }
            else if (buttonID.Equals("ViewModuleButton"))
            {
                PMTComponents.Module module = data.GetModule(Convert.ToInt32(ModuleDropDownList.SelectedValue));

                report.Item = module;
                report.FillForm();
            }
            else //(buttonID.Equals("ViewTaskButton"))
            {
                PMTComponents.Task task = data.GetTask(Convert.ToInt32(TaskDropDownList.SelectedValue));

                report.Item = task;
                report.FillForm();
            }

            ReportPanel.Visible = true;
        }


        protected void ProjectDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ProjectDropDownList.SelectedValue.Length == 0)
            {
                ViewProjectButton.Enabled = false;
                enableModuleControls(false);
                enableTaskControls(false);
                return;
            }

            IDataProvider data = DataProviderFactory.CreateInstance();
            ModuleDropDownList.DataSource = data.GetProjectModules(Convert.ToInt32(ProjectDropDownList.SelectedValue));
            ModuleDropDownList.DataTextField = "Name";
            ModuleDropDownList.DataValueField = "ID";
            ModuleDropDownList.DataBind();
            ModuleDropDownList.Items.Insert(0, String.Empty);

            enableProjectControls(true);
            enableModuleControls(true);
        }

        protected void ModuleDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ModuleDropDownList.SelectedValue.Length == 0)
            {
                ViewModuleButton.Enabled = false;
                enableTaskControls(false);
                return;
            }

            IDataProvider data = DataProviderFactory.CreateInstance();
            TaskDropDownList.DataSource = data.GetModuleTasks(Convert.ToInt32(ModuleDropDownList.SelectedValue));
            TaskDropDownList.DataTextField = "Name";
            TaskDropDownList.DataValueField = "ID";
            TaskDropDownList.DataBind();
            TaskDropDownList.Items.Insert(0, String.Empty);

            enableModuleControls(true);
            enableTaskControls(true);
        }

        protected void TaskDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (TaskDropDownList.SelectedValue.Length == 0)
            {
                ViewTaskButton.Enabled = false;
                return;
            }

            enableTaskControls(true);
        }

        #region Enable Controls
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
        #endregion
    }
}
