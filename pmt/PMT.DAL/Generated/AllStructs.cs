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
	#region Tables Struct
	public partial struct Tables
	{
		
		public static string CvCMatrix = @"CvCMatrix";
        
		public static string ManagerAssignment = @"ManagerAssignments";
        
		public static string MessageRecipient = @"MessageRecipients";
        
		public static string Message = @"Messages";
        
		public static string ModuleX = @"Modules";
        
		public static string ProjectAssignment = @"ProjectAssignments";
        
		public static string Project = @"Projects";
        
		public static string TaskAssignment = @"TaskAssignments";
        
		public static string Task = @"Tasks";
        
		public static string UserProfile = @"UserProfile";
        
		public static string User = @"Users";
        
	}
	#endregion
    #region Schemas
    public partial class Schemas {
		
		public static TableSchema.Table CvCMatrix{
            get { return DataService.GetSchema("CvCMatrix","SqlServer"); }
		}
        
		public static TableSchema.Table ManagerAssignment{
            get { return DataService.GetSchema("ManagerAssignments","SqlServer"); }
		}
        
		public static TableSchema.Table MessageRecipient{
            get { return DataService.GetSchema("MessageRecipients","SqlServer"); }
		}
        
		public static TableSchema.Table Message{
            get { return DataService.GetSchema("Messages","SqlServer"); }
		}
        
		public static TableSchema.Table ModuleX{
            get { return DataService.GetSchema("Modules","SqlServer"); }
		}
        
		public static TableSchema.Table ProjectAssignment{
            get { return DataService.GetSchema("ProjectAssignments","SqlServer"); }
		}
        
		public static TableSchema.Table Project{
            get { return DataService.GetSchema("Projects","SqlServer"); }
		}
        
		public static TableSchema.Table TaskAssignment{
            get { return DataService.GetSchema("TaskAssignments","SqlServer"); }
		}
        
		public static TableSchema.Table Task{
            get { return DataService.GetSchema("Tasks","SqlServer"); }
		}
        
		public static TableSchema.Table UserProfile{
            get { return DataService.GetSchema("UserProfile","SqlServer"); }
		}
        
		public static TableSchema.Table User{
            get { return DataService.GetSchema("Users","SqlServer"); }
		}
        
	
    }
    #endregion
    #region View Struct
    public partial struct Views 
    {
		
    }
    #endregion
    
    #region Query Factories
	public static partial class DB
	{
        public static DataProvider _provider = DataService.Providers["SqlServer"];
        static ISubSonicRepository _repository;
        public static ISubSonicRepository Repository {
            get {
                if (_repository == null)
                    return new SubSonicRepository(_provider);
                return _repository; 
            }
            set { _repository = value; }
        }
	
        public static Select SelectAllColumnsFrom<T>() where T : RecordBase<T>, new()
	    {
            return Repository.SelectAllColumnsFrom<T>();
            
	    }
	    public static Select Select()
	    {
            return Repository.Select();
	    }
	    
		public static Select Select(params string[] columns)
		{
            return Repository.Select(columns);
        }
	    
		public static Select Select(params Aggregate[] aggregates)
		{
            return Repository.Select(aggregates);
        }
   
	    public static Update Update<T>() where T : RecordBase<T>, new()
	    {
            return Repository.Update<T>();
	    }
     
	    
	    public static Insert Insert()
	    {
            return Repository.Insert();
	    }
	    
	    public static Delete Delete()
	    {
            
            return Repository.Delete();
	    }
	    
	    public static InlineQuery Query()
	    {
            
            return Repository.Query();
	    }
	    	    
	    
	}
    #endregion
    
}
#region Databases
public partial struct Databases 
{
	
	public static string SqlServer = @"SqlServer";
    
}
#endregion