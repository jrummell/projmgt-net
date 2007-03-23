using System;
using System.Collections.Generic;
using System.Text;
using PMT.DAL;
using PMT.DAL.ProjectsDataSetTableAdapters;
using PMT.DAL.AssignmentsDataSetTableAdapters;

namespace PMT.BLL
{
    public class TaskData : IDisposable
    {
        private TasksTableAdapter taTasks;
        private TaskAssignmentsTableAdapter taAssignments;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskData"/> class.
        /// </summary>
        public TaskData()
        {
            taTasks = new TasksTableAdapter();
            taAssignments = new TaskAssignmentsTableAdapter();
        }

        /// <summary>
        /// Gets the assigned tasks.
        /// </summary>
        /// <returns></returns>
        public AssignmentsDataSet.TaskAssignmentsDataTable GetAssignedTasks()
        {
            return taAssignments.GetTaskAssignments();
        }

        /// <summary>
        /// Inserts the task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns></returns>
        public bool InsertTask(Task task)
        {
            return 1 == taTasks.Insert(
                task.ModuleID,
                task.Name,
                task.Description,
                task.StartDate,
                task.ExpEndDate,
                task.ActEndDate,
                (short)task.Status,
                (short)task.Complexity);
        }

        /// <summary>
        /// Updates the task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns></returns>
        public bool UpdateTask(Task task)
        {
            return 1 == taTasks.Update(
                task.ModuleID,
                task.Name,
                task.Description,
                task.StartDate,
                task.ExpEndDate,
                task.ActEndDate,
                (short)task.Status,
                (short)task.Complexity,
                task.ID);
        }

        /// <summary>
        /// Deletes the task.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool DeleteTask(int id)
        {
            return 1 == taTasks.Delete(id);
        }

        /// <summary>
        /// Gets the module tasks.
        /// </summary>
        /// <param name="moduleID">The module ID.</param>
        /// <returns></returns>
        public ProjectsDataSet.TasksDataTable GetModuleTasks(int moduleID)
        {
            return taTasks.GetTasksByModuleID(moduleID);
        }

        /// <summary>
        /// Assigns the task.
        /// </summary>
        /// <param name="taskID">The task ID.</param>
        /// <param name="devID">The dev ID.</param>
        /// <returns></returns>
        public bool AssignTask(int taskID, int devID)
        {
            object count = taAssignments.IsAssigned(taskID, devID);

            if (count is int)
            {
                // already asigned ?
                if ((int)count == 1)
                    return false;
            }

            return 1 == taAssignments.Insert(taskID, devID);
        }

        /// <summary>
        /// Unassigns the task.
        /// </summary>
        /// <param name="taskID">The task ID.</param>
        /// <param name="devID">The dev ID.</param>
        /// <returns></returns>
        public bool UnassignTask(int taskID, int devID)
        {
            return 1 == taAssignments.Delete(taskID, devID);
        }

        /// <summary>
        /// Gets the task.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Task GetTask(int id)
        {
            ProjectsDataSet.TasksDataTable dt = taTasks.GetTaskByID(id);

            if (dt.Count != 1)
                return null;

            ProjectsDataSet.TasksRow row = dt[0];

            Task task = new Task(
                row.ID,
                row.ModuleID,
                row.Name,
                row.Description,
                (TaskComplexity)row.Complexity,
                row.StartDate,
                row.ExpEndDate,
                row.ActEndDate);

            return task;
        }

        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                lock (this)
                {
                    if (taAssignments != null)
                        taAssignments.Dispose();

                    if (taTasks != null)
                        taTasks.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        #endregion
    }
}
