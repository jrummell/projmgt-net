using System.Collections;
using System.Collections.ObjectModel;

namespace PMT.BLL
{
    public interface IDataService
    {
        /// <summary>
        /// Gets all of the records.
        /// </summary>
        /// <returns></returns>
        ICollection GetAll();

        /// <summary>
        /// Gets a record by its ID.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        IRecord GetByID(int id);

        /// <summary>
        /// Inserts a new record.
        /// </summary>
        /// <param name="record">The record.</param>
        void Insert(IRecord record);

        /// <summary>
        /// Updates a record.
        /// </summary>
        /// <param name="record">The record.</param>
        void Update(IRecord record);

        /// <summary>
        /// Does the specificed record exist?
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        bool Exists(int id);

        /// <summary>
        /// Deletes a record by its id.
        /// </summary>
        /// <param name="id">The id.</param>
        void Delete(int id);

        /// <summary>
        /// Verifies the defaults.
        /// </summary>
        void VerifyDefaults();
    }

    public interface IDataService<TRecord> : IDataService
        where TRecord : IRecord
    {
        /// <summary>
        /// Gets all of the records.
        /// </summary>
        /// <returns></returns>
        new Collection<TRecord> GetAll();

        /// <summary>
        /// Gets a record by its ID.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        new TRecord GetByID(int id);

        /// <summary>
        /// Inserts a new record.
        /// </summary>
        /// <param name="record">The record.</param>
        void Insert(TRecord record);

        /// <summary>
        /// Updates a record.
        /// </summary>
        /// <param name="record">The record.</param>
        void Update(TRecord record);
    }
}