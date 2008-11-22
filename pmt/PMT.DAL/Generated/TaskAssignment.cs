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
	/// Strongly-typed collection for the TaskAssignment class.
	/// </summary>
    [Serializable]
	public partial class TaskAssignmentCollection : ActiveList<TaskAssignment, TaskAssignmentCollection>
	{	   
		public TaskAssignmentCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TaskAssignmentCollection</returns>
		public TaskAssignmentCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TaskAssignment o = this[i];
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
	/// This is an ActiveRecord class which wraps the TaskAssignments table.
	/// </summary>
	[Serializable]
	public partial class TaskAssignment : ActiveRecord<TaskAssignment>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TaskAssignment()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TaskAssignment(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TaskAssignment(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TaskAssignment(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("TaskAssignments", TableType.Table, DataService.GetInstance("SqlServer"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarTaskID = new TableSchema.TableColumn(schema);
				colvarTaskID.ColumnName = "TaskID";
				colvarTaskID.DataType = DbType.Int32;
				colvarTaskID.MaxLength = 0;
				colvarTaskID.AutoIncrement = false;
				colvarTaskID.IsNullable = false;
				colvarTaskID.IsPrimaryKey = true;
				colvarTaskID.IsForeignKey = true;
				colvarTaskID.IsReadOnly = false;
				colvarTaskID.DefaultSetting = @"";
				
					colvarTaskID.ForeignKeyTableName = "Tasks";
				schema.Columns.Add(colvarTaskID);
				
				TableSchema.TableColumn colvarUserID = new TableSchema.TableColumn(schema);
				colvarUserID.ColumnName = "UserID";
				colvarUserID.DataType = DbType.Int32;
				colvarUserID.MaxLength = 0;
				colvarUserID.AutoIncrement = false;
				colvarUserID.IsNullable = false;
				colvarUserID.IsPrimaryKey = false;
				colvarUserID.IsForeignKey = true;
				colvarUserID.IsReadOnly = false;
				colvarUserID.DefaultSetting = @"";
				
					colvarUserID.ForeignKeyTableName = "Users";
				schema.Columns.Add(colvarUserID);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SqlServer"].AddSchema("TaskAssignments",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("TaskID")]
		[Bindable(true)]
		public int TaskID 
		{
			get { return GetColumnValue<int>(Columns.TaskID); }
			set { SetColumnValue(Columns.TaskID, value); }
		}
		  
		[XmlAttribute("UserID")]
		[Bindable(true)]
		public int UserID 
		{
			get { return GetColumnValue<int>(Columns.UserID); }
			set { SetColumnValue(Columns.UserID, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Task ActiveRecord object related to this TaskAssignment
		/// 
		/// </summary>
		public PMT.DAL.Task Task
		{
			get { return PMT.DAL.Task.FetchByID(this.TaskID); }
			set { SetColumnValue("TaskID", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a User ActiveRecord object related to this TaskAssignment
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
		public static void Insert(int varTaskID,int varUserID)
		{
			TaskAssignment item = new TaskAssignment();
			
			item.TaskID = varTaskID;
			
			item.UserID = varUserID;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varTaskID,int varUserID)
		{
			TaskAssignment item = new TaskAssignment();
			
				item.TaskID = varTaskID;
			
				item.UserID = varUserID;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn TaskIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn UserIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string TaskID = @"TaskID";
			 public static string UserID = @"UserID";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
