using System;
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
            : base(typeof(TaskController))
        {
        }

        /// <summary>
        /// Inserts the task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns></returns>
        public override void Insert(Task task)
        {
            if (task == null)
            {
                throw new ArgumentNullException("task");
            }

            DAL.Task dalTask = new DAL.Task
                                   {
                                       ModuleID = task.ModuleID,
                                       Name = task.Name,
                                       Description = task.Description,
                                       StartDate = task.StartDate,
                                       ExpEndDate = task.ExpEndDate,
                                       ActEndDate = task.ActEndDate,
                                       Status = (short) task.Status,
                                       Complexity = (short) task.Complexity

                                   };

            dalTask.Save();

            task.ID = dalTask.Id;
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

#warning //TODO: optimize
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
            if (!Exists(taskID))
            {
                throw new ServiceException(String.Format("A task with ID = {0} does not exist.", taskID));
            }

            UserService userService = new UserService();
            if (!userService.Exists(devID))
            {
                throw new ServiceException(String.Format("A user with ID = {0} does not exist.", devID));
            }

            Query query = TaskAssignment.CreateQuery()
                .AddWhere(TaskAssignment.Columns.TaskID, Comparison.Equals, taskID);

            if (_taskAssignmentController.FetchByQuery(query).Count != 0)
            {
                throw new ServiceException(String.Format("Task with ID = {0} is already assigned.", taskID));
            }

            _taskAssignmentController.Insert(taskID, devID);
        }

        /// <summary>
        /// Unassigns the task.
        /// </summary>
        /// <param name="taskID">The task ID.</param>
        public void Unassign(int taskID)
        {
            if (!Exists(taskID))
            {
                throw new ServiceException(String.Format("A task with ID = {0} does not exist.", taskID));
            }

            _taskAssignmentController.Delete(taskID);
        }

        public Collection<Task> GetByUser(int devID)
        {
            Query query = TaskAssignment.CreateQuery().AddWhere(TaskAssignment.Columns.UserID, Comparison.Equals, devID);
            TaskAssignmentCollection assignmentCollection = _taskAssignmentController.FetchByQuery(query);

#warning //TODO: optimize
            Collection<Task> tasks = new Collection<Task>();
            foreach (TaskAssignment assignment in assignmentCollection)
            {
                tasks.Add(CreateRecord(assignment.Task));
            }

            return tasks;
        }
    }
}