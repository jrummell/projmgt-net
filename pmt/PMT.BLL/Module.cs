using System;

namespace PMT.BLL
{
    /// <summary>
    /// A module report item
    /// </summary>
    public class Module : ProjectItem
    {
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="id">Module id</param>
        /// <param name="projectID">The project ID.</param>
        /// <param name="name">name</param>
        /// <param name="description">description</param>
        /// <param name="startDate">start date</param>
        /// <param name="expEndDate">expected end date</param>
        /// <param name="actEndDate">actual end date</param>
        public Module(int id, int projectID, string name, string description,
                      DateTime startDate, DateTime expEndDate, DateTime actEndDate)
            : base(id, name, description, startDate, expEndDate, actEndDate)
        {
            ProjectID = projectID;
        }

        /// <summary>
        /// Constructor used for a new Module
        /// </summary>
        /// <param name="projID">Project id</param>
        /// <param name="name">name</param>
        /// <param name="description">description</param>
        /// <param name="startDate">start date</param>
        public Module(int projID, string name, string description, DateTime startDate)
            : this(0, projID, name, description, startDate, DateTime.MinValue, DateTime.MinValue)
        {
        }


        /// <summary>
        /// Gets or sets the Project id this Module belongs to
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public override ProjectItemType Type
        {
            get { return ProjectItemType.Module; }
        }
    }
}