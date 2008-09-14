using PMT.DAL;
using SubSonic;

namespace PMT.BLL
{
    public class TaskData
    {
        private readonly TaskAssignmentController _taskAssignmentController;
        private readonly TaskController _tasksController;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskData"/> class.
        /// </summary>
        public TaskData()
        {
            _tasksController = new TaskController();
            _taskAssignmentController = new TaskAssignmentController();
        }

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
        public void InsertTask(Task task)
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
        public void UpdateTask(Task task)
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

        /// <summary>
        /// Deletes the task.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public void DeleteTask(int id)
        {
            _tasksController.Delete(id);
        }

        /// <summary>
        /// Gets the module tasks.
        /// </summary>
        /// <param name="moduleID">The module ID.</param>
        /// <returns></returns>
        public TaskCollection GetModuleTasks(int moduleID)
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
        public void AssignTask(int taskID, int devID)
        {
            _taskAssignmentController.Insert(taskID, devID);
        }

        /// <summary>
        /// Unassigns the task.
        /// </summary>
        /// <param name="taskID">The task ID.</param>
        /// <param name="devID">The dev ID.</param>
        /// <returns></returns>
        public void UnassignTask(int taskID, int devID)
        {
            _taskAssignmentController.Delete(taskID, devID);
        }

        /// <summary>
        /// Gets the task.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public DAL.Task GetTask(int id)
        {
            return ReadOnlyRecord<DAL.Task>.FetchByID(id);
        }
    }
}