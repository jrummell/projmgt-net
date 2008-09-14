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
	/// Strongly-typed collection for the UserProfile class.
	/// </summary>
    [Serializable]
	public partial class UserProfileCollection : ActiveList<UserProfile, UserProfileCollection>
	{	   
		public UserProfileCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>UserProfileCollection</returns>
		public UserProfileCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                UserProfile o = this[i];
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
	/// This is an ActiveRecord class which wraps the UserProfile table.
	/// </summary>
	[Serializable]
	public partial class UserProfile : ActiveRecord<UserProfile>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public UserProfile()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public UserProfile(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public UserProfile(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public UserProfile(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("UserProfile", TableType.Table, DataService.GetInstance("SqlServer"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "ID";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = false;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = true;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				
					colvarId.ForeignKeyTableName = "Users";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarFirstName = new TableSchema.TableColumn(schema);
				colvarFirstName.ColumnName = "FirstName";
				colvarFirstName.DataType = DbType.AnsiString;
				colvarFirstName.MaxLength = 25;
				colvarFirstName.AutoIncrement = false;
				colvarFirstName.IsNullable = true;
				colvarFirstName.IsPrimaryKey = false;
				colvarFirstName.IsForeignKey = false;
				colvarFirstName.IsReadOnly = false;
				colvarFirstName.DefaultSetting = @"";
				colvarFirstName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFirstName);
				
				TableSchema.TableColumn colvarLastName = new TableSchema.TableColumn(schema);
				colvarLastName.ColumnName = "LastName";
				colvarLastName.DataType = DbType.AnsiString;
				colvarLastName.MaxLength = 25;
				colvarLastName.AutoIncrement = false;
				colvarLastName.IsNullable = true;
				colvarLastName.IsPrimaryKey = false;
				colvarLastName.IsForeignKey = false;
				colvarLastName.IsReadOnly = false;
				colvarLastName.DefaultSetting = @"";
				colvarLastName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLastName);
				
				TableSchema.TableColumn colvarAddress = new TableSchema.TableColumn(schema);
				colvarAddress.ColumnName = "Address";
				colvarAddress.DataType = DbType.AnsiString;
				colvarAddress.MaxLength = 150;
				colvarAddress.AutoIncrement = false;
				colvarAddress.IsNullable = true;
				colvarAddress.IsPrimaryKey = false;
				colvarAddress.IsForeignKey = false;
				colvarAddress.IsReadOnly = false;
				colvarAddress.DefaultSetting = @"";
				colvarAddress.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAddress);
				
				TableSchema.TableColumn colvarCity = new TableSchema.TableColumn(schema);
				colvarCity.ColumnName = "City";
				colvarCity.DataType = DbType.AnsiString;
				colvarCity.MaxLength = 50;
				colvarCity.AutoIncrement = false;
				colvarCity.IsNullable = true;
				colvarCity.IsPrimaryKey = false;
				colvarCity.IsForeignKey = false;
				colvarCity.IsReadOnly = false;
				colvarCity.DefaultSetting = @"";
				colvarCity.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCity);
				
				TableSchema.TableColumn colvarState = new TableSchema.TableColumn(schema);
				colvarState.ColumnName = "State";
				colvarState.DataType = DbType.AnsiString;
				colvarState.MaxLength = 2;
				colvarState.AutoIncrement = false;
				colvarState.IsNullable = true;
				colvarState.IsPrimaryKey = false;
				colvarState.IsForeignKey = false;
				colvarState.IsReadOnly = false;
				colvarState.DefaultSetting = @"";
				colvarState.ForeignKeyTableName = "";
				schema.Columns.Add(colvarState);
				
				TableSchema.TableColumn colvarZip = new TableSchema.TableColumn(schema);
				colvarZip.ColumnName = "Zip";
				colvarZip.DataType = DbType.AnsiString;
				colvarZip.MaxLength = 10;
				colvarZip.AutoIncrement = false;
				colvarZip.IsNullable = true;
				colvarZip.IsPrimaryKey = false;
				colvarZip.IsForeignKey = false;
				colvarZip.IsReadOnly = false;
				colvarZip.DefaultSetting = @"";
				colvarZip.ForeignKeyTableName = "";
				schema.Columns.Add(colvarZip);
				
				TableSchema.TableColumn colvarPhoneNumber = new TableSchema.TableColumn(schema);
				colvarPhoneNumber.ColumnName = "PhoneNumber";
				colvarPhoneNumber.DataType = DbType.AnsiString;
				colvarPhoneNumber.MaxLength = 13;
				colvarPhoneNumber.AutoIncrement = false;
				colvarPhoneNumber.IsNullable = true;
				colvarPhoneNumber.IsPrimaryKey = false;
				colvarPhoneNumber.IsForeignKey = false;
				colvarPhoneNumber.IsReadOnly = false;
				colvarPhoneNumber.DefaultSetting = @"";
				colvarPhoneNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPhoneNumber);
				
				TableSchema.TableColumn colvarEmail = new TableSchema.TableColumn(schema);
				colvarEmail.ColumnName = "Email";
				colvarEmail.DataType = DbType.AnsiString;
				colvarEmail.MaxLength = 30;
				colvarEmail.AutoIncrement = false;
				colvarEmail.IsNullable = true;
				colvarEmail.IsPrimaryKey = false;
				colvarEmail.IsForeignKey = false;
				colvarEmail.IsReadOnly = false;
				colvarEmail.DefaultSetting = @"";
				colvarEmail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmail);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SqlServer"].AddSchema("UserProfile",schema);
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
		  
		[XmlAttribute("FirstName")]
		[Bindable(true)]
		public string FirstName 
		{
			get { return GetColumnValue<string>(Columns.FirstName); }
			set { SetColumnValue(Columns.FirstName, value); }
		}
		  
		[XmlAttribute("LastName")]
		[Bindable(true)]
		public string LastName 
		{
			get { return GetColumnValue<string>(Columns.LastName); }
			set { SetColumnValue(Columns.LastName, value); }
		}
		  
		[XmlAttribute("Address")]
		[Bindable(true)]
		public string Address 
		{
			get { return GetColumnValue<string>(Columns.Address); }
			set { SetColumnValue(Columns.Address, value); }
		}
		  
		[XmlAttribute("City")]
		[Bindable(true)]
		public string City 
		{
			get { return GetColumnValue<string>(Columns.City); }
			set { SetColumnValue(Columns.City, value); }
		}
		  
		[XmlAttribute("State")]
		[Bindable(true)]
		public string State 
		{
			get { return GetColumnValue<string>(Columns.State); }
			set { SetColumnValue(Columns.State, value); }
		}
		  
		[XmlAttribute("Zip")]
		[Bindable(true)]
		public string Zip 
		{
			get { return GetColumnValue<string>(Columns.Zip); }
			set { SetColumnValue(Columns.Zip, value); }
		}
		  
		[XmlAttribute("PhoneNumber")]
		[Bindable(true)]
		public string PhoneNumber 
		{
			get { return GetColumnValue<string>(Columns.PhoneNumber); }
			set { SetColumnValue(Columns.PhoneNumber, value); }
		}
		  
		[XmlAttribute("Email")]
		[Bindable(true)]
		public string Email 
		{
			get { return GetColumnValue<string>(Columns.Email); }
			set { SetColumnValue(Columns.Email, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a User ActiveRecord object related to this UserProfile
		/// 
		/// </summary>
		public PMT.DAL.User User
		{
			get { return PMT.DAL.User.FetchByID(this.Id); }
			set { SetColumnValue("ID", value.Id); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varId,string varFirstName,string varLastName,string varAddress,string varCity,string varState,string varZip,string varPhoneNumber,string varEmail)
		{
			UserProfile item = new UserProfile();
			
			item.Id = varId;
			
			item.FirstName = varFirstName;
			
			item.LastName = varLastName;
			
			item.Address = varAddress;
			
			item.City = varCity;
			
			item.State = varState;
			
			item.Zip = varZip;
			
			item.PhoneNumber = varPhoneNumber;
			
			item.Email = varEmail;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varFirstName,string varLastName,string varAddress,string varCity,string varState,string varZip,string varPhoneNumber,string varEmail)
		{
			UserProfile item = new UserProfile();
			
				item.Id = varId;
			
				item.FirstName = varFirstName;
			
				item.LastName = varLastName;
			
				item.Address = varAddress;
			
				item.City = varCity;
			
				item.State = varState;
			
				item.Zip = varZip;
			
				item.PhoneNumber = varPhoneNumber;
			
				item.Email = varEmail;
			
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
        
        
        
        public static TableSchema.TableColumn FirstNameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn LastNameColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn AddressColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CityColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn StateColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ZipColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn PhoneNumberColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn EmailColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string FirstName = @"FirstName";
			 public static string LastName = @"LastName";
			 public static string Address = @"Address";
			 public static string City = @"City";
			 public static string State = @"State";
			 public static string Zip = @"Zip";
			 public static string PhoneNumber = @"PhoneNumber";
			 public static string Email = @"Email";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
