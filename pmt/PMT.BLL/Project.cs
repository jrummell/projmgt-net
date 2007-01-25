using System;
using System.Collections;
using System.Diagnostics;
using System.Data;

namespace PMT.BLL
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
        public ProjectItemType Type
        {
            get 
            {
                string className = this.ToString().Substring(this.ToString().IndexOf('.')+1);
                return (ProjectItemType) Enum.Parse(typeof(ProjectItemType), className);
            }
        }
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public int ID
        {
            get {   return id;  }
            set {   id = value; }
        }
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name
        {
            get {   return name;    }
            set {   name = value;   }
        }
        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description
        {
            get {   return description;     }
            set {   description = value;    }
        }
        /// <summary>
        /// Gets or sets the start date
        /// </summary>
        public DateTime StartDate
        {
            get {   return startDate;   }
            set {   startDate = value;  }
        }
        /// <summary>
        /// Gets or sets the expected end date
        /// </summary>
        public DateTime ExpEndDate
        {
            get {   return expEndDate;  }
            set {   expEndDate = value; }
        }
        /// <summary>
        /// Gets or sets the actual end date
        /// </summary>
        public DateTime ActEndDate
        {
            get {   return actEndDate;  }
            set {   actEndDate = value; }
        }
        #endregion
    }
    #endregion

    #region Project
	/// <summary>
	/// A project item
	/// </summary>
    public class Project : ProjectItem
    {
        private int mgrID;

        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="id">project id</param>
        /// <param name="mgrID">manager id</param>
        /// <param name="name">name</param>
        /// <param name="description">description</param>
        /// <param name="startDate">start date</param>
        /// <param name="expEndDate">expected end date</param>
        /// <param name="actEndDate">actual end date</param>
        public Project(int id, int mgrID, string name, string description, DateTime startDate, DateTime expEndDate, DateTime actEndDate)
            : base(id, name, description, startDate, expEndDate, actEndDate)
        {
            this.mgrID = mgrID;
        }

        /// <summary>
        /// Constructor used for a new Project
        /// </summary>
        /// <param name="mgrID">manager id</param>
        /// <param name="name">name</param>
        /// <param name="description">description</param>
        /// <param name="startDate">start date</param>
        public Project(int mgrID, string name, string description, DateTime startDate)
            : this(0, mgrID, name, description, startDate, DateTime.MinValue, DateTime.MinValue) {}

        /// <summary>
        /// Gets or sets the manager id assigned to this project
        /// </summary>
        public int ManagerID
        {
            get {   return mgrID;   }
            set {   mgrID = value;  }
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

        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="id">Module id</param>
        /// <param name="projID">Project id</param>
        /// <param name="name">name</param>
        /// <param name="description">description</param>
        /// <param name="startDate">start date</param>
        /// <param name="expEndDate">expected end date</param>
        /// <param name="actEndDate">actual end date</param>
        public Module(int id, int projID, string name, string description, 
            DateTime startDate, DateTime expEndDate, DateTime actEndDate)
            : base(id, name, description, startDate, expEndDate, actEndDate)
        {
            this.projID = projID;
        }

        /// <summary>
        /// Constructor used for a new Module
        /// </summary>
        /// <param name="projID">Project id</param>
        /// <param name="name">name</param>
        /// <param name="description">description</param>
        /// <param name="startDate">start date</param>
        public Module(int projID, string name, string description, DateTime startDate)
            : this(0, projID, name, description, startDate, DateTime.MinValue, DateTime.MinValue) {}
       

        /// <summary>
        /// Gets or sets the Project id this Module belongs to
        /// </summary>
        public int ProjectID
        {
            get {   return projID;  }
            set {   projID = value; }
        }
	}
    #endregion

    #region Task
    /// <summary>
    /// Task Statuses
    /// </summary>
    public enum TaskStatus { Unassigned=0, InProgress, Complete, Approved }
    /// <summary>
    /// Task Complexities
    /// </summary>
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

        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="id">Task id</param>
        /// <param name="modID">Module id</param>
        /// <param name="projID">Project id</param>
        /// <param name="name">name</param>
        /// <param name="description">description</param>
        /// <param name="complexity">complexity</param>
        /// <param name="startDate">start date</param>
        /// <param name="expEndDate">expected end date</param>
        /// <param name="actEndDate">actual end date</param>
       public Task(int id, int modID, int projID, string name, string description, TaskComplexity complexity, 
            DateTime startDate, DateTime expEndDate, DateTime actEndDate)
            : base(id, name, description, startDate, expEndDate, actEndDate)
        {
            this.modID = modID;
            this.projID = projID;
            this.complexity = complexity;
        }

        /// <summary>
        /// Constructor used for a new task
        /// </summary>
        /// <param name="modID">Module id</param>
        /// <param name="projID">Project id</param>
        /// <param name="name">name</param>
        /// <param name="description">description</param>
        /// <param name="complexity">complexity</param>
        /// <param name="startDate">start date</param>
        public Task(int modID, int projID, string name, string description, 
            TaskComplexity complexity, DateTime startDate)
            : this(0, modID, projID, name, description, complexity, 
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
    }
    #endregion
}
