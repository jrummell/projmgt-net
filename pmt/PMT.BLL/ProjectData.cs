using PMT.DAL;
using SubSonic;

namespace PMT.BLL
{
    public class ProjectData
    {
        private readonly ProjectAssignmentController _assignmentController;
        private readonly ProjectController _projectController;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectData"/> class.
        /// </summary>
        public ProjectData()
        {
            _projectController = new ProjectController();
            _assignmentController = new ProjectAssignmentController();
        }

        /// <summary>
        /// Gets the assigned projects.
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
        public ProjectAssignmentCollection GetAssignedProjects(int userID)
        {
            Query query = ProjectAssignment.CreateQuery().AddWhere(ProjectAssignment.Columns.UserID, Comparison.Equals,
                                                                   userID);

            return _assignmentController.FetchByQuery(query);
        }

        /// <summary>
        /// Inserts the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns></returns>
        public void InsertProject(Project project)
        {
            _projectController.Insert(project.Name, project.Description,
                              project.StartDate, project.ExpEndDate, project.ActEndDate);
        }

        /// <summary>
        /// Updates the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns></returns>
        public void UpdateProject(Project project)
        {
            _projectController.Update(project.ID, project.Name, project.Description,
                              project.StartDate, project.ExpEndDate, project.ActEndDate);
        }

        /// <summary>
        /// Deletes the project.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public void DeleteProject(int id)
        {
            _projectController.Delete(id);
        }

        /// <summary>
        /// Assigns the project.
        /// </summary>
        /// <param name="projectID">The project ID.</param>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
        public void AssignProject(int projectID, int userID)
        {
            _assignmentController.Insert(projectID, userID);
        }

        /// <summary>
        /// Unassigns the project.
        /// </summary>
        /// <param name="projectID">The project ID.</param>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
        public void UnassignProject(int projectID, int userID)
        {
            _assignmentController.Delete(projectID, userID);
        }

        /// <summary>
        /// Gets the project.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public DAL.Project GetProject(int id)
        {
            return ReadOnlyRecord<DAL.Project>.FetchByID(id);
        }
    }
}