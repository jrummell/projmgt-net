using System;
using System.Collections.Generic;
using System.Text;
using PMT.DAL;
using PMT.DAL.ProjectsDataSetTableAdapters;

namespace PMT.BLL
{
    public class ModuleData : IDisposable
    {
        private ModulesTableAdapter taModules;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleData"/> class.
        /// </summary>
        public ModuleData()
        {
            taModules = new ModulesTableAdapter();
        }

        /// <summary>
        /// Gets the project's modules.
        /// </summary>
        /// <param name="projectID">The project ID.</param>
        /// <returns></returns>
        public ProjectsDataSet.ModulesDataTable GetProjectModules(int projectID)
        {
            return taModules.GetModulesByProjectID(projectID);
        }

        /// <summary>
        /// Inserts the module.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <returns></returns>
        public bool InsertModule(Module module)
        {
            return 1 == taModules.Insert(
                module.ProjectID,
                module.Name,
                module.Description,
                module.StartDate,
                module.ExpEndDate,
                module.ActEndDate);
        }

        /// <summary>
        /// Updates the module.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <returns></returns>
        public bool UpdateModule(Module module)
        {
            return 1 == taModules.Update(
                module.ProjectID,
                module.Name,
                module.Description,
                module.StartDate,
                module.ExpEndDate,
                module.ActEndDate,
                module.ID,
                module.ID);
        }

        /// <summary>
        /// Deletes the module.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool DeleteModule(int id)
        {
            return 1 == taModules.Delete(id);
        }

        /// <summary>
        /// Gets the module.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Module GetModule(int id)
        {
            ProjectsDataSet.ModulesDataTable dt = taModules.GetModuleByID(id);

            if (dt.Count != 1)
                return null;

            ProjectsDataSet.ModulesRow row = dt[0];

            Module module = new Module(
                row.ID,
                row.ProjectID,
                row.Name,
                row.Description,
                row.StartDate,
                row.ExpEndDate,
                row.ActEndDate);

            return module;
        }

        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                lock (this)
                {
                    if (taModules != null)
                        taModules.Dispose();
                }
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
