namespace PMT.BLL
{
    public class ProjectSummary
    {
        /// <summary>
        /// Gets the name of the project.
        /// </summary>
        /// <value>The name of the project.</value>
        public string ProjectName { get; internal set; }

        /// <summary>
        /// Gets or sets the project ID.
        /// </summary>
        /// <value>The project ID.</value>
        public int ProjectID { get; internal set; }
    }
}