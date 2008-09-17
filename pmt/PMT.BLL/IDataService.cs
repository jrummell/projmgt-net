using System.Collections.Generic;

namespace PMT.BLL
{
    public interface IDataService<TRecord>
    {
        /// <summary>
        /// Gets all of the records.
        /// </summary>
        /// <returns></returns>
        ICollection<TRecord> GetAll();

        /// <summary>
        /// Gets a record by its ID.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        TRecord GetByID(int id);

        /// <summary>
        /// Does the specificed record exist?
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        bool Exists(int id);

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

        /// <summary>
        /// Deletes a record by its id.
        /// </summary>
        /// <param name="id">The id.</param>
        void Delete(int id);

        void VerifyDefaults();
    }
}