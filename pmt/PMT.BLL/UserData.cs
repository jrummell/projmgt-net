using System;
using System.Collections.Generic;
using System.Text;
using PMT.DAL;
using PMT.DAL.UsersDataSetTableAdapters;
using PMT.DAL.AssignmentsDataSetTableAdapters;
using System.Data;

namespace PMT.BLL
{
    /// <summary>
    /// Manages User data
    /// </summary>
    public class UserData : IDisposable
    {
        private UsersTableAdapter taUsers;
        private UserProfileTableAdapter taUserProfile;
        private ManagerAssignmentsTableAdapter taUserManagers;
        private ProjectAssignmentsTableAdapter taUserProjects;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserData"/> class.
        /// </summary>
        public UserData()
        {
            taUsers = new UsersTableAdapter();
            taUserProfile = new UserProfileTableAdapter();
            taUserManagers = new ManagerAssignmentsTableAdapter();
            taUserProjects = new ProjectAssignmentsTableAdapter();
        }
    
        /// <summary>
        /// Get a User by id
        /// </summary>
        /// <param name="id">user id</param>
        public User GetUser(int id)
        {
            return GetUser(id, null);
        }

        /// <summary>
        /// Get a User by username
        /// </summary>
        /// <param name="userName">username</param>
        public User GetUser(string userName)
        {
            if (userName == null)
            {
                throw new ArgumentNullException("userName");
            }
			
            return GetUser(0, userName);
        }

        /// <summary>
        /// Inserts a new User
        /// </summary>
        /// <returns>the inserted user's id</returns>
        public int InsertUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (UsernameExists(user.UserName))
            {
                throw new Exception(String.Format("User {0} already exists.", user.UserName));
            }

            // add to users and get new id
            int rows = (int)taUsers.Insert(user.UserName, 
                (short)user.Role, user.Password, user.Enabled);

            if (rows != 1)
            {
                throw new Exception(String.Format("Could not insert user {0}.", user.UserName));
            }

            // get new id
            UsersDataSet.UsersDataTable dt = taUsers.GetUserByUserName(user.UserName);
            if (dt.Count != 1)
            {
                throw new Exception(String.Format("Could not get new user {0}.", user.UserName));
            }
            int id = dt[0].ID;

            // add user profile
            rows = taUserProfile.Insert(id, user.FirstName, user.LastName, 
                user.State, user.ZipCode, user.PhoneNumber, user.Email, 
                user.Address, user.City);

            if (rows != 1)
            {
                DeleteUser(id);
                throw new Exception(String.Format(
                    "Could not insert profile. User {0} deleted.", user.UserName));
            }

            return id;
        }

        /// <summary>
        /// Deletes a User by their id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>true if successfull</returns>
        public bool DeleteUser(int id)
        {
            int rows = taUsers.Delete(id);

            if (rows == 1)
            {
                rows = taUserProfile.Delete(id);

                if (rows == 1)
                {
                    taUserManagers.DeleteByUserID(id);
                    taUserProjects.DeleteByUserID(id);
                }
            }

            return rows == 1;
        }

        /// <summary>
        /// Updates a user by their id
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>true if sucessfull</returns>
        public bool UpdateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
			
            int rows = taUsers.Update(user.UserName, (short)user.Role, user.Password, user.Enabled, user.ID, user.ID);

            if (rows == 1)
            {
                rows = taUserProfile.Update(user.ID, user.FirstName, user.LastName, user.Address,
                    user.City, user.State, user.ZipCode, user.PhoneNumber, user.Email, user.ID);
            }

            return rows == 1;
        }

        /// <summary>
        /// Updates the enabled.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        /// <returns></returns>
        public bool UpdateEnabled(int id, bool enabled)
        {
            int rows = taUsers.UpdateEnabled(enabled, id);

            return rows == 1;
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        private User GetUser(int id, string userName)
        {
            User user = null;

            UsersDataSet.UserProfileDataTable dtProfile;
            UsersDataSet.UsersDataTable dtUser;

            if (userName == null)
            {
                dtProfile = taUserProfile.GetUserProfileByID(id);
                dtUser = taUsers.GetUserByID(id);
            }
            else
            {
                dtProfile = taUserProfile.GetUserProfileByUsername(userName);
                dtUser = taUsers.GetUserByUserName(userName);
            }

            if (dtUser.Count == 0 || dtProfile.Count == 0)
                return null;

            UsersDataSet.UsersRow rUser = dtUser[0];
            user = User.CreateUser((UserRole)rUser.Role);
            user.ID = rUser.ID;
            user.UserName = rUser.Username;
            user.Enabled = rUser.Enabled;

            UsersDataSet.UserProfileRow rProfile = dtProfile[0];
            user.FirstName = rProfile.FirstName;
            user.LastName = rProfile.LastName;
            user.Email = rProfile.Email;
            user.Address = rProfile.Address;
            user.City = rProfile.City;
            user.State = rProfile.State;
            user.ZipCode = rProfile.Zip;
            user.PhoneNumber = rProfile.PhoneNumber;

            return user;
        }

        /// <summary>
        /// Gets the user profiles.
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserProfiles()
        {
            UsersDataSet.UsersDataTable dtUsers = taUsers.GetUsers();
            UsersDataSet.UserProfileDataTable dtProfiles = taUserProfile.GetUserProfiles();

            DataTable dt = new DataTable();
            dt.Merge(dtUsers);
            dt.Merge(dtProfiles);

            return dt;
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <param name="enabled">if set to <c>true</c> gets enabled users.</param>
        /// <returns></returns>
        public UsersDataSet.UsersDataTable GetUsers(bool enabled)
        {
            return taUsers.GetUsersByEnabled(enabled);
        }

        /// <summary>
        /// Authenticates the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public bool AuthenticateUser(string username, string password)
        {
            if (username == null)
            {
                throw new ArgumentNullException("username");
            }

            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
			
			
            return 1 == (int)taUsers.AuthenticateUser(username, password);
        }

        /// <summary>
        /// Users the name exists.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public bool UsernameExists(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("username");
            }
			
            return taUsers.GetUserByUserName(username).Rows.Count != 0;
        }

        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                lock (this)
                {
                    if (taUsers != null)
                        taUsers.Dispose();
                    if (taUserProjects != null)
                        taUserProjects.Dispose();
                    if (taUserProfile != null)
                        taUserProfile.Dispose();
                    if (taUserManagers != null)
                        taUserManagers.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        #endregion
    }
}
