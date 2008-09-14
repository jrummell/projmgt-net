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
    /// Controller class for Tasks
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TaskController
    {
        // Preload our schema..
        Task thisSchemaLoad = new Task();
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
        public TaskCollection FetchAll()
        {
            TaskCollection coll = new TaskCollection();
            Query qry = new Query(Task.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TaskCollection FetchByID(object Id)
        {
            TaskCollection coll = new TaskCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TaskCollection FetchByQuery(Query qry)
        {
            TaskCollection coll = new TaskCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Task.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Task.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ModuleID,string Name,string Description,DateTime? StartDate,DateTime? ExpEndDate,DateTime? ActEndDate,short Status,short? Complexity)
	    {
		    Task item = new Task();
		    
            item.ModuleID = ModuleID;
            
            item.Name = Name;
            
            item.Description = Description;
            
            item.StartDate = StartDate;
            
            item.ExpEndDate = ExpEndDate;
            
            item.ActEndDate = ActEndDate;
            
            item.Status = Status;
            
            item.Complexity = Complexity;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int ModuleID,string Name,string Description,DateTime? StartDate,DateTime? ExpEndDate,DateTime? ActEndDate,short Status,short? Complexity)
	    {
		    Task item = new Task();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.ModuleID = ModuleID;
				
			item.Name = Name;
				
			item.Description = Description;
				
			item.StartDate = StartDate;
				
			item.ExpEndDate = ExpEndDate;
				
			item.ActEndDate = ActEndDate;
				
			item.Status = Status;
				
			item.Complexity = Complexity;
				
	        item.Save(UserName);
	    }
    }
}
