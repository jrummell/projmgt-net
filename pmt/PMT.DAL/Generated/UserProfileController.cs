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
    /// Controller class for UserProfile
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class UserProfileController
    {
        // Preload our schema..
        UserProfile thisSchemaLoad = new UserProfile();
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
        public UserProfileCollection FetchAll()
        {
            UserProfileCollection coll = new UserProfileCollection();
            Query qry = new Query(UserProfile.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public UserProfileCollection FetchByID(object Id)
        {
            UserProfileCollection coll = new UserProfileCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public UserProfileCollection FetchByQuery(Query qry)
        {
            UserProfileCollection coll = new UserProfileCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (UserProfile.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (UserProfile.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Id,string FirstName,string LastName,string Address,string City,string State,string Zip,string PhoneNumber,string Email)
	    {
		    UserProfile item = new UserProfile();
		    
            item.Id = Id;
            
            item.FirstName = FirstName;
            
            item.LastName = LastName;
            
            item.Address = Address;
            
            item.City = City;
            
            item.State = State;
            
            item.Zip = Zip;
            
            item.PhoneNumber = PhoneNumber;
            
            item.Email = Email;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string FirstName,string LastName,string Address,string City,string State,string Zip,string PhoneNumber,string Email)
	    {
		    UserProfile item = new UserProfile();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.FirstName = FirstName;
				
			item.LastName = LastName;
				
			item.Address = Address;
				
			item.City = City;
				
			item.State = State;
				
			item.Zip = Zip;
				
			item.PhoneNumber = PhoneNumber;
				
			item.Email = Email;
				
	        item.Save(UserName);
	    }
    }
}
