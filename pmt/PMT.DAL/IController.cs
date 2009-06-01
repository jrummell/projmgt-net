using System.Collections;
using SubSonic;

namespace PMT.DAL
{
    /// <summary>
    /// An interface for SubSonic controllers.
    /// </summary>
    public interface IController
    {
        IList FetchAll();

        IList FetchByID(object Id);

        IList FetchByQuery(Query qry);

        bool Delete(object Id);
    }
}