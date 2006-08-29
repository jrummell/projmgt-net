using System;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;



namespace PMT
{
    /// <summary>
    /// A Project Item, super class for Project, Module, Task
    /// </summary>
    public abstract class ProjectItem
    {
        /// <summary>
        /// Project Item Types
        /// </summary>
        public struct ItemType
        {
            public const string PROJECT = "Project";
            public const string MODULE = "Module";
            public const string TASK = "Task";
        };

        protected string name;
        protected string id;
        protected string description;
        protected string startDate;
        protected string expEndDate;
        protected string actEndDate;
        
        protected const string percentFormatter = "###.00%;###.00%;0.00%;";

        protected DBDriver myDB;

        /// <summary>
        /// Create a Project Item, ONLY CALLED BY SubClasses
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="startDate"></param>
        protected ProjectItem(string name, string description, string startDate)
        {
            this.name = name;
            this.description = description;
            this.startDate = startDate;
        }

        /// <summary>
        /// Set the id field, ONLY CALLED BY SubClasses
        /// </summary>
        /// <param name="id"></param>
        protected ProjectItem(string id)
        {
            this.id = id;
        }
 
        /// <summary>
        /// Update a Project Item
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="desc">Description</param>
        /// <param name="startDate">Start Date</param>
        public void update(string name, string desc, string startDate)
        {
            this.name = name;
            this.description = desc;
            this.startDate = startDate;
        }

        /// <summary>
        /// Public properties
        ///  do we want setters???
        /// </summary>
        public string Name
        {
            get {   return name;    }
        }

        public string ID
        {
            get {   return id;  }
        }

        public string Description
        {
            get {   return description; }
        }

        public string StartDate
        {
            get {   return startDate;   }
        }

        public string ExpEndDate
        {
            get {   return expEndDate;  }
        }

        public string ActEndDate
        {
            get {   return actEndDate;  }
        }
    }
	/// <summary>
	/// A project item
	/// </summary>
    public class Project : ProjectItem
    {
        protected string mgrID;

        /// <summary>
        /// Create a project object from the database
        /// </summary>
        /// <param name="id">a project id</param>
        public Project(string id)
            : base(id)
        {
            myDB = new DBDriver();
            myDB.Query = "select * from projects \n" + 
                "where ID = @ID;";
            myDB.addParam("@ID", id);

            DataSet ds = new DataSet();
            myDB.createAdapter().Fill(ds);
            DataTable table = ds.Tables[0];
            DataRow row = table.Rows[0];

            this.name = row["Name"].ToString();
            this.id = row["id"].ToString();
            this.mgrID = row["managerID"].ToString();
            this.description = row["description"].ToString();
            this.startDate = row["startDate"].ToString();
            this.expEndDate = row["expEndDate"].ToString();
            this.actEndDate = row["actEndDate"].ToString();
        }

        public Project(string name, string mgrID, string description, string startDate)
            : base(name, description, startDate)
        {
            DBDriver db = new DBDriver();
            // Create Adapter
            db.Query = "select * from Projects";
            SqlDataAdapter da = db.createAdapter();
            // We need this to get an ID back from the database
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            // Create and initialize CommandBuilder
            SqlCommandBuilder dbCB = new SqlCommandBuilder(da);

            // New DataSet
            DataSet ds = new DataSet();
            // Populate DataSet with data
            da.Fill(ds, "Projects");

            // Get reference to our table
            DataTable table = ds.Tables["Projects"];
            // Create new row
            DataRow  row = table.NewRow();
            // Store data in the row
            row["Name"] = this.name = name;
            row["managerID"] = this.mgrID = mgrID;
            row["description"] = this.description = description;
            row["startDate"] = this.startDate = startDate;
            // Add row back to table
            table.Rows.Add(row);

            // Update data source
            da.Update(ds, "Projects");

            // Get newFileID
            if( !row.IsNull("ID") )
                id = row["ID"].ToString();

        }

