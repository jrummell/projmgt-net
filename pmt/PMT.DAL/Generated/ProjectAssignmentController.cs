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
    /// Controller class for ProjectAssignments
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProjectAssignmentController
    {
        // Preload our schema..
        ProjectAssignment thisSchemaLoad = new ProjectAssignment();
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
        public ProjectAssignmentCollection FetchAll()
        {
            ProjectAssignmentCollection coll = new ProjectAssignmentCollection();
            Query qry = new Query(ProjectAssignment.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProjectAssignmentCollection FetchByID(object ProjectID)
        {
            ProjectAssignmentCollection coll = new ProjectAssignmentCollection().Where("ProjectID", ProjectID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProjectAssignmentCollection FetchByQuery(Query qry)
        {
            ProjectAssignmentCollection coll = new ProjectAssignmentCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ProjectID)
        {
            return (ProjectAssignment.Delete(ProjectID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ProjectID)
        {
            return (ProjectAssignment.Destroy(ProjectID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int ProjectID,int UserID)
        {
            Query qry = new Query(ProjectAssignment.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("ProjectID", ProjectID).AND("UserID", UserID);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ProjectID,int UserID)
	    {
		    ProjectAssignment item = new ProjectAssignment();
		    
            item.ProjectID = ProjectID;
            
            item.UserID = UserID;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ProjectID,int UserID)
	    {
		    ProjectAssignment item = new ProjectAssignment();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ProjectID = ProjectID;
				
			item.UserID = UserID;
				
	        item.Save(UserName);
	    }
    }
}
