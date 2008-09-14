using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
namespace PMT.DAL
{
    /// <summary>
    /// Controller class for ManagerAssignments
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ManagerAssignmentController
    {
        // Preload our schema..
        ManagerAssignment thisSchemaLoad = new ManagerAssignment();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public ManagerAssignmentCollection FetchAll()
        {
            ManagerAssignmentCollection coll = new ManagerAssignmentCollection();
            Query qry = new Query(ManagerAssignment.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ManagerAssignmentCollection FetchByID(object ManagerID)
        {
            ManagerAssignmentCollection coll = new ManagerAssignmentCollection().Where("ManagerID", ManagerID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ManagerAssignmentCollection FetchByQuery(Query qry)
        {
            ManagerAssignmentCollection coll = new ManagerAssignmentCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ManagerID)
        {
            return (ManagerAssignment.Delete(ManagerID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ManagerID)
        {
            return (ManagerAssignment.Destroy(ManagerID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int ManagerID,int UserID)
        {
            Query qry = new Query(ManagerAssignment.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("ManagerID", ManagerID).AND("UserID", UserID);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ManagerID,int UserID)
	    {
		    ManagerAssignment item = new ManagerAssignment();
		    
            item.ManagerID = ManagerID;
            
            item.UserID = UserID;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ManagerID,int UserID)
	    {
		    ManagerAssignment item = new ManagerAssignment();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ManagerID = ManagerID;
				
			item.UserID = UserID;
				
	        item.Save(UserName);
	    }
    }
}
