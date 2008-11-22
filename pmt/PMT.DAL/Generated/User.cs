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
	/// Strongly-typed collection for the User class.
	/// </summary>
    [Serializable]
	public partial class UserCollection : ActiveList<User, UserCollection>
	{	   
		public UserCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>UserCollection</returns>
		public UserCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                User o = this[i];
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
	/// This is an ActiveRecord class which wraps the Users table.
	/// </summary>
	[Serializable]
	public partial class User : ActiveRecord<User>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public User()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public User(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public User(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public User(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Users", TableType.Table, DataService.GetInstance("SqlServer"));
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
				
				TableSchema.TableColumn colvarUsername = new TableSchema.TableColumn(schema);
				colvarUsername.ColumnName = "Username";
				colvarUsername.DataType = DbType.AnsiString;
				colvarUsername.MaxLength = 36;
				colvarUsername.AutoIncrement = false;
				colvarUsername.IsNullable = false;
				colvarUsername.IsPrimaryKey = false;
				colvarUsername.IsForeignKey = false;
				colvarUsername.IsReadOnly = false;
				colvarUsername.DefaultSetting = @"";
				colvarUsername.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsername);
				
				TableSchema.TableColumn colvarRole = new TableSchema.TableColumn(schema);
				colvarRole.ColumnName = "Role";
				colvarRole.DataType = DbType.Int16;
				colvarRole.MaxLength = 0;
				colvarRole.AutoIncrement = false;
				colvarRole.IsNullable = false;
				colvarRole.IsPrimaryKey = false;
				colvarRole.IsForeignKey = false;
				colvarRole.IsReadOnly = false;
				colvarRole.DefaultSetting = @"";
				colvarRole.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRole);
				
				TableSchema.TableColumn colvarEnabled = new TableSchema.TableColumn(schema);
				colvarEnabled.ColumnName = "Enabled";
				colvarEnabled.DataType = DbType.Boolean;
				colvarEnabled.MaxLength = 0;
				colvarEnabled.AutoIncrement = false;
				colvarEnabled.IsNullable = false;
				colvarEnabled.IsPrimaryKey = false;
				colvarEnabled.IsForeignKey = false;
				colvarEnabled.IsReadOnly = false;
				
						colvarEnabled.DefaultSetting = @"((0))";
				colvarEnabled.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEnabled);
				
				TableSchema.TableColumn colvarPassword = new TableSchema.TableColumn(schema);
				colvarPassword.ColumnName = "Password";
				colvarPassword.DataType = DbType.AnsiString;
				colvarPassword.MaxLength = 40;
				colvarPassword.AutoIncrement = false;
				colvarPassword.IsNullable = false;
				colvarPassword.IsPrimaryKey = false;
				colvarPassword.IsForeignKey = false;
				colvarPassword.IsReadOnly = false;
				colvarPassword.DefaultSetting = @"";
				colvarPassword.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPassword);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SqlServer"].AddSchema("Users",schema);
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
		  
		[XmlAttribute("Username")]
		[Bindable(true)]
		public string Username 
		{
			get { return GetColumnValue<string>(Columns.Username); }
			set { SetColumnValue(Columns.Username, value); }
		}
		  
		[XmlAttribute("Role")]
		[Bindable(true)]
		public short Role 
		{
			get { return GetColumnValue<short>(Columns.Role); }
			set { SetColumnValue(Columns.Role, value); }
		}
		  
		[XmlAttribute("Enabled")]
		[Bindable(true)]
		public bool Enabled 
		{
			get { return GetColumnValue<bool>(Columns.Enabled); }
			set { SetColumnValue(Columns.Enabled, value); }
		}
		  
		[XmlAttribute("Password")]
		[Bindable(true)]
		public string Password 
		{
			get { return GetColumnValue<string>(Columns.Password); }
			set { SetColumnValue(Columns.Password, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public PMT.DAL.ManagerAssignmentCollection ManagerAssignments()
		{
			return new PMT.DAL.ManagerAssignmentCollection().Where(ManagerAssignment.Columns.UserID, Id).Load();
		}
		public PMT.DAL.ProjectAssignmentCollection ProjectAssignments()
		{
			return new PMT.DAL.ProjectAssignmentCollection().Where(ProjectAssignment.Columns.UserID, Id).Load();
		}
		public PMT.DAL.TaskAssignmentCollection TaskAssignments()
		{
			return new PMT.DAL.TaskAssignmentCollection().Where(TaskAssignment.Columns.UserID, Id).Load();
		}
		public PMT.DAL.UserProfileCollection UserProfileRecords()
		{
			return new PMT.DAL.UserProfileCollection().Where(UserProfile.Columns.Id, Id).Load();
		}
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public PMT.DAL.ProjectCollection GetProjectCollection() { return User.GetProjectCollection(this.Id); }
		public static PMT.DAL.ProjectCollection GetProjectCollection(int varId)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [dbo].[Projects] INNER JOIN [ProjectAssignments] ON [Projects].[ID] = [ProjectAssignments].[ProjectID] WHERE [ProjectAssignments].[UserID] = @UserID", User.Schema.Provider.Name);
			cmd.AddParameter("@UserID", varId, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ProjectCollection coll = new ProjectCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveProjectMap(int varId, ProjectCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProjectAssignments] WHERE [ProjectAssignments].[UserID] = @UserID", User.Schema.Provider.Name);
			cmdDel.AddParameter("@UserID", varId, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Project item in items)
			{
				ProjectAssignment varProjectAssignment = new ProjectAssignment();
				varProjectAssignment.SetColumnValue("UserID", varId);
				varProjectAssignment.SetColumnValue("ProjectID", item.GetPrimaryKeyValue());
				varProjectAssignment.Save();
			}
		}
		public static void SaveProjectMap(int varId, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProjectAssignments] WHERE [ProjectAssignments].[UserID] = @UserID", User.Schema.Provider.Name);
			cmdDel.AddParameter("@UserID", varId, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProjectAssignment varProjectAssignment = new ProjectAssignment();
					varProjectAssignment.SetColumnValue("UserID", varId);
					varProjectAssignment.SetColumnValue("ProjectID", l.Value);
					varProjectAssignment.Save();
				}
			}
		}
		public static void SaveProjectMap(int varId , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProjectAssignments] WHERE [ProjectAssignments].[UserID] = @UserID", User.Schema.Provider.Name);
			cmdDel.AddParameter("@UserID", varId, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				ProjectAssignment varProjectAssignment = new ProjectAssignment();
				varProjectAssignment.SetColumnValue("UserID", varId);
				varProjectAssignment.SetColumnValue("ProjectID", item);
				varProjectAssignment.Save();
			}
		}
		
		public static void DeleteProjectMap(int varId) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProjectAssignments] WHERE [ProjectAssignments].[UserID] = @UserID", User.Schema.Provider.Name);
			cmdDel.AddParameter("@UserID", varId, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		#endregion
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varUsername,short varRole,bool varEnabled,string varPassword)
		{
			User item = new User();
			
			item.Username = varUsername;
			
			item.Role = varRole;
			
			item.Enabled = varEnabled;
			
			item.Password = varPassword;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varUsername,short varRole,bool varEnabled,string varPassword)
		{
			User item = new User();
			
				item.Id = varId;
			
				item.Username = varUsername;
			
				item.Role = varRole;
			
				item.Enabled = varEnabled;
			
				item.Password = varPassword;
			
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
        
        
        
        public static TableSchema.TableColumn UsernameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn RoleColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn EnabledColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn PasswordColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string Username = @"Username";
			 public static string Role = @"Role";
			 public static string Enabled = @"Enabled";
			 public static string Password = @"Password";
						
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
