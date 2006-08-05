using System;
using System.Data;
using System.Text;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using PMTComponents;

namespace PMTDataProvider
{
	/// <summary>
	/// MySql implementation of the PMT IDataProvider
	/// </summary>
    public class MySqlDataProvider : IDataProvider
    {
        public MySqlDataProvider() {}

        #region IDataProvider Members

        #region PMTUser
        public bool AuthenticateUser(string username, string password, TransactionFailedHandler handler)
        {
            using (MySqlConnection conn = new MySqlConnection(Configuration.ConnectionString))
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "select count(*) from users where UserName=?user";
                command.Parameters.Add("?user", username);

                int k = Convert.ToInt32(this.ExecuteScalar(command));

                if (k == 0)
                {
                    //user does not exist in DB
                    handler(new Exception("You have entered an unknown username."));
                    return false;
                }
                else
                {
                    command = conn.CreateCommand();
                    command.CommandText = "select count(*) from users u where u.UserName=?user and u.Password=?pass";
                    command.Parameters.Add("?user", username);
                    command.Parameters.Add("?pass", password);

                    k = Convert.ToInt32(this.ExecuteScalar(command));
                    if (k == 0)
                    {
                        //password incorrect
                        handler(new Exception("You have entered an incorrect password."));
                        return false;
                    }
                    else
                    {
                        command = conn.CreateCommand();
                        command.CommandText = "select count(*) from users u where u.UserName=?user and u.Enabled=1";
                        command.Parameters.Add("?user", username);

                        k = Convert.ToInt32(this.ExecuteScalar(command));
                        if (k == 0)
                        {
                            //user not enabled
                            handler(new Exception("Your account has not been enabled.  Please contact your Administrator."));
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        #region PMTUser Management
        /// <summary>
        /// Enable a new user
        /// </summary>
        /// <param name="id">User id</param>
        public bool EnablePMTUser(int id, TransactionFailedHandler handler)
        {
            using (MySqlConnection conn = new MySqlConnection(Configuration.ConnectionString))
            {
                PMTUser user = this.GetPMTUserById(id, conn);

                if (user == null)
                {
                    handler(new NullReferenceException(String.Format("User with id {0} does not exist.", id)));
                    return false;
                }

                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "update users set enabled=1 where id=?id";
                command.Parameters.Add("?id", id);

                try
                {
                    int rows = this.ExecuteNonQuery(command);
                    if (rows == 0)
                        return false;
                }
                catch (MySqlException ex)
                {
                    handler(ex);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Disables a user
        /// </summary>
        /// <param name="id">User ID</param>
        public bool DisablePMTUser(int id, TransactionFailedHandler handler)
        {
            using (MySqlConnection conn = new MySqlConnection(Configuration.ConnectionString))
            {
                PMTUser user = this.GetPMTUserById(id, conn);

                if (user == null)
                {
                    handler(new NullReferenceException(String.Format("User with id {0} does not exist.", id)));
                    return false;
                }

                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "update users set enabled=0 where id=?id";
                command.Parameters.Add("?id", id);

                try
                {
                    int rows = this.ExecuteNonQuery(command);
                    if (rows == 0)
                        return false;
                }
                catch (MySqlException ex)
                {
                    handler(ex);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Delete a PMTUser
        /// </summary>
        /// <param name="id">User ID</param>
        public bool DeletePMTUser(int id, TransactionFailedHandler handler)
        {
            using (MySqlConnection conn = new MySqlConnection(Configuration.ConnectionString))
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "delete from users where id=?id";

                try
                {
                    this.ExecuteNonQuery(command);
                }
                catch (MySqlException ex)
                {
                    handler(ex);
                    return false;
                }
            }
            return true;
        }

        public bool InsertPMTUser(PMTUser user, TransactionFailedHandler handler)
        {
            using (MySqlConnection conn = new MySqlConnection(Configuration.ConnectionString))
            {
                // add the user
                StringBuilder sbCommand = new StringBuilder();
                sbCommand.Append("insert into users (Username, Password, Role, Enabled) \n");
                sbCommand.Append("values (?user, ?password, ?role, ?enabled)");

                MySqlCommand command = conn.CreateCommand();
                command.CommandText = sbCommand.ToString();
                command.Parameters.Add("?user", user.UserName);
                command.Parameters.Add("?password", user.Password);
                command.Parameters.Add("?role", (int)user.Role);
                command.Parameters.Add("?enabled", user.Enabled ? 1 : 0);

                try
                {
                    this.ExecuteNonQuery(command);
                }
                catch (MySqlException ex)
                {
                    handler(ex);
                    return false;
                }

                // get the user we just inserted so we can have its ID
                PMTUser temp = this.GetPMTUserByUsername(user.UserName);
                if (temp == null)
                {
                    handler(new NullReferenceException("User could not be added."));
                    return false;
                }

                user.ID = temp.ID;

                // add the user's info
                sbCommand = new StringBuilder();
                sbCommand.Append("insert into userInfo (ID, FirstName, LastName, Address, City, State, Zip, PhoneNumber, Email) \n");
                sbCommand.Append("values (?id, ?firstName, ?lastName, ?address, ?city, ?state, ?zip, ?phone, ?email)");

                command = conn.CreateCommand();
                command.CommandText = sbCommand.ToString();
                command.Parameters.Add("?id", user.ID);
                command.Parameters.Add("?firstName", user.FirstName);
                command.Parameters.Add("?lastName", user.LastName);
                command.Parameters.Add("?address", user.Address);
                command.Parameters.Add("?city", user.City);
                command.Parameters.Add("?state", user.State);
                command.Parameters.Add("?zip", user.ZipCode);
                command.Parameters.Add("?phone", user.PhoneNumber);
                command.Parameters.Add("?email", user.Email);

                try
                {
                    this.ExecuteNonQuery(command);
                }
                catch (MySqlException ex)
                {
                    handler(ex);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Update an existing user
        /// </summary>
        public bool UpdatePMTUser(PMTUser user, TransactionFailedHandler handler)
        {
            using (MySqlConnection conn = new MySqlConnection(Configuration.ConnectionString))
            {
                // update the user
                StringBuilder sbCommand = new StringBuilder();
                sbCommand.Append("update users  set Username=?user, Password=?password, Role=?role, Enabled=?enabled \n");
                sbCommand.Append("where ID=?id");

                MySqlCommand command = conn.CreateCommand();
                command.CommandText = sbCommand.ToString();
                command.Parameters.Add("?user", user.UserName);
                command.Parameters.Add("?password", user.Password);
                command.Parameters.Add("?role", (int)user.Role);
                command.Parameters.Add("?enabled", user.Enabled ? 1 : 0);
                command.Parameters.Add("?id", user.ID);

                try
                {
                    this.ExecuteNonQuery(command);
                }
                catch (MySqlException ex)
                {
                    handler(ex);
                    return false;
                }

                // update the user's info
                sbCommand = new StringBuilder();
                sbCommand.Append("update userInfo \n");
                sbCommand.Append("set FirstName=?firstName, LastName=?lastName, Address=?address, City=?city, State=?state, Zip=?zip, PhoneNumber=?phone, Email=?email \n");
                sbCommand.Append("where ID=?id");

                command = conn.CreateCommand();
                command.CommandText = sbCommand.ToString();
                command.Parameters.Add("?id", user.ID);
                command.Parameters.Add("?firstName", user.FirstName);
                command.Parameters.Add("?lastName", user.LastName);
                command.Parameters.Add("?address", user.Address);
                command.Parameters.Add("?city", user.City);
                command.Parameters.Add("?state", user.State);
                command.Parameters.Add("?zip", user.ZipCode);
                command.Parameters.Add("?phone", user.PhoneNumber);
                command.Parameters.Add("?email", user.Email);
                command.Parameters.Add("?id", user.ID);

                try
                {
                    this.ExecuteNonQuery(command);
                }
                catch (MySqlException ex)
                {
                    handler(ex);
                    return false;
                }
            }
            return true;
        }
        #endregion PMTUser Management

        #region Get Users
        /// <summary>
        /// Gets all users
        /// </summary>
        public DataTable GetPMTUsers()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(Configuration.ConnectionString))
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "select * from users u left join userInfo i on u.id=i.id";

                MySqlDataAdapter da = new MySqlDataAdapter(command);
                try
                {
                    da.Fill(dt);
                }
                finally
                {
                }
            }
            return dt;
        }

        /// <summary>
        /// Gets either enabled or disabled users
        /// </summary>
        /// <param name="enabled">Enabled or Disabled users?</param>
        public DataTable GetEnabledPMTUsers(bool enabled)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(Configuration.ConnectionString))
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "select * from users u left join userInfo i on u.id=i.id where u.Enabled=?enabled";
                command.Parameters.Add("?enabled", enabled ? 1 : 0);

                MySqlDataAdapter da = new MySqlDataAdapter(command);
                try
                {
                    da.Fill(dt);
                }
                finally
                {
                }
            }
            return dt;
        }
        #endregion Get Users

        #region Get PMTUser
        /// <summary>
        /// Gets a user by id
        /// </summary>
        /// <param name="id">User ID</param>
        public PMTUser GetPMTUserById(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(Configuration.ConnectionString))
            {
                return this.GetPMTUserById(id, conn);
            }
        }                

        /// <summary>
        /// Gets a user by id.  Internal method that reuses a connection
        /// </summary>
        /// <param name="id">User ID</param>
        private PMTUser GetPMTUserById(int id, MySqlConnection conn)
        {
            PMTUser user = null;
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "select * from users u left join userInfo i on u.id=i.id where u.id=?id";
            command.Parameters.Add("?id", id);

            if (conn.State != ConnectionState.Open)
                conn.Open();
            MySqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                user = new PMTUser(
                    Convert.ToInt32(dr["id"]),
                    dr["userName"].ToString(),
                    dr["password"].ToString(),
                    (PMTUserRole)Convert.ToInt32(dr["role"]),
                    dr["firstName"].ToString(),
                    dr["lastName"].ToString(),
                    dr["email"].ToString(),
                    dr["phoneNumber"].ToString(),
                    dr["address"].ToString(),
                    dr["city"].ToString(),
                    dr["state"].ToString(),
                    dr["zip"].ToString(),
                    Convert.ToInt32(dr["enabled"]) == 1);
            }
            dr.Close();
            return user;
        }

        /// <summary>
        /// Returns a PMTUser by username
        /// </summary>
        public PMTUser GetPMTUserByUsername(string username)
        {
            using (MySqlConnection conn = new MySqlConnection(Configuration.ConnectionString))
            {
                MySqlCommand command = conn.CreateCommand();

                command.CommandText = "select ID from users where UserName=?user";
                command.Parameters.Add("?user", username);

                int id = Convert.ToInt32(this.ExecuteScalar(command));
                return this.GetPMTUserById(id, conn);
            }
        }
        #endregion Get PMTUser

        /// <summary>
        /// Is the email address in the userInfo table?
        /// </summary>
        /// <param name="email">Email Address</param>
        public bool VerifyEmailExists(string email)
        {
            using (MySqlConnection conn = new MySqlConnection(Configuration.ConnectionString))
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "select count(*) from userInfo where email=?email";
                command.Parameters.Add("?email", email);

                int k = Convert.ToInt32(this.ExecuteScalar(command));

                if (k > 0)
                    return true;
                else
                    return false;
            }
        }

        /*
         * This isn't needed, we can do a GetPMTUserByUsername(),
         *  and if the return is null, it does not exist
         * 
        /// <summary>
        /// Verify that a username exists in the database
        /// </summary>
        /// <param name="userName">the username to verify</param>
        /// <returns>true if it exists, false if it doesn't</returns>
        static public bool verifyUserNameExists(string userName, bool isNew)
        {
            DBDriver myDB=new DBDriver();
            myDB.Query="select count(*) from users where userName=@name;";
            myDB.addParam("@name", userName);
            int k=Convert.ToInt32(myDB.scalar());
            if(k!=1)
                if(isNew)
                {
                    myDB.Query="select count(*) from newUsers where userName=@name;";
                    myDB.addParam("@name", userName);
                    k=Convert.ToInt32(myDB.scalar());                                                                  
                }
            if(k==1)
                return true;

            return false;
        }
        */
        #endregion PMTUser

        #region Managed Query Execution
        /// <summary>
        /// Execute a query that returns the number of rows affected, and not data
        /// </summary>
        private int ExecuteNonQuery(MySqlCommand command)
        {
            int rows = 0;

            if (command.Connection.State != ConnectionState.Open)
                command.Connection.Open();

            rows = command.ExecuteNonQuery();

            return rows;
        }

        /// <summary>
        /// Execute a command that returns an object
        /// </summary>
        private object ExecuteScalar(MySqlCommand command)
        {
            object obj = null;

            if (command.Connection.State != ConnectionState.Open)
                command.Connection.Open();

            obj = command.ExecuteScalar();
            
            return obj;
        }
        #endregion

        #endregion
    }
}
