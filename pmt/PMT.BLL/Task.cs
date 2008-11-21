using System;

namespace PMT.BLL
{
    /// <summary>
    /// Task Statuses
    /// </summary>
    public enum TaskStatus
    {
        Unassigned = 0,
        InProgress,
        Complete,
        Approved
    }

    /// <summary>
    /// Task Complexities
    /// </summary>
    public enum TaskComplexity
    {
        Low = 0,
        Medium,
        High
    }

    /// <summary>
    /// A task report item
    /// </summary>
    public class Task : ProjectItem
    {
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="id">Task id</param>
        /// <param name="modID">Module id</param>
        /// <param name="name">name</param>
        /// <param name="description">description</param>
        /// <param name="complexity">complexity</param>
        /// <param name="startDate">start date</param>
        /// <param name="expEndDate">expected end date</param>
        /// <param name="actEndDate">actual end date</param>
        public Task(int id, int modID, string name, string description, TaskComplexity complexity,
                    DateTime? startDate, DateTime? expEndDate, DateTime? actEndDate)
            : base(id, name, description, startDate, expEndDate, actEndDate)
        {
            ModuleID = modID;
            Complexity = complexity;
        }

        /// <summary>
        /// Constructor used for a new task
        /// </summary>
        /// <param name="moduleID">The module ID.</param>
        /// <param name="name">name</param>
        /// <param name="description">description</param>
        /// <param name="complexity">complexity</param>
        public Task(int moduleID, string name, string description,
                    TaskComplexity complexity)
            : this(0, moduleID, name, description, complexity,
                   null, null, null)
        {
        }

        /// <summary>
        /// Gets or sets the module ID.
        /// </summary>
        /// <value>The module ID.</value>
        public int ModuleID { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public TaskStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the complexity.
        /// </summary>
        /// <value>The complexity.</value>
        public TaskComplexity Complexity { get; set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public override ProjectItemType Type
        {
            get { return ProjectItemType.Task; }
        }
    }
}