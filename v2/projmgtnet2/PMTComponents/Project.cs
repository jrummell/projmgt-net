using System;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PMTComponents
{
    #region ProjectItem
    /// <summary>
    /// The type of the Project Item ...
    /// </summary>
    public enum ProjectItemType { Project=0, Module, Task   }

    /// <summary>
    /// Base class for Project, Module, Task
    /// </summary>
    public abstract class ProjectItem
    {
        protected string name;
        protected int id;
        protected string description;
        protected DateTime startDate;
        protected DateTime expEndDate;
        protected DateTime actEndDate;

        #region Constructors
        /// <summary>
        /// Main Constructor
        /// </summary>
        internal ProjectItem(int id, string name, string description, 
            DateTime startDate, DateTime expEndDate, DateTime actEndDate)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.startDate  = startDate;
            this.expEndDate = expEndDate;
            this.actEndDate = actEndDate;
        }

        /// <summary>
        /// Creates a blank ProjectItem
        /// </summary>
        internal ProjectItem()
            : this(0, "", "", DateTime.MinValue, DateTime.MinValue, DateTime.MinValue) {}
        #endregion
 
        #region Properties
        public int ID
        {
            get {   return id;  }
            set {   id = value; }
        }
        public string Name
        {
            get {   return name;    }
            set {   name = value;   }
        }
        public string Description
        {
            get {   return description;     }
            set {   description = value;    }
        }
        public DateTime StartDate
        {
            get {   return startDate;   }
            set {   startDate = value;  }
        }
        public DateTime ExpEndDate
        {
            get {   return expEndDate;  }
            set {   expEndDate = value; }
        }
        public DateTime ActEndDate
        {
            get {   return actEndDate;  }
            set {   actEndDate = value; }
        }
        #endregion

        /// <summary>
        /// Return the ProjectItem as Html
        /// </summary>
        /// <returns></returns>
        public abstract string RenderHtml();
    }
    #endregion

    #region Project
	/// <summary>
	/// A project item
	/// </summary>
    public class Project : ProjectItem
    {
        private int mgrID;

        public Project(int id, int mgrID, string name, string description, DateTime startDate, DateTime expEndDate, DateTime actEndDate)
            : base(id, name, description, startDate, expEndDate, actEndDate)
        {
            this.mgrID = mgrID;
        }

        public Project(int mgrID, string name, string description, DateTime startDate)
            : this(-1, mgrID, name, description, startDate, DateTime.MinValue, DateTime.MinValue) {}

        /// <summary>
        /// ID of the ProjectManager assigned to this Project
        /// </summary>
        public int ManagerID
        {
            get {   return mgrID;   }
            set {   mgrID = value;  }
        }
        
        public override string RenderHtml()
        {
            return "";
        }
	}
    #endregion

    #region Module
    /// <summary>
    /// A module report item
    /// </summary>
	public class Module : ProjectItem
	{
        private int projID;

        public Module(int id, int projID, string name, string description, 
            DateTime startDate, DateTime expEndDate, DateTime actEndDate)
            : base(id, name, description, startDate, expEndDate, actEndDate)
        {
            this.projID = projID;
        }

        public Module(int projID, string name, string description, DateTime startDate)
            : this(-1, projID, name, description, startDate, DateTime.MinValue, DateTime.MinValue) {}
       

        /// <summary>
        /// Get the Project id this Module belongs to
        /// </summary>
        public int ProjectID
        {
            get {   return projID;  }
            set {   projID = value; }
        }
        
        public override string RenderHtml()
        {
            return "";
        }
	}
    #endregion

    #region Task
    /// <summary>
    /// The Status of a Task
    /// </summary>
    public enum TaskStatus { Unassigned=0, InProgress, Complete, Approved }
    public enum TaskComplexity { Low=0, Medium, High }

    /// <summary>
    /// A task report item
    /// </summary>
	public class Task : ProjectItem
	{
        private int devID;
        private int modID;
        private int projID;
        private TaskStatus status;
        private TaskComplexity complexity;

       public Task(int id, int modID, int projID, string name, string description, TaskComplexity complexity, 
            DateTime startDate, DateTime expEndDate, DateTime actEndDate)
            : base(id, name, description, startDate, expEndDate, actEndDate)
        {
            this.modID = modID;
            this.projID = projID;
            this.complexity = complexity;
        }

        public Task(int modID, int projID, string name, string description, 
            TaskComplexity complexity, DateTime startDate)
            : this(-1, modID, projID, name, description, complexity, 
                startDate, DateTime.MinValue, DateTime.MinValue) {}


        #region Properties
        public int DeveloperID
        {
            get {   return devID;   }
            set {   devID = value;  }
        }
        public int ModuleID
        {
            get {   return modID;   }
            set {   modID = value;  }
        }
        public int ProjectID
        {
            get {   return projID;   }
            set {   projID = value;  }
        }
        public TaskStatus Status
        {
            get {   return status;  }
            set {   status = value; }
        }
        #endregion
	
        public override string RenderHtml()
        {
            return "";
        }
    }
    #endregion
}
