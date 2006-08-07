using System;
using System.Reflection;
using System.Data;
using PMTComponents;

namespace PMTDataProvider
{
    /// <summary>
    /// Delegate for handling exceptions when editing the Database within IDataProvider
    /// </summary>
    public delegate void TransactionFailedHandler(Exception ex);

    public class DataProvider
    {
        // hide constructor
        private DataProvider(){}

        public static IDataProvider CreateInstance()
        {
            Type t = Type.GetType(Configuration.DataProvider);
            ConstructorInfo constructor = t.GetConstructor(Type.EmptyTypes);
            return (IDataProvider)constructor.Invoke(new Object[0]);
        }
    }

	/// <summary>
	/// Interface for PMTDataProvider
	/// </summary>
	public interface IDataProvider
	{
        bool AuthenticateUser(string username, string password, TransactionFailedHandler handler);

        DataTable GetPMTUsers();
        DataTable GetEnabledPMTUsers(bool enabled);

        PMTUser GetPMTUserById(int id);
        PMTUser GetPMTUserByUsername(string username);

        bool InsertPMTUser(PMTUser user, TransactionFailedHandler handler);
        bool UpdatePMTUser(PMTUser user, TransactionFailedHandler handler);
        bool DeletePMTUser(int id, TransactionFailedHandler handler);
        bool EnablePMTUser(int id, TransactionFailedHandler handler);
        bool DisablePMTUser(int id, TransactionFailedHandler handler);

        bool VerifyEmailExists(string email);

        DataTable GetCompMatrix();
        bool UpdateCompMatrix(CompLevel level, double low, double med, double high, TransactionFailedHandler handler);

        DataTable GetProjects();
        Project GetProject(int id);
        DataTable GetManagerProjects(int mgrID);
        DataTable GetProjectModules(int projID);
        int InsertProject(Project project, TransactionFailedHandler handler);
        bool UpdateProject(Project project, TransactionFailedHandler handler);
        bool DeleteProject(int projID, TransactionFailedHandler handler);

        DataTable GetModules();
        PMTComponents.Module GetModule(int id);
        DataTable GetModuleTasks(int modID);
        int InsertModule(PMTComponents.Module module, TransactionFailedHandler handler);
        bool UpdateModule(PMTComponents.Module module, TransactionFailedHandler handler);
        bool DeleteModule(int modID, TransactionFailedHandler handler);

        DataTable GetTasks();
        Task GetTask(int id);
        DataTable GetDeveloperTasks(int devID);
        int InsertTask(Task task, TransactionFailedHandler handler);
        bool UpdateTask(Task task, TransactionFailedHandler handler);
        bool DeleteTask(int taskID, TransactionFailedHandler handler);
        bool AssignDeveloper(int devID, int taskID, TransactionFailedHandler handler);

        DataTable GetDeveloperAssignments();
        bool ApproveTask(int taskID, TransactionFailedHandler handler);

        double ResolvePercentComplete(ProjectItem item);
        DateTime ResolveExpectedEndDate(ProjectItem item);
	}
}
