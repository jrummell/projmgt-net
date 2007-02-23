using System;
using System.Collections.Generic;
using System.Text;
using PMT.DAL;
using PMT.DAL.ProjectsDataSetTableAdapters;
using PMT.DAL.AssignmentsDataSetTableAdapters;

namespace PMT.BLL
{
    public class ProjectData : IDisposable
    {
        private ProjectsTableAdapter taProjects;
        private ProjectAssignmentsTableAdapter taAssignments;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectData"/> class.
        /// </summary>
        public ProjectData()
        {
            taProjects = new ProjectsTableAdapter();
            taAssignments = new ProjectAssignmentsTableAdapter();
        }

        /// <summary>
        /// Gets the assigned projects.
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
        public ProjectsDataSet.ProjectsDataTable GetAssignedProjects(int userID)
        {
            return taProjects.GetProjectsByUserProjects(userID);
        }

        /// <summary>
        /// Inserts the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns></returns>
        public int InsertProject(Project project)
        {
            int id = taProjects.Insert(project.Name, project.Description,
                project.StartDate, project.ExpEndDate, project.ActEndDate);

            return id;
        }

        /// <summary>
        /// Updates the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns></returns>
        public bool UpdateProject(Project project)
        {
            int rows = taProjects.Update(project.Name, project.Description,
                project.StartDate, project.ExpEndDate, project.ActEndDate,
                project.ID, project.ID);

            return rows == 1;
        }

        /// <summary>
        /// Deletes the project.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool DeleteProject(int id)
        {
            int rows = taProjects.Delete(id);

            return rows == 1;
        }

        /// <summary>
        /// Assigns the project.
        /// </summary>
        /// <param name="projectID">The project ID.</param>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
        public bool AssignProject(int projectID, int userID)
        {
            int rows = taAssignments.Insert(projectID, userID);

            return rows == 1;
        }

        /// <summary>
        /// Unassigns the project.
        /// </summary>
        /// <param name="projectID">The project ID.</param>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
        public bool UnassignProject(int projectID, int userID)
        {
            int rows = taAssignments.Delete(projectID, userID);

            return rows == 1;
        }

        /// <summary>
        /// Gets the project.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Project GetProject(int id)
        {
            ProjectsDataSet.ProjectsDataTable dt =
                taProjects.GetProjectByID(id);

            if (dt.Count != 1)
                return null;

            Project p = new Project();
            p.ID = id;
            p.Name = dt[0].Name;
            p.Description = dt[0].Description;
            p.StartDate = dt[0].StartDate;
            p.ExpEndDate = dt[0].ExpEndDate;
            p.ActEndDate = dt[0].ActEndDate;

            return p;
        }

        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                taAssignments.Dispose();
                taProjects.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        #endregion
    }
}
