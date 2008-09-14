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
    /// Controller class for Modules
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ModuleXController
    {
        // Preload our schema..
        ModuleX thisSchemaLoad = new ModuleX();
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
        public ModuleXCollection FetchAll()
        {
            ModuleXCollection coll = new ModuleXCollection();
            Query qry = new Query(ModuleX.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ModuleXCollection FetchByID(object Id)
        {
            ModuleXCollection coll = new ModuleXCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ModuleXCollection FetchByQuery(Query qry)
        {
            ModuleXCollection coll = new ModuleXCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (ModuleX.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (ModuleX.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ProjectID,string Name,string Description,DateTime? StartDate,DateTime? ExpEndDate,DateTime? ActEndDate)
	    {
		    ModuleX item = new ModuleX();
		    
            item.ProjectID = ProjectID;
            
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
	    public void Update(int Id,int ProjectID,string Name,string Description,DateTime? StartDate,DateTime? ExpEndDate,DateTime? ActEndDate)
	    {
		    ModuleX item = new ModuleX();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.ProjectID = ProjectID;
				
			item.Name = Name;
				
			item.Description = Description;
				
			item.StartDate = StartDate;
				
			item.ExpEndDate = ExpEndDate;
				
			item.ActEndDate = ActEndDate;
				
	        item.Save(UserName);
	    }
    }
}