        /// <summary>
        /// Insert a Project in the database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mID">Assigned manager</param>
        /// <param name="description"></param>
        /// <param name="startDate">Start date</param>
        public static void create(string name, string mID, string description, string startDate)
        {
            DBDriver myDB = new DBDriver();
            myDB.Query="insert into projects (name, managerID, description, startDate) \n"
                +"values ( @name, @mID, @desc, @start, @end );";

            myDB.addParam("@name", name);
            myDB.addParam("@mID", mID);
            myDB.addParam("@desc", description);
            myDB.addParam("@start", startDate);
        
            myDB.nonQuery();
        }

        /// <summary>
        /// Update a Project
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="startDate"></param>
        new public void update(string name, string description, string startDate)
        {
            base.update(name, description, startDate);

            DBDriver myDB = new DBDriver();
            myDB.Query="update projects \n" 
                +"set name=@name, description=@desc, startDate=@start \n"
                +"where id=@id;";

            myDB.addParam("@id", this.id);
            myDB.addParam("@name", name);
            myDB.addParam("@desc", description);
            myDB.addParam("@start", startDate);

            myDB.nonQuery();
        }

        /// <summary>
        /// Remove a Project
        /// </summary>
        /// <param name="id">project id</param>
        public static void remove(string id)
        {
            DBDriver myDB = new DBDriver();
            myDB.Query = "delete from Projects where id=@id";
            myDB.addParam("@id", id);
            myDB.nonQuery();
        }

        /// <summary>
        /// Get a Project DataSet by its id
        /// </summary>
        /// <param name="id">Project id</param>
        /// <returns>Filled DataSet</returns>
        public static DataSet getByID(string id)
        {
            DBDriver myDB = new DBDriver();
            myDB.Query = "select * from projects \n" + 
                "where ID = @ID;";
            myDB.addParam("@ID", id);

            DataSet ds = new DataSet();
            myDB.createAdapter().Fill(ds);
            
            return ds;
        }

        /// <summary>
        /// Gets a DataSet filled with a projects fields
        /// </summary>
        public DataSet getDataSet()
        {
            DBDriver myDB = new DBDriver();
            myDB.Query = 
                "select * from projects \n" + 
                "where ID = @ID;";
            myDB.addParam("@ID", id);

            DataSet ds = new DataSet();
            myDB.createAdapter().Fill(ds);
            
            return ds;
        }

        /// <summary>
        /// Gets a DataSet with all Projects
        /// </summary>
        /// <returns></returns>
        public static DataSet getProjectsDataSet()
        {
            DBDriver myDB = new DBDriver();
            myDB.Query = "select * from projects;";

            DataSet ds = new DataSet();
            myDB.createAdapter().Fill(ds);
            
            return ds;
        }

        /// <summary>
        /// Gets a DataSet with Projects assigned to a PM 
        /// </summary>
        /// <param name="mgrID">Project Manager</param>
        /// <returns></returns>
        public static DataSet getProjectsDataSet(string mgrID)
        {
            DBDriver myDB = new DBDriver();
            myDB.Query = "select * from projects \n"
                +"where managerID=@mgrID;";
            myDB.addParam("@mgrID", mgrID);

            DataSet ds = new DataSet();
            myDB.createAdapter().Fill(ds);
            
            return ds;
        }

        /// <summary>
        /// Gets a DataSet of Modules in the Project
        /// </summary>
        /// <returns>Module DataSet</returns>
        public DataSet getModulesDataSet()
        {
            myDB.Query = "select * from modules\n" +
                "where projectID = @ID;";
            myDB.addParam("@ID", id);

            DataSet ds = new DataSet();
            myDB.createAdapter().Fill(ds);
            return ds;
        }

        
        /// <summary>
        /// ID of the ProjectManager assigned to this Project
        /// </summary>
        public string ProjectManagerID
        {
            get {   return mgrID;   }
        }
        

//        public static void assignManager(string mID)
//        {
//            myDB.Query = "update Projects set managerID=@mID where ";
//        }

