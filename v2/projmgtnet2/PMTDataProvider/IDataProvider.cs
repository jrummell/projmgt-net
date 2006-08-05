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
	}
}
