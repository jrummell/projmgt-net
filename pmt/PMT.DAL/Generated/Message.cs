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
	/// Strongly-typed collection for the Message class.
	/// </summary>
    [Serializable]
	public partial class MessageCollection : ActiveList<Message, MessageCollection>
	{	   
		public MessageCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MessageCollection</returns>
		public MessageCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Message o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the Messages table.
	/// </summary>
	[Serializable]
	public partial class Message : ActiveRecord<Message>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Message()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Message(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Message(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Message(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("Messages", TableType.Table, DataService.GetInstance("SqlServer"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "ID";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarSenderID = new TableSchema.TableColumn(schema);
				colvarSenderID.ColumnName = "SenderID";
				colvarSenderID.DataType = DbType.Int32;
				colvarSenderID.MaxLength = 0;
				colvarSenderID.AutoIncrement = false;
				colvarSenderID.IsNullable = false;
				colvarSenderID.IsPrimaryKey = false;
				colvarSenderID.IsForeignKey = true;
				colvarSenderID.IsReadOnly = false;
				colvarSenderID.DefaultSetting = @"";
				
					colvarSenderID.ForeignKeyTableName = "Users";
				schema.Columns.Add(colvarSenderID);
				
				TableSchema.TableColumn colvarSubject = new TableSchema.TableColumn(schema);
				colvarSubject.ColumnName = "Subject";
				colvarSubject.DataType = DbType.AnsiString;
				colvarSubject.MaxLength = 50;
				colvarSubject.AutoIncrement = false;
				colvarSubject.IsNullable = true;
				colvarSubject.IsPrimaryKey = false;
				colvarSubject.IsForeignKey = false;
				colvarSubject.IsReadOnly = false;
				colvarSubject.DefaultSetting = @"";
				colvarSubject.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSubject);
				
				TableSchema.TableColumn colvarBody = new TableSchema.TableColumn(schema);
				colvarBody.ColumnName = "Body";
				colvarBody.DataType = DbType.AnsiString;
				colvarBody.MaxLength = 2147483647;
				colvarBody.AutoIncrement = false;
				colvarBody.IsNullable = true;
				colvarBody.IsPrimaryKey = false;
				colvarBody.IsForeignKey = false;
				colvarBody.IsReadOnly = false;
				colvarBody.DefaultSetting = @"";
				colvarBody.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBody);
				
				TableSchema.TableColumn colvarDateSent = new TableSchema.TableColumn(schema);
				colvarDateSent.ColumnName = "DateSent";
				colvarDateSent.DataType = DbType.DateTime;
				colvarDateSent.MaxLength = 0;
				colvarDateSent.AutoIncrement = false;
				colvarDateSent.IsNullable = false;
				colvarDateSent.IsPrimaryKey = false;
				colvarDateSent.IsForeignKey = false;
				colvarDateSent.IsReadOnly = false;
				colvarDateSent.DefaultSetting = @"";
				colvarDateSent.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDateSent);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SqlServer"].AddSchema("Messages",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("SenderID")]
		[Bindable(true)]
		public int SenderID 
		{
			get { return GetColumnValue<int>(Columns.SenderID); }
			set { SetColumnValue(Columns.SenderID, value); }
		}
		  
		[XmlAttribute("Subject")]
		[Bindable(true)]
		public string Subject 
		{
			get { return GetColumnValue<string>(Columns.Subject); }
			set { SetColumnValue(Columns.Subject, value); }
		}
		  
		[XmlAttribute("Body")]
		[Bindable(true)]
		public string Body 
		{
			get { return GetColumnValue<string>(Columns.Body); }
			set { SetColumnValue(Columns.Body, value); }
		}
		  
		[XmlAttribute("DateSent")]
		[Bindable(true)]
		public DateTime DateSent 
		{
			get { return GetColumnValue<DateTime>(Columns.DateSent); }
			set { SetColumnValue(Columns.DateSent, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public PMT.DAL.MessageRecipientCollection MessageRecipients()
		{
			return new PMT.DAL.MessageRecipientCollection().Where(MessageRecipient.Columns.MessageID, Id).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a User ActiveRecord object related to this Message
		/// 
		/// </summary>
		public PMT.DAL.User User
		{
			get { return PMT.DAL.User.FetchByID(this.SenderID); }
			set { SetColumnValue("SenderID", value.Id); }
		}
		
		
		#endregion
		
		
		
		#region Many To Many Helpers
		
		 
		public PMT.DAL.UserCollection GetUserCollection() { return Message.GetUserCollection(this.Id); }
		public static PMT.DAL.UserCollection GetUserCollection(int varId)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [dbo].[Users] INNER JOIN [MessageRecipients] ON [Users].[ID] = [MessageRecipients].[UserID] WHERE [MessageRecipients].[MessageID] = @MessageID", Message.Schema.Provider.Name);
			cmd.AddParameter("@MessageID", varId, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			UserCollection coll = new UserCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveUserMap(int varId, UserCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [MessageRecipients] WHERE [MessageRecipients].[MessageID] = @MessageID", Message.Schema.Provider.Name);
			cmdDel.AddParameter("@MessageID", varId, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (User item in items)
			{
				MessageRecipient varMessageRecipient = new MessageRecipient();
				varMessageRecipient.SetColumnValue("MessageID", varId);
				varMessageRecipient.SetColumnValue("UserID", item.GetPrimaryKeyValue());
				varMessageRecipient.Save();
			}
		}
		public static void SaveUserMap(int varId, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [MessageRecipients] WHERE [MessageRecipients].[MessageID] = @MessageID", Message.Schema.Provider.Name);
			cmdDel.AddParameter("@MessageID", varId, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					MessageRecipient varMessageRecipient = new MessageRecipient();
					varMessageRecipient.SetColumnValue("MessageID", varId);
					varMessageRecipient.SetColumnValue("UserID", l.Value);
					varMessageRecipient.Save();
				}
			}
		}
		public static void SaveUserMap(int varId , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [MessageRecipients] WHERE [MessageRecipients].[MessageID] = @MessageID", Message.Schema.Provider.Name);
			cmdDel.AddParameter("@MessageID", varId, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				MessageRecipient varMessageRecipient = new MessageRecipient();
				varMessageRecipient.SetColumnValue("MessageID", varId);
				varMessageRecipient.SetColumnValue("UserID", item);
				varMessageRecipient.Save();
			}
		}
		
		public static void DeleteUserMap(int varId) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [MessageRecipients] WHERE [MessageRecipients].[MessageID] = @MessageID", Message.Schema.Provider.Name);
			cmdDel.AddParameter("@MessageID", varId, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		#endregion
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varSenderID,string varSubject,string varBody,DateTime varDateSent)
		{
			Message item = new Message();
			
			item.SenderID = varSenderID;
			
			item.Subject = varSubject;
			
			item.Body = varBody;
			
			item.DateSent = varDateSent;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int varSenderID,string varSubject,string varBody,DateTime varDateSent)
		{
			Message item = new Message();
			
				item.Id = varId;
			
				item.SenderID = varSenderID;
			
				item.Subject = varSubject;
			
				item.Body = varBody;
			
				item.DateSent = varDateSent;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn SenderIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn SubjectColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn BodyColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DateSentColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string SenderID = @"SenderID";
			 public static string Subject = @"Subject";
			 public static string Body = @"Body";
			 public static string DateSent = @"DateSent";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
}
        #endregion
	}
}
