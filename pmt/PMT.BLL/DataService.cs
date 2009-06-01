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
        private readonly Type _controllerType;
        private IController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataService&lt;TRecord&gt;"/> class.
        /// </summary>
        /// <param name="controllerType">Type of the controller.</param>
        protected DataService(Type controllerType)
        {
            if (controllerType == null)
            {
                throw new ArgumentNullException("controllerType");
            }
            _controllerType = controllerType;
        }

        private IController Controller
        {
            get
            {
                if (_controller == null)
                {
                    _controller = (IController) Activator.CreateInstance(_controllerType);

                    if (_controller == null)
                    {
                        throw new InvalidOperationException(String.Format(
                                                                "Could not create an instance of {0} from {1}",
                                                                typeof (IController), _controllerType));
                    }
                }
                return _controller;
            }
        }

        #region IDataService<TRecord> Members

        /// <summary>
        /// Gets all of the records.
        /// </summary>
        /// <returns></returns>
        public virtual Collection<TRecord> GetAll()
        {
            return CreateCollection(Controller.FetchAll());
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
            IList collection = Controller.FetchByID(id);

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
            Controller.Delete(id);
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

            return CreateCollection(Controller.FetchByQuery(query));
        }

        /// <summary>
        /// Creates a <see cref="Collection{T}"/> from the given <see cref="Query"/> and paging parameters.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="startRowIndex">Start index of the row.</param>
        /// <param name="maximumRows">The maximum rows.</param>
        /// <returns></returns>
        protected Collection<TRecord> CreateCollection(Query query, int startRowIndex, int maximumRows)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            query.PageSize = maximumRows;

            if (maximumRows > 0)
            {
                query.PageIndex = startRowIndex/maximumRows + 1;
            }
            else
            {
                query.PageIndex = 1;
            }

            return CreateCollection(Controller.FetchByQuery(query));
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