using System.Collections.Generic;
using PMT.DAL;
using SubSonic;

namespace PMT.BLL
{
    public class TaskService : IDataService<Task>
    {
        private readonly TaskAssignmentController _taskAssignmentController = new TaskAssignmentController();
        private readonly TaskController _tasksController = new TaskController();

        /// <summary>
        /// Gets the assigned tasks.
        /// </summary>
        /// <returns></returns>
        public TaskAssignmentCollection GetAssignedTasks()
        {
            return _taskAssignmentController.FetchAll();
        }

        /// <summary>
        /// Inserts the task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns></returns>
        public void Insert(Task task)
        {
            _tasksController.Insert(
                task.ModuleID,
                task.Name,
                task.Description,
                task.StartDate,
                task.ExpEndDate,
                task.ActEndDate,
                (short) task.Status,
                (short) task.Complexity);
        }

        /// <summary>
        /// Updates the task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns></returns>
        public void Update(Task task)
        {
            _tasksController.Update(task.ID,
                           task.ModuleID,
                           task.Name,
                           task.Description,
                           task.StartDate,
                           task.ExpEndDate,
                           task.ActEndDate,
                           (short) task.Status,
                           (short) task.Complexity);
        }

        public ICollection<Task> GetAll()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Does the specificed record exist?
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool Exists(int id)
        {
            return GetByID(id) != null;
        }

        /// <summary>
        /// Deletes the task.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public void Delete(int id)
        {
            _tasksController.Delete(id);
        }

        public void VerifyDefaults()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the module tasks.
        /// </summary>
        /// <param name="moduleID">The module ID.</param>
        /// <returns></returns>
        public TaskCollection GetTasksByModule(int moduleID)
        {
            Query query = DAL.Task.CreateQuery().WHERE(DAL.Task.Columns.ModuleID, Comparison.Equals, moduleID);
            return _tasksController.FetchByQuery(query);
        }

        /// <summary>
        /// Assigns the task.
        /// </summary>
        /// <param name="taskID">The task ID.</param>
        /// <param name="devID">The dev ID.</param>
        /// <returns></returns>
        public void Assign(int taskID, int devID)
        {
            _taskAssignmentController.Insert(taskID, devID);
        }

        /// <summary>
        /// Unassigns the task.
        /// </summary>
        /// <param name="taskID">The task ID.</param>
        /// <param name="devID">The dev ID.</param>
        /// <returns></returns>
        public void Unassign(int taskID, int devID)
        {
            _taskAssignmentController.Delete(taskID, devID);
        }

        /// <summary>
        /// Gets the task.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Task GetByID(int id)
        {
            DAL.Task dalTask = ReadOnlyRecord<DAL.Task>.FetchByID(id);
            return new Task(dalTask);
        }
    }
}