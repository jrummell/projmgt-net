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
	/// Strongly-typed collection for the MessageRecipient class.
	/// </summary>
    [Serializable]
	public partial class MessageRecipientCollection : ActiveList<MessageRecipient, MessageRecipientCollection>
	{	   
		public MessageRecipientCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MessageRecipientCollection</returns>
		public MessageRecipientCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                MessageRecipient o = this[i];
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
	/// This is an ActiveRecord class which wraps the MessageRecipients table.
	/// </summary>
	[Serializable]
	public partial class MessageRecipient : ActiveRecord<MessageRecipient>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public MessageRecipient()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public MessageRecipient(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public MessageRecipient(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public MessageRecipient(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("MessageRecipients", TableType.Table, DataService.GetInstance("SqlServer"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarMessageID = new TableSchema.TableColumn(schema);
				colvarMessageID.ColumnName = "MessageID";
				colvarMessageID.DataType = DbType.Int32;
				colvarMessageID.MaxLength = 0;
				colvarMessageID.AutoIncrement = false;
				colvarMessageID.IsNullable = false;
				colvarMessageID.IsPrimaryKey = true;
				colvarMessageID.IsForeignKey = true;
				colvarMessageID.IsReadOnly = false;
				colvarMessageID.DefaultSetting = @"";
				
					colvarMessageID.ForeignKeyTableName = "Messages";
				schema.Columns.Add(colvarMessageID);
				
				TableSchema.TableColumn colvarUserID = new TableSchema.TableColumn(schema);
				colvarUserID.ColumnName = "UserID";
				colvarUserID.DataType = DbType.Int32;
				colvarUserID.MaxLength = 0;
				colvarUserID.AutoIncrement = false;
				colvarUserID.IsNullable = false;
				colvarUserID.IsPrimaryKey = true;
				colvarUserID.IsForeignKey = true;
				colvarUserID.IsReadOnly = false;
				colvarUserID.DefaultSetting = @"";
				
					colvarUserID.ForeignKeyTableName = "Users";
				schema.Columns.Add(colvarUserID);
				
				TableSchema.TableColumn colvarOpened = new TableSchema.TableColumn(schema);
				colvarOpened.ColumnName = "Opened";
				colvarOpened.DataType = DbType.Boolean;
				colvarOpened.MaxLength = 0;
				colvarOpened.AutoIncrement = false;
				colvarOpened.IsNullable = false;
				colvarOpened.IsPrimaryKey = false;
				colvarOpened.IsForeignKey = false;
				colvarOpened.IsReadOnly = false;
				
						colvarOpened.DefaultSetting = @"((0))";
				colvarOpened.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOpened);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SqlServer"].AddSchema("MessageRecipients",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("MessageID")]
		[Bindable(true)]
		public int MessageID 
		{
			get { return GetColumnValue<int>(Columns.MessageID); }
			set { SetColumnValue(Columns.MessageID, value); }
		}
		  
		[XmlAttribute("UserID")]
		[Bindable(true)]
		public int UserID 
		{
			get { return GetColumnValue<int>(Columns.UserID); }
			set { SetColumnValue(Columns.UserID, value); }
		}
		  
		[XmlAttribute("Opened")]
		[Bindable(true)]
		public bool Opened 
		{
			get { return GetColumnValue<bool>(Columns.Opened); }
			set { SetColumnValue(Columns.Opened, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Message ActiveRecord object related to this MessageRecipient
		/// 
		/// </summary>
		public PMT.DAL.Message Message
		{
			get { return PMT.DAL.Message.FetchByID(this.MessageID); }
			set { SetColumnValue("MessageID", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a User ActiveRecord object related to this MessageRecipient
		/// 
		/// </summary>
		public PMT.DAL.User User
		{
			get { return PMT.DAL.User.FetchByID(this.UserID); }
			set { SetColumnValue("UserID", value.Id); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varMessageID,int varUserID,bool varOpened)
		{
			MessageRecipient item = new MessageRecipient();
			
			item.MessageID = varMessageID;
			
			item.UserID = varUserID;
			
			item.Opened = varOpened;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varMessageID,int varUserID,bool varOpened)
		{
			MessageRecipient item = new MessageRecipient();
			
				item.MessageID = varMessageID;
			
				item.UserID = varUserID;
			
				item.Opened = varOpened;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn MessageIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn UserIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn OpenedColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string MessageID = @"MessageID";
			 public static string UserID = @"UserID";
			 public static string Opened = @"Opened";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