        /// <summary>
        /// Gets the percent of tasks complete in this project
        /// </summary>
        public string PercentComplete
        {
            get
            {
                int count = 0;
                int approved = 0;

                DataTable modsTable = this.getModulesDataSet().Tables[0];
                foreach (DataRow modRow in modsTable.Rows)
                {
                    DataTable tasksTable = new Module(modRow["id"].ToString()).getTasksDataSet().Tables[0];
                    foreach (DataRow taskRow in tasksTable.Rows)
                    {
                        if (taskRow["complete"].ToString().Equals(TaskStatus.APPROVED))
                            approved++;
                        count++;
                    }
                }
                double pct = (double)approved/(double)count;
                if (Double.IsNaN(pct))
                    pct = 0;
                return Convert.ToString(pct.ToString(percentFormatter));
            }
        }

	}

    /// <summary>
    /// A module report item
    /// </summary>
	public class Module : ProjectItem
	{
        private string projID;

        /// <summary>
        /// Create a Module object from an existing module in database
        /// </summary>
        /// <param name="id">An existing module id</param>
        public Module(string id)
            : base(id)
        {
            this.myDB = new DBDriver();
            myDB.Query = "select * from modules \n" + 
                "where ID = @ID;";
            myDB.addParam("@ID", id);

            DataSet ds = new DataSet();
            myDB.createAdapter().Fill(ds);
            DataTable table = ds.Tables[0];
            DataRow row = table.Rows[0];

            this.name = row["Name"].ToString();
            this.id = row["id"].ToString();
            this.projID = row["projectID"].ToString();
            this.description = row["description"].ToString();
            this.startDate = row["startDate"].ToString();
            this.expEndDate = row["expEndDate"].ToString();
            this.actEndDate = row["actEndDate"].ToString();
        }

        public Module(string name, string projectID, string description, string startDate)
            : base(name, description, startDate)
        {
            DBDriver db = new DBDriver();
            // Create Adapter
            db.Query = "select * from Modules";
            SqlDataAdapter da = db.createAdapter();
            // We need this to get an ID back from the database
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            // Create and initialize CommandBuilder
            SqlCommandBuilder dbCB = new SqlCommandBuilder(da);

            // New DataSet
            DataSet ds = new DataSet();
            // Populate DataSet with data
            da.Fill(ds, "Modules");

            // Get reference to our table
            DataTable table = ds.Tables["Modules"];
            // Create new row
            DataRow  row = table.NewRow();
            // Store data in the row
            row["Name"] = this.name = name;
            row["projectID"] = this.projID = projectID;
            row["description"] = this.description = description;
            row["startDate"] = this.startDate = startDate;
            // Add row back to table
            table.Rows.Add(row);

            // Update data source
            da.Update(ds, "Modules");

            // Get newFileID
            if( !row.IsNull("ID") )
                id = row["ID"].ToString();

        }
        
        /// <summary>
        /// Insert a Module in the database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pID">Project to add to</param>
        /// <param name="description"></param>
        /// <param name="startDate">Start date</param>
        public static void create(string name, string pID, string description, string startDate)
        {
            DBDriver myDB = new DBDriver();
            myDB.Query="insert into modules (name, projectID, description, startDate) \n"
                +"values ( @name, @pID, @desc, @start);";

            myDB.addParam("@name", name);
            myDB.addParam("@pID", pID);
            myDB.addParam("@desc", description);
            myDB.addParam("@start", startDate);
            
            myDB.nonQuery();
        }

        /// <summary>
        /// Update a module
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="startDate"></param>
        new public void update(string name, string description, string startDate)
        {
            base.update(name, description, startDate);

            DBDriver myDB = new DBDriver();
            myDB.Query="update modules \n" 
                +"set name=@name, description=@desc, startDate=@start \n"
                +"where id=@id;";

            myDB.addParam("@id", this.id);
            myDB.addParam("@name", name);
            myDB.addParam("@desc", description);
            myDB.addParam("@start", startDate);
            
            myDB.nonQuery();
        }

        /// <summary>
        /// Remove a Module
        /// </summary>
        /// <param name="id">project id</param>
        public static void remove(string id)
        {
            DBDriver myDB = new DBDriver();
            myDB.Query = "delete from Modules where id=@id";
            myDB.addParam("@id", id);
            myDB.nonQuery();
        }

