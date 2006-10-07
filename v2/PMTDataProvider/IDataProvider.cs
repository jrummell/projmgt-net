using System;
using System.Reflection;
using System.Data;
using PMTComponents;
using PMTDataProvider.Configuration;

namespace PMTDataProvider
{
    /// <summary>
    /// Delegate for handling exceptions when editing the Database within IDataProvider
    /// </summary>
    public delegate void TransactionFailedHandler(Exception ex);

    /// <summary>
    /// Creates an instance of a class that inherits IDataProvider
    /// </summary>
    public class DataProviderFactory
    {
        /// <summary>
        /// Hiding the constructor ...
        /// </summary>
        private DataProviderFactory(){}

        /// <summary>
        /// Creates an instance of the Data Provider specified in web.config
        /// </summary>
        public static IDataProvider CreateInstance()
        {
            Type t = Type.GetType(Config.DataProvider);
            ConstructorInfo constructor = t.GetConstructor(Type.EmptyTypes);
            return (IDataProvider)constructor.Invoke(new Object[0]);
        }
    }

	/// <summary>
	/// Interface for PMTDataProvider
	/// </summary>
	/// <remarks>
	/// Any method that alters the database has a TransactionFailedHandler parameter.
	/// This is a delegate that allows the calling class to handle any thrown exceptions.
	/// Also, any method that alters the database returns true if successfull and false if not.
	/// </remarks>
	public interface IDataProvider
	{
        #region User
        /// <summary>
        /// Authenticates a username and password against stored users
        /// </summary>
        /// <returns>True if successfull, false if not</returns>
        bool AuthenticateUser(string username, string password, TransactionFailedHandler handler);

        /// <summary>
        /// Gets all users
        /// </summary>
        DataTable GetPMTUsers();
        /// <summary>
        /// Gets either enabled or disabled users
        /// </summary>
        /// <param name="enabled">Enabled or Disabled users?</param>
        DataTable GetEnabledPMTUsers(bool enabled);

        /// <summary>
        /// Gets a user by id
        /// </summary>
        /// <param name="id">User ID</param>
        PMTUser GetPMTUser(int id);
        /// <summary>
        /// Gets a PMTUser by username
        /// </summary>
        PMTUser GetPMTUser(string username);

        /// <summary>
        /// Gets all developers
        /// </summary>
        DataTable GetDevelopers();
        /// <summary>
        /// Gets a developer by id
        /// </summary>
        Developer GetDeveloper(int id);
        /// <summary>
        /// Updates a developer
        /// </summary>
        bool UpdateDeveloper(Developer dev, TransactionFailedHandler handler);

        /// <summary>
        /// Inserts a new user
        /// </summary>
        bool InsertPMTUser(PMTUser user, TransactionFailedHandler handler);
        /// <summary>
        /// Updates an existing user
        /// </summary>
        bool UpdatePMTUser(PMTUser user, TransactionFailedHandler handler);
        /// <summary>
        /// Deletes a PMTUser
        /// </summary>
        /// <param name="id">User ID</param>
        bool DeletePMTUser(int id, TransactionFailedHandler handler);
        /// <summary>
        /// Enables a new user
        /// </summary>
        /// <param name="id">User id</param>
        bool EnablePMTUser(int id, TransactionFailedHandler handler);
        /// <summary>
        /// Disables a user
        /// </summary>
        /// <param name="id">User ID</param>
        bool DisablePMTUser(int id, TransactionFailedHandler handler);

        /// <summary>
        /// Is the email address in the userInfo table?
        /// </summary>
        /// <param name="email">Email Address</param>
        bool VerifyEmailExists(string email);

        /// <summary>
        /// Gets the Compentency vs. Complexity Matrix (C vs. C Matrix)
        /// </summary>
        DataTable GetCompMatrix();
        /// <summary>
        /// Update the Compentency vs. Complexity Matrix (C vs. C Matrix)
        /// </summary>
        bool UpdateCompMatrix(CompLevel level, double low, double med, double high, TransactionFailedHandler handler);
        #endregion

        #region Projects
        /// <summary>
        /// Gets all projects
        /// </summary>
        DataTable GetProjects();
        /// <summary>
        /// Gets a project by its id
        /// </summary>
        Project GetProject(int userID, int projectID);
        /// <summary>
        /// Gets a manager's projects
        /// </summary>
        /// <param name="mgrID">Manager id</param>
        DataTable GetManagerProjects(int mgrID);
        /// <summary>
        /// Gets a project's modules
        /// </summary>
        /// <param name="projID">project id</param>
        DataTable GetProjectModules(int projID);
        /// <summary>
        /// Inserts a new project
        /// </summary>
        /// <returns>new project's id</returns>
        int InsertProject(Project project, TransactionFailedHandler handler);
        /// <summary>
        /// Updates a project
        /// </summary>
        bool UpdateProject(Project project, TransactionFailedHandler handler);
        /// <summary>
        /// Deletes a project by its id
        /// </summary>
        /// <param name="projID">project id</param>
        bool DeleteProject(int projID, TransactionFailedHandler handler);

