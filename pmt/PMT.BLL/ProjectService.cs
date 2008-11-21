using System.Collections.Generic;
using PMT.DAL;
using SubSonic;

namespace PMT.BLL
{
    public class ProjectService : DataService<Project>
    {
        private readonly ProjectAssignmentController _assignmentController = new ProjectAssignmentController();
        private readonly ProjectController _projectController = new ProjectController();

        public ProjectService()
            : base(new ProjectController())
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

            _projectController.Insert(project.Name, project.Description,
                                      project.StartDate, project.ExpEndDate, project.ActEndDate);

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

        public override void VerifyDefaults()
        {
            Project project = GetByName("Project1");
            if (project == null)
            {
                project = new Project("Project1", "Your first project");
                Insert(project);
            }

            UserService userService = new UserService();
            User manager = userService.GetByUsername("manager");
            if (GetByUser(manager.ID).Count == 0)
            {
                Assign(project.ID, manager.ID);
            }
        }

        /// <summary>
        /// Unassigns the users.
        /// </summary>
        /// <param name="id">The project id.</param>
        private void UnassignUsers(int id)
        {
            _projectController.Delete(id);
        }

        private Project GetByName(string name)
        {
            Query query = DAL.Project.CreateQuery().AddWhere(DAL.Project.Columns.Name, Comparison.Equals, name);

            ProjectCollection collection = _projectController.FetchByQuery(query);
            if (collection.Count == 0)
            {
                return null;
            }

            return CreateRecord(collection[0]);
        }

        protected override Project CreateRecord(IActiveRecord activeRecord)
        {
            DAL.Project dalProject = (DAL.Project) activeRecord;
            return new Project(dalProject.Id, dalProject.Name, dalProject.Description, dalProject.StartDate,
                               dalProject.ExpEndDate, dalProject.ActEndDate);
        }

        /// <summary>
        /// Gets the assigned projects.
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
        public ICollection<Project> GetByUser(int userID)
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
                throw new ServiceException("A project with ID = " + projectID + " does not exist.");
            }

            UserService userService = new UserService();
            if (!userService.Exists(userID))
            {
                throw new ServiceException("A user with ID = " + userID + " does not exist.");
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
    }
}