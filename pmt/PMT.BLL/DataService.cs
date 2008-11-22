using System;
using System.Collections;
using System.Collections.ObjectModel;
using PMT.DAL;
using SubSonic;

namespace PMT.BLL
{
    public abstract class DataService<TRecord> : IDataService<TRecord>
        where TRecord : class, IRecord
    {
        private readonly IController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataService&lt;TRecord&gt;"/> class.
        /// </summary>
        /// <param name="controller">The controller.</param>
        protected DataService(IController controller)
        {
            if (controller == null)
            {
                throw new ArgumentNullException("controller");
            }
            _controller = controller;
        }

        #region IDataService<TRecord> Members

        /// <summary>
        /// Gets all of the records.
        /// </summary>
        /// <returns></returns>
        public virtual Collection<TRecord> GetAll()
        {
            return CreateCollection(_controller.FetchAll());
        }

        /// <summary>
        /// Gets all of the records.
        /// </summary>
        /// <returns></returns>
        ICollection IDataService.GetAll()
        {
            return GetAll();
        }

        /// <summary>
        /// Gets a record by its ID.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public virtual TRecord GetByID(int id)
        {
            IList collection = _controller.FetchByID(id);

            if (collection.Count == 0)
            {
                return null;
            }

            return CreateRecord((IActiveRecord) collection[0]);
        }

        /// <summary>
        /// Gets a record by its ID.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        IRecord IDataService.GetByID(int id)
        {
            return GetByID(id);
        }

        /// <summary>
        /// Does the specificed record exist?
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool Exists(int id)
        {
            return GetByID(id) != null;
        }

        /// <summary>
        /// Inserts a new record.
        /// </summary>
        /// <param name="record">The record.</param>
        public abstract void Insert(TRecord record);

        /// <summary>
        /// Inserts a new record.
        /// </summary>
        /// <param name="record">The record.</param>
        public void Insert(IRecord record)
        {
            Insert((TRecord) record);
        }

        /// <summary>
        /// Updates a record.
        /// </summary>
        /// <param name="record">The record.</param>
        public abstract void Update(TRecord record);

        /// <summary>
        /// Updates a record.
        /// </summary>
        /// <param name="record">The record.</param>
        public void Update(IRecord record)
        {
            Update((TRecord) record);
        }

        /// <summary>
        /// Deletes a record by its id.
        /// </summary>
        /// <param name="id">The id.</param>
        public virtual void Delete(int id)
        {
            _controller.Delete(id);
        }

        /// <summary>
        /// Verifies the defaults.
        /// </summary>
        public virtual void VerifyDefaults()
        {
        }

        #endregion

        /// <summary>
        /// Creates a <see cref="Collection{T}"/> from the given <see cref="IActiveRecord"/>s.
        /// </summary>
        /// <param name="activeRecords">The active records.</param>
        /// <returns></returns>
        protected Collection<TRecord> CreateCollection(IEnumerable activeRecords)
        {
            if (activeRecords == null)
            {
                throw new ArgumentNullException("activeRecords");
            }

            Collection<TRecord> records = new Collection<TRecord>();
            foreach (IActiveRecord activeRecord in activeRecords)
            {
                records.Add(CreateRecord(activeRecord));
            }

            return records;
        }

        /// <summary>
        /// Creates a <see cref="Collection{T}"/> from the given <see cref="Query"/>.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        protected Collection<TRecord> CreateCollection(Query query)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            return CreateCollection(_controller.FetchByQuery(query));
        }

        /// <summary>
        /// Creates a <see cref="TRecord"/> from an <see cref="IActiveRecord"/>.
        /// </summary>
        /// <param name="activeRecord">The active record.</param>
        /// <returns></returns>
        protected abstract TRecord CreateRecord(IActiveRecord activeRecord);

        /// <summary>
        /// Creates a single record from the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        protected TRecord CreateRecord(Query query)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            Collection<TRecord> collection = CreateCollection(query);
            if (collection.Count == 0)
            {
                return null;
            }

            return collection[0];
        }
    }
}