        /// <summary>
        /// Get a Module DataSet by its id
        /// </summary>
        /// <param name="id">Project id</param>
        /// <returns>Filled DataSet</returns>
        public static DataSet getByID(string id)
        {
            DBDriver myDB = new DBDriver();
            myDB.Query = "select * from modules \n" + 
                "where ID = @ID;";
            myDB.addParam("@ID", id);

            DataSet ds = new DataSet();
            myDB.createAdapter().Fill(ds);
            
            return ds;
        }

        /// <summary>
        /// Gets all Tasks in the Module
        /// </summary>
        /// <returns>Tasks DataSet</returns>
        public DataSet getTasksDataSet()
        {
            myDB.Query = "select * from tasks\n" +
                "where moduleID = @ID;";
            myDB.addParam("@ID", id);

            DataSet ds = new DataSet();
            myDB.createAdapter().Fill(ds);
            return ds;
        }

        /// <summary>
        /// Gets a DataSet of Modules in the Project
        /// </summary>
        /// <param name="id">Project id</param>
        /// <returns>Module DataSet</returns>
        public static DataSet getModulesDataSet(string id)
        {
            DBDriver myDB = new DBDriver();
            myDB.Query = "select * from modules\n" +
                "where projectID = @ID;";
            myDB.addParam("@ID", id);

            DataSet ds = new DataSet();
            myDB.createAdapter().Fill(ds);
            return ds;
        }

		// TODO: removeTask

        /// <summary>
        /// Get the Project id this Module belongs to
        /// </summary>
        public string ProjectID
        {
            get {   return projID;  }
        }
        
