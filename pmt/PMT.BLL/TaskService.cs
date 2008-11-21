using System.Collections.ObjectModel;
using PMT.DAL;
using SubSonic;

namespace PMT.BLL
{
    public class TaskService : DataService<Task>
    {
        private readonly TaskAssignmentController _taskAssignmentController = new TaskAssignmentController();
        private readonly TaskController _tasksController = new TaskController();

        public TaskService()
            : base(new TaskController())
        {
        }

        /// <summary>
        /// Inserts the task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns></returns>
        public override void Insert(Task task)
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
        public override void Update(Task task)
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
        /// Gets the assigned tasks.
        /// </summary>
        /// <returns></returns>
        public Collection<Task> GetAssigned()
        {
            Collection<Task> collection = new Collection<Task>();
            TaskAssignmentCollection dalAssignments = _taskAssignmentController.FetchAll();

#warning optimize
            foreach (TaskAssignment taskAssignment in dalAssignments)
            {
                collection.Add(CreateRecord(taskAssignment.Task));
            }

            return collection;
        }

        protected override Task CreateRecord(IActiveRecord activeRecord)
        {
            DAL.Task dalTask = (DAL.Task) activeRecord;
            return new Task(dalTask.Id, dalTask.ModuleID, dalTask.Name, dalTask.Description,
                            (TaskComplexity) dalTask.Complexity, dalTask.StartDate, dalTask.ExpEndDate,
                            dalTask.ActEndDate);
        }

        /// <summary>
        /// Gets the module tasks.
        /// </summary>
        /// <param name="moduleID">The module ID.</param>
        /// <returns></returns>
        public Collection<Task> GetByModule(int moduleID)
        {
            Query query = DAL.Task.CreateQuery().WHERE(DAL.Task.Columns.ModuleID, Comparison.Equals, moduleID);
            return CreateCollection(_tasksController.FetchByQuery(query));
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
    }
}