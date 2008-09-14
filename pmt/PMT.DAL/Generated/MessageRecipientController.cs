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
    /// Controller class for MessageRecipients
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MessageRecipientController
    {
        // Preload our schema..
        MessageRecipient thisSchemaLoad = new MessageRecipient();
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
        public MessageRecipientCollection FetchAll()
        {
            MessageRecipientCollection coll = new MessageRecipientCollection();
            Query qry = new Query(MessageRecipient.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MessageRecipientCollection FetchByID(object MessageID)
        {
            MessageRecipientCollection coll = new MessageRecipientCollection().Where("MessageID", MessageID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MessageRecipientCollection FetchByQuery(Query qry)
        {
            MessageRecipientCollection coll = new MessageRecipientCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object MessageID)
        {
            return (MessageRecipient.Delete(MessageID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object MessageID)
        {
            return (MessageRecipient.Destroy(MessageID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int MessageID,int UserID)
        {
            Query qry = new Query(MessageRecipient.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("MessageID", MessageID).AND("UserID", UserID);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int MessageID,int UserID,bool Opened)
	    {
		    MessageRecipient item = new MessageRecipient();
		    
            item.MessageID = MessageID;
            
            item.UserID = UserID;
            
            item.Opened = Opened;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int MessageID,int UserID,bool Opened)
	    {
		    MessageRecipient item = new MessageRecipient();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.MessageID = MessageID;
				
			item.UserID = UserID;
				
			item.Opened = Opened;
				
	        item.Save(UserName);
	    }
    }
}
