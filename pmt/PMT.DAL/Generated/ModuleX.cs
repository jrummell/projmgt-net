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
	/// Strongly-typed collection for the ModuleX class.
	/// </summary>
    [Serializable]
	public partial class ModuleXCollection : ActiveList<ModuleX, ModuleXCollection>
	{	   
		public ModuleXCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ModuleXCollection</returns>
		public ModuleXCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ModuleX o = this[i];
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
	/// This is an ActiveRecord class which wraps the Modules table.
	/// </summary>
	[Serializable]
	public partial class ModuleX : ActiveRecord<ModuleX>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ModuleX()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ModuleX(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ModuleX(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ModuleX(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Modules", TableType.Table, DataService.GetInstance("SqlServer"));
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
				
				TableSchema.TableColumn colvarProjectID = new TableSchema.TableColumn(schema);
				colvarProjectID.ColumnName = "ProjectID";
				colvarProjectID.DataType = DbType.Int32;
				colvarProjectID.MaxLength = 0;
				colvarProjectID.AutoIncrement = false;
				colvarProjectID.IsNullable = false;
				colvarProjectID.IsPrimaryKey = false;
				colvarProjectID.IsForeignKey = true;
				colvarProjectID.IsReadOnly = false;
				colvarProjectID.DefaultSetting = @"";
				
					colvarProjectID.ForeignKeyTableName = "Projects";
				schema.Columns.Add(colvarProjectID);
				
				TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
				colvarName.ColumnName = "Name";
				colvarName.DataType = DbType.AnsiString;
				colvarName.MaxLength = 25;
				colvarName.AutoIncrement = false;
				colvarName.IsNullable = true;
				colvarName.IsPrimaryKey = false;
				colvarName.IsForeignKey = false;
				colvarName.IsReadOnly = false;
				colvarName.DefaultSetting = @"";
				colvarName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarName);
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "Description";
				colvarDescription.DataType = DbType.AnsiString;
				colvarDescription.MaxLength = 250;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = true;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
				TableSchema.TableColumn colvarStartDate = new TableSchema.TableColumn(schema);
				colvarStartDate.ColumnName = "StartDate";
				colvarStartDate.DataType = DbType.DateTime;
				colvarStartDate.MaxLength = 0;
				colvarStartDate.AutoIncrement = false;
				colvarStartDate.IsNullable = true;
				colvarStartDate.IsPrimaryKey = false;
				colvarStartDate.IsForeignKey = false;
				colvarStartDate.IsReadOnly = false;
				colvarStartDate.DefaultSetting = @"";
				colvarStartDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStartDate);
				
				TableSchema.TableColumn colvarExpEndDate = new TableSchema.TableColumn(schema);
				colvarExpEndDate.ColumnName = "ExpEndDate";
				colvarExpEndDate.DataType = DbType.DateTime;
				colvarExpEndDate.MaxLength = 0;
				colvarExpEndDate.AutoIncrement = false;
				colvarExpEndDate.IsNullable = true;
				colvarExpEndDate.IsPrimaryKey = false;
				colvarExpEndDate.IsForeignKey = false;
				colvarExpEndDate.IsReadOnly = false;
				colvarExpEndDate.DefaultSetting = @"";
				colvarExpEndDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExpEndDate);
				
				TableSchema.TableColumn colvarActEndDate = new TableSchema.TableColumn(schema);
				colvarActEndDate.ColumnName = "ActEndDate";
				colvarActEndDate.DataType = DbType.DateTime;
				colvarActEndDate.MaxLength = 0;
				colvarActEndDate.AutoIncrement = false;
				colvarActEndDate.IsNullable = true;
				colvarActEndDate.IsPrimaryKey = false;
				colvarActEndDate.IsForeignKey = false;
				colvarActEndDate.IsReadOnly = false;
				colvarActEndDate.DefaultSetting = @"";
				colvarActEndDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActEndDate);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SqlServer"].AddSchema("Modules",schema);
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
		  
		[XmlAttribute("ProjectID")]
		[Bindable(true)]
		public int ProjectID 
		{
			get { return GetColumnValue<int>(Columns.ProjectID); }
			set { SetColumnValue(Columns.ProjectID, value); }
		}
		  
		[XmlAttribute("Name")]
		[Bindable(true)]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }
			set { SetColumnValue(Columns.Name, value); }
		}
		  
		[XmlAttribute("Description")]
		[Bindable(true)]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }
			set { SetColumnValue(Columns.Description, value); }
		}
		  
		[XmlAttribute("StartDate")]
		[Bindable(true)]
		public DateTime? StartDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.StartDate); }
			set { SetColumnValue(Columns.StartDate, value); }
		}
		  
		[XmlAttribute("ExpEndDate")]
		[Bindable(true)]
		public DateTime? ExpEndDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.ExpEndDate); }
			set { SetColumnValue(Columns.ExpEndDate, value); }
		}
		  
		[XmlAttribute("ActEndDate")]
		[Bindable(true)]
		public DateTime? ActEndDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.ActEndDate); }
			set { SetColumnValue(Columns.ActEndDate, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public PMT.DAL.TaskCollection Tasks()
		{
			return new PMT.DAL.TaskCollection().Where(Task.Columns.ModuleID, Id).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Project ActiveRecord object related to this ModuleX
		/// 
		/// </summary>
		public PMT.DAL.Project Project
		{
			get { return PMT.DAL.Project.FetchByID(this.ProjectID); }
			set { SetColumnValue("ProjectID", value.Id); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varProjectID,string varName,string varDescription,DateTime? varStartDate,DateTime? varExpEndDate,DateTime? varActEndDate)
		{
			ModuleX item = new ModuleX();
			
			item.ProjectID = varProjectID;
			
			item.Name = varName;
			
			item.Description = varDescription;
			
			item.StartDate = varStartDate;
			
			item.ExpEndDate = varExpEndDate;
			
			item.ActEndDate = varActEndDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int varProjectID,string varName,string varDescription,DateTime? varStartDate,DateTime? varExpEndDate,DateTime? varActEndDate)
		{
			ModuleX item = new ModuleX();
			
				item.Id = varId;
			
				item.ProjectID = varProjectID;
			
				item.Name = varName;
			
				item.Description = varDescription;
			
				item.StartDate = varStartDate;
			
				item.ExpEndDate = varExpEndDate;
			
				item.ActEndDate = varActEndDate;
			
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
        
        
        
        public static TableSchema.TableColumn ProjectIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn StartDateColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ExpEndDateColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ActEndDateColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string ProjectID = @"ProjectID";
			 public static string Name = @"Name";
			 public static string Description = @"Description";
			 public static string StartDate = @"StartDate";
			 public static string ExpEndDate = @"ExpEndDate";
			 public static string ActEndDate = @"ActEndDate";
						
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
