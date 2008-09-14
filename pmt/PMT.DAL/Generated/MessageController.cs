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
    /// Controller class for Messages
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MessageController
    {
        // Preload our schema..
        Message thisSchemaLoad = new Message();
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
        public MessageCollection FetchAll()
        {
            MessageCollection coll = new MessageCollection();
            Query qry = new Query(Message.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MessageCollection FetchByID(object Id)
        {
            MessageCollection coll = new MessageCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MessageCollection FetchByQuery(Query qry)
        {
            MessageCollection coll = new MessageCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Message.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Message.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int SenderID,string Subject,string Body,DateTime DateSent)
	    {
		    Message item = new Message();
		    
            item.SenderID = SenderID;
            
            item.Subject = Subject;
            
            item.Body = Body;
            
            item.DateSent = DateSent;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int SenderID,string Subject,string Body,DateTime DateSent)
	    {
		    Message item = new Message();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.SenderID = SenderID;
				
			item.Subject = Subject;
				
			item.Body = Body;
				
			item.DateSent = DateSent;
				
	        item.Save(UserName);
	    }
    }
}
