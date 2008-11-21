using System.Collections;
using SubSonic;

namespace PMT.DAL
{
    public partial class ProjectController : IController
    {
        #region IController Members

        IList IController.FetchAll()
        {
            return FetchAll();
        }

        IList IController.FetchByID(object Id)
        {
            return FetchByID(Id);
        }

        IList IController.FetchByQuery(Query qry)
        {
            return FetchByQuery(qry);
        }

        #endregion
    }
}