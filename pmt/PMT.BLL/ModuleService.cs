using System.Collections.ObjectModel;
using PMT.DAL;
using SubSonic;

namespace PMT.BLL
{
    public class ModuleService : DataService<Module>
    {
        private readonly ModuleXController _controller = new ModuleXController();

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleService"/> class.
        /// </summary>
        public ModuleService()
            : base(new ModuleXController())
        {
        }

        /// <summary>
        /// Gets the project's modules.
        /// </summary>
        /// <param name="projectID">The project ID.</param>
        /// <returns></returns>
        public Collection<Module> GetByProject(int projectID)
        {
            Query query = new Query(Tables.ModuleX).WHERE(ModuleX.Columns.ProjectID, Comparison.Equals,
                                                          projectID);
            return CreateCollection(_controller.FetchByQuery(query));
        }

        /// <summary>
        /// Inserts the module.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <returns></returns>
        public override void Insert(Module module)
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
        public override void Update(Module module)
        {
            _controller.Update(module.ID,
                               module.ProjectID,
                               module.Name,
                               module.Description,
                               module.StartDate,
                               module.ExpEndDate,
                               module.ActEndDate);
        }

        protected override Module CreateRecord(IActiveRecord activeRecord)
        {
            ModuleX dalModule = (ModuleX) activeRecord;

            return new Module(dalModule.Id, dalModule.ProjectID, dalModule.Name, dalModule.Description,
                              dalModule.StartDate, dalModule.ExpEndDate, dalModule.ActEndDate);
        }
    }
}