        /// <summary>
        /// Gets all projects that belong the logged in Client
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        DataTable GetClientProjects(int clientID);
        #endregion

        #region Modules
        /// <summary>
        /// Gets all modules
        /// </summary>
        DataTable GetModules();
        /// <summary>
        /// Gets a module by its id
        /// </summary>
        /// <param name="id">module id</param>
        PMTComponents.Module GetModule(int id);
        /// <summary>
        /// Gets tasks in a module
        /// </summary>
        /// <param name="modID">module id</param>
        DataTable GetModuleTasks(int modID);
        /// <summary>
        /// Inserts a new module
        /// </summary>
        /// <returns>new module's id</returns>
        int InsertModule(PMTComponents.Module module, TransactionFailedHandler handler);
        /// <summary>
        /// Updates an existing module
        /// </summary>
        bool UpdateModule(PMTComponents.Module module, TransactionFailedHandler handler);
        /// <summary>
        /// Delete's a module
        /// </summary>
        /// <param name="modID">module id</param>
        bool DeleteModule(int modID, TransactionFailedHandler handler);
        #endregion

        #region Tasks
        /// <summary>
        /// Gets all tasks
        /// </summary>
        DataTable GetTasks();
        /// <summary>
        /// Gets a task by its id
        /// </summary>
        Task GetTask(int id);
        /// <summary>
        /// Gets a developer's tasks
        /// </summary>
        DataTable GetDeveloperTasks(int devID);
        /// <summary>
        /// Inserts a new task
        /// </summary>
        /// <returns>new task's id</returns>
        int InsertTask(Task task, TransactionFailedHandler handler);
        /// <summary>
        /// Updates a task
        /// </summary>
        bool UpdateTask(Task task, TransactionFailedHandler handler);
        /// <summary>
        /// Deletes a task
        /// </summary>
        /// <param name="taskID">task id</param>
        bool DeleteTask(int taskID, TransactionFailedHandler handler);
        /// <summary>
        /// Gets developers that have no more than the given number of assigned tasks
        /// </summary>
        /// <param name="numTasks">number of assigned tasks</param>
        DataTable GetAvailableDevelopers(int numTasks);
        /// <summary>
        /// Assigns a developer to a task
        /// </summary>
        /// <param name="devID">developer id</param>
        /// <param name="taskID">task id</param>
        bool AssignDeveloper(int devID, int taskID, TransactionFailedHandler handler);
        /// <summary>
        /// Approves a completed task
        /// </summary>
        /// <param name="taskID">task id</param>
        /// <param name="status">task status</param>
        bool UpdateTaskStatus(int taskID, TaskStatus status, TransactionFailedHandler handler);

        /// <summary>
        /// Gets all assignments
        /// </summary>
        DataTable GetDeveloperAssignments();
        #endregion

        #region Project Item
        /// <summary>
        /// Returns the percent complete of an item. 
        /// (number of approved tasks / number of tasks)
        /// </summary>
        double ResolvePercentComplete(ProjectItem item);
        /// <summary>
        /// Returns the expected end date of the item based on the C vs. C Matrix
        /// </summary>
        DateTime ResolveExpectedEndDate(ProjectItem item);
        #endregion

        #region Messaging
        /// <summary>
        /// Gets a user's sent messages
        /// </summary>
        DataTable GetSentMessages(int userID);
        /// <summary>
        /// Get a user's received messages
        /// </summary>
        DataTable GetReceivedMessages(int userID);
        /// <summary>
        /// Gets a message by its id
        /// </summary>
        Message GetMessage(int id);
        /// <summary>
        /// Inserts (Sends) a message
        /// </summary>
        /// <param name="m">message</param>
        int InsertMessage(Message m, TransactionFailedHandler handler);
        /// <summary>
        /// Deletes a message
        /// </summary>
        /// <param name="messageID"></param>
        /// <param name="recipientID"></param>
        bool DeleteMessage(int messageID, int recipientID, TransactionFailedHandler handler);

        /// <summary>
        /// Gets all contacts ... this will need to change
        /// </summary>
        DataTable GetContacts();
        #endregion
	}
}
