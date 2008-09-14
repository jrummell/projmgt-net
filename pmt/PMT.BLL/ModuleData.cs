using PMT.DAL;
using SubSonic;

namespace PMT.BLL
{
    public class ModuleData
    {
        private readonly ModuleXController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleData"/> class.
        /// </summary>
        public ModuleData()
        {
            _controller = new ModuleXController();
        }

        /// <summary>
        /// Gets the project's modules.
        /// </summary>
        /// <param name="projectID">The project ID.</param>
        /// <returns></returns>
        public ModuleXCollection GetProjectModules(int projectID)
        {
            Query query = new Query(Tables.ModuleX).WHERE(ModuleX.Columns.ProjectID, Comparison.Equals,
                                                          projectID);
            return _controller.FetchByQuery(query);
        }

        /// <summary>
        /// Inserts the module.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <returns></returns>
        public void InsertModule(Module module)
        {
            _controller.Insert(
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
        public void UpdateModule(Module module)
        {
            _controller.Update(module.ID,
                             module.ProjectID,
                             module.Name,
                             module.Description,
                             module.StartDate,
                             module.ExpEndDate,
                             module.ActEndDate);
        }

        /// <summary>
        /// Deletes the module.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public void DeleteModule(int id)
        {
            _controller.Delete(id);
        }

        /// <summary>
        /// Gets the module.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public ModuleX GetModule(int id)
        {
            return ReadOnlyRecord<ModuleX>.FetchByID(id);
        }
    }
}