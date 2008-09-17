using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SubSonic;

namespace PMT.BLL
{
    public abstract class DataServiceBase<TRecord> : IDataService<TRecord>
        where TRecord : class
    {
        #region IDataService<TRecord> Members

        /// <summary>
        /// Inserts the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns></returns>
        public abstract void Insert(TRecord project);

        /// <summary>
        /// Updates the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns></returns>
        public abstract void Update(TRecord project);

        /// <summary>
        /// Gets all of the records.
        /// </summary>
        /// <returns></returns>
        public abstract ICollection<TRecord> GetAll();

        /// <summary>
        /// Deletes the project.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public abstract void Delete(int id);

        /// <summary>
        /// Verifies the defaults.
        /// </summary>
        public abstract void VerifyDefaults();

        /// <summary>
        /// Gets the project.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public abstract TRecord GetByID(int id);

        /// <summary>
        /// Does the specificed record exist?
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool Exists(int id)
        {
            return GetByID(id) != null;
        }

        #endregion

        /// <summary>
        /// Creates a <see cref="TRecord"/> from an <see cref="IActiveRecord"/>.
        /// </summary>
        /// <param name="activeRecord">The active record.</param>
        /// <returns></returns>
        protected abstract TRecord CreateRecord(IActiveRecord activeRecord);

        /// <summary>
        /// Creates a <see cref="ICollection{T}"/> from the given <see cref="IActiveRecord"/>s.
        /// </summary>
        /// <param name="activeRecords">The active records.</param>
        /// <returns></returns>
        protected ICollection<TRecord> CreateCollection(IEnumerable activeRecords)
        {
            Collection<TRecord> records = new Collection<TRecord>();
            foreach (IActiveRecord activeRecord in activeRecords)
            {
                records.Add(CreateRecord(activeRecord));
            }

            return records;
        }
    }
}