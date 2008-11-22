using System;

namespace PMT.BLL
{
    /// <summary>
    /// The type of the Project Item
    /// </summary>
    public enum ProjectItemType
    {
        Project = 0,
        Module,
        Task
    }

    /// <summary>
    /// Base class for Project, Module, Task
    /// </summary>
    public abstract class ProjectItem : IRecord
    {
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="expEndDate">The exp end date.</param>
        /// <param name="actEndDate">The act end date.</param>
        protected ProjectItem(int id, string name, string description,
                              DateTime? startDate, DateTime? expEndDate, DateTime? actEndDate)
        {
            ID = id;
            Name = name;
            Description = description;
            StartDate = startDate;
            ExpEndDate = expEndDate;
            ActEndDate = actEndDate;
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public abstract ProjectItemType Type { get; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the start date
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the expected end date
        /// </summary>
        public DateTime? ExpEndDate { get; set; }

        /// <summary>
        /// Gets or sets the actual end date
        /// </summary>
        public DateTime? ActEndDate { get; set; }

        #region IRecord Members

        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public int ID { get; internal set; }

        #endregion
    }
}