        /// <summary>
        /// Gets the percent of tasks complete
        /// </summary>
        public string PercentComplete
        {
            get
            {
                int count = 0;
                int approved = 0;

                DataTable dt = this.getTasksDataSet().Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    if (row["complete"].ToString().Equals(TaskStatus.APPROVED))
                        approved++;
                    count++;
                }
                double pct = (double)approved/(double)count;
                if (Double.IsNaN(pct))
                    pct = 0;
                return Convert.ToString(pct.ToString(percentFormatter));
            }
        }
	}

    /// <summary>
    /// The Status of a Task
    /// </summary>
    public struct TaskStatus
    {
        public const string COMPLETE   = "Complete";   // dev marks complete
        public const string APPROVED   = "Approved";   // pm marks approved
        public const string INPROGRESS = "In Progress";    // set when assigned
        //public const string NOTSTARTED = "Not Started";
        public const string UNASSIGNED = "Unassigned"; // initial value
    }

    /// <summary>
    /// A task report item
    /// </summary>
	public class Task : ProjectItem
	{
        string devID;
        string modID;
        string status;
        string complexity;

        /// <summary>
        /// Create a Task object from an existing task in database
        /// </summary>
        /// <param name="id">An existing task id</param>
        public Task(string id)
            :base(id)
        {
            this.myDB = new DBDriver();
            myDB.Query = "select tasks.name as name, tasks.id as id, tasks.moduleID as modID, tasks.description as description,\n"
                + "tasks.startDate as startDate, tasks.expEndDate as expEndDate, tasks.actEndDate as actEndDate,\n"
                + "tasks.complete as complete, tasks.complexity as complexity\n"
                + "from tasks, assignments \n"
                + "where tasks.ID = @taskID \n";
            myDB.addParam("@taskID", id);

            DataSet ds = new DataSet();
            myDB.createAdapter().Fill(ds);
            DataTable table = ds.Tables[0];
            DataRow row = table.Rows[0];

            this.name = row["Name"].ToString();
            this.id = row["id"].ToString();
            this.modID = row["modID"].ToString();
            this.description = row["description"].ToString();
            this.startDate = row["startDate"].ToString();
            this.expEndDate = row["expEndDate"].ToString();
            this.actEndDate = row["actEndDate"].ToString();
            this.status = row["complete"].ToString();
            this.complexity = row["complexity"].ToString();

            // check for an assigned developer
            myDB.Query = "select assignments.devID as devID\n"
            			+ "from assignments\n"
            			+ "where assignments.taskID = @taskID;";
			myDB.addParam("@taskID", id);

            myDB.addParam("@id", this.id);
            ds = new DataSet();
            myDB.createAdapter().Fill(ds);
            table = ds.Tables[0];
            if (table.Rows.Count > 0)
            {
                row = table.Rows[0];

                if (!row["devID"].ToString().Equals(String.Empty))
                {
                    this.devID = row["devID"].ToString();
                }
            }
        }

        public Task(string name, string moduleID, string description, string startDate, string compexity)
            : base(name, description, startDate)
        {
            DBDriver db = new DBDriver();
            // Create Adapter
            db.Query = "select * from Tasks";
            SqlDataAdapter da = db.createAdapter();
            // We need this to get an ID back from the database
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            // Create and initialize CommandBuilder
            SqlCommandBuilder dbCB = new SqlCommandBuilder(da);

            // New DataSet
            DataSet ds = new DataSet();
            // Populate DataSet with data
            da.Fill(ds, "Tasks");

            // Get reference to our table
            DataTable table = ds.Tables["Tasks"];
            // Create new row
            DataRow  row = table.NewRow();
            // Store data in the row
            row["Name"] = this.name = name;
            row["moduleID"] = this.modID = moduleID;
            row["description"] = this.description = description;
            row["startDate"] = this.startDate = startDate;
            row["complete"] = this.status = TaskStatus.UNASSIGNED;
            row["complexity"] = this.complexity = compexity;
            // Add row back to table
            table.Rows.Add(row);

            // Update data source
            da.Update(ds, "Tasks");

            // Get newFileID
            if( !row.IsNull("ID") )
                id = row["ID"].ToString();

        }

        /// <summary>
        /// Insert a Task in the database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mID">Module to add to</param>
        /// <param name="description"></param>
        /// <param name="startDate">Start date</param>
        public static void create(string name, string mID, string description, string startDate)
        {
            DBDriver myDB = new DBDriver();
            myDB.Query="insert into tasks (name, moduleID, description, startDate, complete) \n"
                +"values ( @name, @mID, @desc, @start, @complete );";

            myDB.addParam("@name", name);
            myDB.addParam("@mID", mID);
            myDB.addParam("@desc", description);
            myDB.addParam("@start", startDate);
            myDB.addParam("@complete", PMT.TaskStatus.UNASSIGNED);

            myDB.nonQuery();
        }

        /// <summary>
        /// Update a Task
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="startDate"></param>
        new public void update(string name, string description, string startDate)
        {
            base.update(name, description, startDate);

            DBDriver myDB = new DBDriver();
            myDB.Query="update tasks \n" 
                +"set name=@name, description=@desc, startDate=@start\n"
                +"where id=@id;";

            myDB.addParam("@id", this.id);
            myDB.addParam("@name", name);
            myDB.addParam("@desc", description);
            myDB.addParam("@start", startDate);
            
            myDB.nonQuery();
        }

        /// <summary>
        /// Remove a Task
        /// </summary>
        /// <param name="id">project id</param>
        public static void remove(string id)
        {
            DBDriver myDB = new DBDriver();
            myDB.Query = "delete from Tasks where id=@id";
            myDB.addParam("@id", id);
            myDB.nonQuery();
        }

        /// <summary>
        /// Get a Task DataSet by its id
        /// </summary>
        /// <param name="id">Module id</param>
        /// <returns>Filled DataSet</returns>
        public static DataSet getByID(string id)
        {
            DBDriver myDB = new DBDriver();
            myDB.Query = "select * from tasks \n" + 
                "where ID = @ID;";
            myDB.addParam("@ID", id);

            DataSet ds = new DataSet();
            myDB.createAdapter().Fill(ds);
            
            return ds;
        }

        /// <summary>
        /// Gets a DataSet of Tasks in the specified Module
        /// </summary>
        /// <param name="id">Module id</param>
        /// <returns>Tasks DataSet</returns>
        public static DataSet getTasksDataSet(string id)
        {
            DBDriver myDB = new DBDriver();
            myDB.Query = "select * from tasks\n" +
                "where moduleID = @ID;";
            myDB.addParam("@ID", id);

            DataSet ds = new DataSet();
            myDB.createAdapter().Fill(ds);
            return ds;
        }

		/// <summary>
		/// Assign a Developer
		/// </summary>
		/// <param name="dev"></param>
		public void assignDeveloper(string devID)
		{
            this.devID = devID;

			DBDriver db = new DBDriver();
            db.Query = "insert into assignments (taskID, devID, dateAss)\n"
                        + "values (@taskID, @devID, @date)";
            db.addParam("@taskID", this.id);
            db.addParam("@devID", devID);
            db.addParam("@date", Convert.ToString(DateTime.Now));
			db.nonQuery();
			
			db.Query = "update tasks set complete = @complete\n"
					 + "where ID = @taskID;";
			db.addParam("@complete", PMT.TaskStatus.INPROGRESS);
			db.addParam("@taskID", this.id);
            db.nonQuery();

            db.Query = "select competence from compLevels where ID = @devID";
            db.addParam("@devID", devID);
            SqlDataReader dr = db.createReader();
            dr.Read();
            string competence = dr["competence"].ToString();
            db.close();
            string length;

            if( complexity == "Low" )
              db.Query = "select lowComplexity as length from compmatrix where compLevel = @competence";
            else if ( complexity == "Medium" )
              db.Query = "select medComplexity as length from compmatrix where compLevel = @competence";
            else if ( complexity == "High" )
              db.Query = "select highComplexity as length from compmatrix where compLevel = @competence";

            db.addParam("@competence", competence);
			dr = db.createReader();
            dr.Read();
            length = dr["length"].ToString();
			db.close();
   
            //TimeSpan temp = new TimeSpan(Convert.ToInt32(length), 0, 0, 0);
            DateTime start = Convert.ToDateTime(this.startDate);
			double hours = Convert.ToDouble(length);
			double days = Math.Ceiling(hours/8);
			DateTime end = start.AddDays(days);
            this.expEndDate = end.ToShortDateString();

            db.Query = "update tasks set expEndDate = @expEndDate\n"
                + "where ID = @taskID;";
            db.addParam("@expEndDate", this.expEndDate);
            db.addParam("@taskID", this.id);
            db.nonQuery();
//TODO
//			modid = ||select moduleid from tasks where id = @taskid;
//
//maximum = max of ||select tasks.expenddate from tasks where tasks.moduleid = @modid
//
//update modules set expenddate = @maximum where id = @modid
//
//projid = ||select projectid from modules where id = @modid
//
//maximum = max of ||select expenddate from modules where projectid = @projid
//
//update project set expenddate = @maximum where id = @projid


        
		}

        /// <summary>
        /// Get the Developer id assigned to this task
        /// </summary>
        public string DeveloperID
        {
            get {   return devID;   }
            set {   assignDeveloper(value); }
        }

        /// <summary>
        /// Get the Module id this task belongs to
        /// </summary>
        public string ModuleID
        {
            get {   return modID;   }
        }

        /// <summary>
        /// Gets or sets the tasks status
        /// </summary>
        public string Status
        {
            get {   return status;  }
            set 
            {   
                status = value;
                DBDriver db = new DBDriver();
                db.Query = 
                    "update tasks set complete=@complete\n"
                    + "where id=@id;";
                db.addParam("@complete", status);
                db.addParam("@id", this.id);
                db.nonQuery();
            }
        }

        /// <summary>
        /// Gets the percentage complete
        /// </summary>
        public string PercentComplete
        {
            get
            {
                double pct;
                if (status.Equals(TaskStatus.APPROVED))
                    pct = 1;
                else
                    pct = 0;

                return Convert.ToString(pct.ToString(percentFormatter));
            }
        }
	}
}
