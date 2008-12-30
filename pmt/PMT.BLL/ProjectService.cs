using System;
using System.Collections.ObjectModel;
using PMT.DAL;
using SubSonic;

namespace PMT.BLL
{
    public class ProjectService : DataService<Project>
    {
        private readonly ProjectAssignmentController _assignmentController = new ProjectAssignmentController();
        private readonly ProjectController _projectController = new ProjectController();

        public ProjectService()
            : base(typeof(ProjectController))
        {
        }

        /// <summary>
        /// Inserts the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns></returns>
        public override void Insert(Project project)
        {
            DAL.Project dalProject = new DAL.Project
                                         {
                                             ActEndDate = project.ActEndDate,
                                             Description = project.Description,
                                             ExpEndDate = project.ExpEndDate,
                                             Name = project.Name,
                                             StartDate = project.StartDate
                                         };
            dalProject.Save();

            project.ID = dalProject.Id;
        }

        /// <summary>
        /// Updates the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns></returns>
        public override void Update(Project project)
        {
            _projectController.Update(project.ID, project.Name, project.Description,
                                      project.StartDate, project.ExpEndDate, project.ActEndDate);
        }

        /// <summary>
        /// Deletes the project.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public override void Delete(int id)
        {
            // unassign all users from the given project
            UnassignUsers(id);

            // delete the project
            _projectController.Delete(id);
        }

        /// <summary>
        /// Unassigns the users.
        /// </summary>
        /// <param name="id">The project id.</param>
        private void UnassignUsers(int id)
        {
            _projectController.Delete(id);
        }

        /// <summary>
        /// Gets the assigned projects.
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
        public Collection<Project> GetByUser(int userID)
        {
            ProjectCollection dalProjects = DAL.User.GetProjectCollection(userID);
            return CreateCollection(dalProjects);
        }

        /// <summary>
        /// Assigns the project.
        /// </summary>
        /// <param name="projectID">The project ID.</param>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
        public void Assign(int projectID, int userID)
        {
            if (!Exists(projectID))
            {
                throw new ServiceException(String.Format("A project with ID = {0} does not exist.", projectID));
            }

            UserService userService = new UserService();
            if (!userService.Exists(userID))
            {
                throw new ServiceException(String.Format("A user with ID = {0} does not exist.", userID));
            }

            _assignmentController.Insert(projectID, userID);
        }

        /// <summary>
        /// Unassigns the project.
        /// </summary>
        /// <param name="projectID">The project ID.</param>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
        public void Unassign(int projectID, int userID)
        {
            _assignmentController.Delete(projectID, userID);
        }

        protected override Project CreateRecord(IActiveRecord activeRecord)
        {
            DAL.Project dalProject = (DAL.Project) activeRecord;
            return new Project(dalProject.Id, dalProject.Name, dalProject.Description, dalProject.StartDate,
                               dalProject.ExpEndDate, dalProject.ActEndDate);
        }
    }
}