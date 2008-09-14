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
    /// Controller class for Projects
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProjectController
    {
        // Preload our schema..
        Project thisSchemaLoad = new Project();
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
        public ProjectCollection FetchAll()
        {
            ProjectCollection coll = new ProjectCollection();
            Query qry = new Query(Project.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProjectCollection FetchByID(object Id)
        {
            ProjectCollection coll = new ProjectCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProjectCollection FetchByQuery(Query qry)
        {
            ProjectCollection coll = new ProjectCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Project.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Project.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,string Description,DateTime? StartDate,DateTime? ExpEndDate,DateTime? ActEndDate)
	    {
		    Project item = new Project();
		    
            item.Name = Name;
            
            item.Description = Description;
            
            item.StartDate = StartDate;
            
            item.ExpEndDate = ExpEndDate;
            
            item.ActEndDate = ActEndDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string Name,string Description,DateTime? StartDate,DateTime? ExpEndDate,DateTime? ActEndDate)
	    {
		    Project item = new Project();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Name = Name;
				
			item.Description = Description;
				
			item.StartDate = StartDate;
				
			item.ExpEndDate = ExpEndDate;
				
			item.ActEndDate = ActEndDate;
				
	        item.Save(UserName);
	    }
    }
}
