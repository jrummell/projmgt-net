using System;

namespace PMT.BLL
{
    /// <summary>
    /// A project item
    /// </summary>
    public class Project : ProjectItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Project"/> class.
        /// </summary>
        public Project()
            : this(0, "", "", DateTime.MinValue, DateTime.MinValue, DateTime.MinValue)
        {
        }

        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="id">project id</param>
        /// <param name="name">name</param>
        /// <param name="description">description</param>
        /// <param name="startDate">start date</param>
        /// <param name="expEndDate">expected end date</param>
        /// <param name="actEndDate">actual end date</param>
        public Project(int id, string name, string description, DateTime? startDate, DateTime? expEndDate,
                       DateTime? actEndDate)
            : base(id, name, description, startDate, expEndDate, actEndDate)
        {
        }

        /// <summary>
        /// Constructor used for a new Project
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="description">description</param>
        public Project(string name, string description)
            : this(0, name, description, null, null, null)
        {
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public override ProjectItemType Type
        {
            get { return ProjectItemType.Project; }
        }
    }
}