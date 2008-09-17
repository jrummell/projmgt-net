using System;
using System.Data.SqlTypes;

namespace PMT.BLL
{
    /// <summary>
    /// The type of the Project Item ...
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
    public abstract class ProjectItem
    {
        /// <summary>
        /// Main Constructor
        /// </summary>
        protected ProjectItem(int id, string name, string description,
                              DateTime? startDate, DateTime? expEndDate, DateTime? actEndDate)
        {
            ID = id;
            Name = name;
            Description = description;
            StartDate = Validate(startDate);
            ExpEndDate = Validate(expEndDate);
            ActEndDate = Validate(actEndDate);
        }

        private static DateTime? Validate(DateTime? date)
        {
            DateTime sqlMin = (DateTime) SqlDateTime.MinValue;
            return date < sqlMin ? sqlMin : date;
        }

        /// <summary>
        /// Creates a blank ProjectItem
        /// </summary>
        protected ProjectItem()
            : this(0, "", "", DateTime.MinValue, DateTime.MinValue, DateTime.MinValue)
        {
        }

        public abstract ProjectItemType Type { get; }

        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public int ID { get; internal set; }

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
    }
}