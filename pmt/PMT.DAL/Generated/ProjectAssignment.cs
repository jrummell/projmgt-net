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
	/// Strongly-typed collection for the ProjectAssignment class.
	/// </summary>
    [Serializable]
	public partial class ProjectAssignmentCollection : ActiveList<ProjectAssignment, ProjectAssignmentCollection>
	{	   
		public ProjectAssignmentCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ProjectAssignmentCollection</returns>
		public ProjectAssignmentCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ProjectAssignment o = this[i];
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
	/// This is an ActiveRecord class which wraps the ProjectAssignments table.
	/// </summary>
	[Serializable]
	public partial class ProjectAssignment : ActiveRecord<ProjectAssignment>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ProjectAssignment()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ProjectAssignment(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ProjectAssignment(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ProjectAssignment(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ProjectAssignments", TableType.Table, DataService.GetInstance("SqlServer"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarProjectID = new TableSchema.TableColumn(schema);
				colvarProjectID.ColumnName = "ProjectID";
				colvarProjectID.DataType = DbType.Int32;
				colvarProjectID.MaxLength = 0;
				colvarProjectID.AutoIncrement = false;
				colvarProjectID.IsNullable = false;
				colvarProjectID.IsPrimaryKey = true;
				colvarProjectID.IsForeignKey = true;
				colvarProjectID.IsReadOnly = false;
				colvarProjectID.DefaultSetting = @"";
				
					colvarProjectID.ForeignKeyTableName = "Projects";
				schema.Columns.Add(colvarProjectID);
				
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
				DataService.Providers["SqlServer"].AddSchema("ProjectAssignments",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ProjectID")]
		[Bindable(true)]
		public int ProjectID 
		{
			get { return GetColumnValue<int>(Columns.ProjectID); }
			set { SetColumnValue(Columns.ProjectID, value); }
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
		/// Returns a Project ActiveRecord object related to this ProjectAssignment
		/// 
		/// </summary>
		public PMT.DAL.Project Project
		{
			get { return PMT.DAL.Project.FetchByID(this.ProjectID); }
			set { SetColumnValue("ProjectID", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a User ActiveRecord object related to this ProjectAssignment
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
		public static void Insert(int varProjectID,int varUserID)
		{
			ProjectAssignment item = new ProjectAssignment();
			
			item.ProjectID = varProjectID;
			
			item.UserID = varUserID;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varProjectID,int varUserID)
		{
			ProjectAssignment item = new ProjectAssignment();
			
				item.ProjectID = varProjectID;
			
				item.UserID = varUserID;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ProjectIDColumn
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
			 public static string ProjectID = @"ProjectID";
			 public static string UserID = @"UserID";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
