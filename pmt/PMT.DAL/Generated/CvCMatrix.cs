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
	/// Strongly-typed collection for the CvCMatrix class.
	/// </summary>
    [Serializable]
	public partial class CvCMatrixCollection : ActiveList<CvCMatrix, CvCMatrixCollection>
	{	   
		public CvCMatrixCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>CvCMatrixCollection</returns>
		public CvCMatrixCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                CvCMatrix o = this[i];
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
	/// This is an ActiveRecord class which wraps the CvCMatrix table.
	/// </summary>
	[Serializable]
	public partial class CvCMatrix : ActiveRecord<CvCMatrix>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public CvCMatrix()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public CvCMatrix(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public CvCMatrix(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public CvCMatrix(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CvCMatrix", TableType.Table, DataService.GetInstance("SqlServer"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarCompetency = new TableSchema.TableColumn(schema);
				colvarCompetency.ColumnName = "Competency";
				colvarCompetency.DataType = DbType.Int32;
				colvarCompetency.MaxLength = 0;
				colvarCompetency.AutoIncrement = false;
				colvarCompetency.IsNullable = false;
				colvarCompetency.IsPrimaryKey = true;
				colvarCompetency.IsForeignKey = false;
				colvarCompetency.IsReadOnly = false;
				colvarCompetency.DefaultSetting = @"";
				colvarCompetency.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCompetency);
				
				TableSchema.TableColumn colvarHighComplexity = new TableSchema.TableColumn(schema);
				colvarHighComplexity.ColumnName = "HighComplexity";
				colvarHighComplexity.DataType = DbType.Double;
				colvarHighComplexity.MaxLength = 0;
				colvarHighComplexity.AutoIncrement = false;
				colvarHighComplexity.IsNullable = false;
				colvarHighComplexity.IsPrimaryKey = false;
				colvarHighComplexity.IsForeignKey = false;
				colvarHighComplexity.IsReadOnly = false;
				colvarHighComplexity.DefaultSetting = @"";
				colvarHighComplexity.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHighComplexity);
				
				TableSchema.TableColumn colvarMedComplexity = new TableSchema.TableColumn(schema);
				colvarMedComplexity.ColumnName = "MedComplexity";
				colvarMedComplexity.DataType = DbType.Double;
				colvarMedComplexity.MaxLength = 0;
				colvarMedComplexity.AutoIncrement = false;
				colvarMedComplexity.IsNullable = false;
				colvarMedComplexity.IsPrimaryKey = false;
				colvarMedComplexity.IsForeignKey = false;
				colvarMedComplexity.IsReadOnly = false;
				colvarMedComplexity.DefaultSetting = @"";
				colvarMedComplexity.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMedComplexity);
				
				TableSchema.TableColumn colvarLowComplexity = new TableSchema.TableColumn(schema);
				colvarLowComplexity.ColumnName = "LowComplexity";
				colvarLowComplexity.DataType = DbType.Double;
				colvarLowComplexity.MaxLength = 0;
				colvarLowComplexity.AutoIncrement = false;
				colvarLowComplexity.IsNullable = false;
				colvarLowComplexity.IsPrimaryKey = false;
				colvarLowComplexity.IsForeignKey = false;
				colvarLowComplexity.IsReadOnly = false;
				colvarLowComplexity.DefaultSetting = @"";
				colvarLowComplexity.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLowComplexity);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SqlServer"].AddSchema("CvCMatrix",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Competency")]
		[Bindable(true)]
		public int Competency 
		{
			get { return GetColumnValue<int>(Columns.Competency); }
			set { SetColumnValue(Columns.Competency, value); }
		}
		  
		[XmlAttribute("HighComplexity")]
		[Bindable(true)]
		public double HighComplexity 
		{
			get { return GetColumnValue<double>(Columns.HighComplexity); }
			set { SetColumnValue(Columns.HighComplexity, value); }
		}
		  
		[XmlAttribute("MedComplexity")]
		[Bindable(true)]
		public double MedComplexity 
		{
			get { return GetColumnValue<double>(Columns.MedComplexity); }
			set { SetColumnValue(Columns.MedComplexity, value); }
		}
		  
		[XmlAttribute("LowComplexity")]
		[Bindable(true)]
		public double LowComplexity 
		{
			get { return GetColumnValue<double>(Columns.LowComplexity); }
			set { SetColumnValue(Columns.LowComplexity, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varCompetency,double varHighComplexity,double varMedComplexity,double varLowComplexity)
		{
			CvCMatrix item = new CvCMatrix();
			
			item.Competency = varCompetency;
			
			item.HighComplexity = varHighComplexity;
			
			item.MedComplexity = varMedComplexity;
			
			item.LowComplexity = varLowComplexity;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varCompetency,double varHighComplexity,double varMedComplexity,double varLowComplexity)
		{
			CvCMatrix item = new CvCMatrix();
			
				item.Competency = varCompetency;
			
				item.HighComplexity = varHighComplexity;
			
				item.MedComplexity = varMedComplexity;
			
				item.LowComplexity = varLowComplexity;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn CompetencyColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn HighComplexityColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn MedComplexityColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn LowComplexityColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Competency = @"Competency";
			 public static string HighComplexity = @"HighComplexity";
			 public static string MedComplexity = @"MedComplexity";
			 public static string LowComplexity = @"LowComplexity";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
