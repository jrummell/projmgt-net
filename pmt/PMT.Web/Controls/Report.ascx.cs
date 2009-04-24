using System;
using System.Collections.Generic;
using System.Web.UI;
using PMT.BLL;

namespace PMT.Web.Controls
{
    public partial class Report : UserControl
    {
        //TODO: use and test ~/Controls/Report.ascx

        /// <summary>
        /// Fills the form with the given item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void FillForm(ProjectItem item)
        {
            if (item != null)
            {
                lblType.Text = item.Type.ToString();
                lblName.Text = item.Name;
                lblDescription.Text = item.Description;
                lblStartDate.Text = Utility.MaskNull(item.StartDate);
                lblExpEndDate.Text = Utility.MaskNull(item.ExpEndDate);
                lblActEndDate.Text = Utility.MaskNull(item.ActEndDate);

                double percentComplete;
                switch (item.Type)
                {
                    case ProjectItemType.Project:
                        {
                            ModuleService service = new ModuleService();
                            List<Module> modules = new List<Module>(service.GetByProject(item.ID));
                            List<ProjectItem> moduleItems = modules.ConvertAll(i => (ProjectItem) i);
                            percentComplete = GetPercentComplete(moduleItems);
                            break;
                        }
                    case ProjectItemType.Module:
                        {
                            TaskService taskService = new TaskService();
                            List<Task> tasks = new List<Task>(taskService.GetByModule(item.ID));
                            List<ProjectItem> taskItems = tasks.ConvertAll(i => (ProjectItem) i);
                            percentComplete = GetPercentComplete(taskItems);
                            break;
                        }
                    case ProjectItemType.Task:
                        {
                            percentComplete = item.IsComplete ? 1 : 0;
                            break;
                        }
                    default:
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                }

                lblItemStatus.Text = percentComplete.ToString("p");
            }
        }

        /// <summary>
        /// Gets the percent complete.
        /// </summary>
        /// <param name="subItems">The sub items.</param>
        /// <returns></returns>
        private static double GetPercentComplete(ICollection<ProjectItem> subItems)
        {
            double percentComplete;
            if (subItems.Count == 0)
            {
                percentComplete = 0;
            }
            else
            {
                int completed = 0;
                foreach (ProjectItem subItem in subItems)
                {
                    if (subItem.IsComplete)
                    {
                        completed++;
                    }
                }

                percentComplete = (double) subItems.Count/completed;
            }
            return percentComplete;
        }
    }
}