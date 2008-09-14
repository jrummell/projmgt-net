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
	/// Strongly-typed collection for the ManagerAssignment class.
	/// </summary>
    [Serializable]
	public partial class ManagerAssignmentCollection : ActiveList<ManagerAssignment, ManagerAssignmentCollection>
	{	   
		public ManagerAssignmentCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ManagerAssignmentCollection</returns>
		public ManagerAssignmentCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ManagerAssignment o = this[i];
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
	/// This is an ActiveRecord class which wraps the ManagerAssignments table.
	/// </summary>
	[Serializable]
	public partial class ManagerAssignment : ActiveRecord<ManagerAssignment>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ManagerAssignment()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ManagerAssignment(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ManagerAssignment(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ManagerAssignment(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ManagerAssignments", TableType.Table, DataService.GetInstance("SqlServer"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarManagerID = new TableSchema.TableColumn(schema);
				colvarManagerID.ColumnName = "ManagerID";
				colvarManagerID.DataType = DbType.Int32;
				colvarManagerID.MaxLength = 0;
				colvarManagerID.AutoIncrement = false;
				colvarManagerID.IsNullable = false;
				colvarManagerID.IsPrimaryKey = true;
				colvarManagerID.IsForeignKey = false;
				colvarManagerID.IsReadOnly = false;
				colvarManagerID.DefaultSetting = @"";
				colvarManagerID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarManagerID);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SqlServer"].AddSchema("ManagerAssignments",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ManagerID")]
		[Bindable(true)]
		public int ManagerID 
		{
			get { return GetColumnValue<int>(Columns.ManagerID); }
			set { SetColumnValue(Columns.ManagerID, value); }
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
		/// Returns a User ActiveRecord object related to this ManagerAssignment
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
		public static void Insert(int varManagerID,int varUserID)
		{
			ManagerAssignment item = new ManagerAssignment();
			
			item.ManagerID = varManagerID;
			
			item.UserID = varUserID;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varManagerID,int varUserID)
		{
			ManagerAssignment item = new ManagerAssignment();
			
				item.ManagerID = varManagerID;
			
				item.UserID = varUserID;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ManagerIDColumn
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
			 public static string ManagerID = @"ManagerID";
			 public static string UserID = @"UserID";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
