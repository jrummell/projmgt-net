using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PMT.DAL;
using SubSonic;

namespace PMT.BLL
{
    /// <summary>
    /// Manages User data
    /// </summary>
    public class UserData
    {
        private readonly UserProfileController taUserProfile;
        private readonly UserController taUsers;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserData"/> class.
        /// </summary>
        public UserData()
        {
            taUsers = new UserController();
            taUserProfile = new UserProfileController();
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
        public void InsertUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (UsernameExists(user.UserName))
            {
                throw new Exception(String.Format("User {0} already exists.", user.UserName));
            }

            // insert the user
            DAL.User newUser = new DAL.User();
            newUser.Enabled = false;
            newUser.Password = user.Password;
            newUser.Role = (short) user.Role;
            newUser.Username = user.UserName;
            newUser.Save();

            // add user profile
            taUserProfile.Insert(user.ID, user.FirstName, user.LastName,
                                 user.State, user.ZipCode, user.PhoneNumber, user.Email,
                                 user.Address, user.City);

            // update the passed in user object
            user.Update(newUser, new UserProfile(user.ID));
        }

        /// <summary>
        /// Deletes a User by their id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>true if successfull</returns>
        public void DeleteUser(int id)
        {
            taUsers.Delete(id);
            taUserProfile.Delete(id);

            ActiveRecord<ManagerAssignment>.Delete(ManagerAssignment.Columns.UserID, id);
            ActiveRecord<ProjectAssignment>.Delete(ProjectAssignment.Columns.UserID, id);
        }

        /// <summary>
        /// Updates a user by their id
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>true if sucessfull</returns>
        public void UpdateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            taUsers.Update(user.ID, user.UserName, (short) user.Role, user.Enabled, user.Password);
        }

        /// <summary>
        /// Updates the enabled.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        /// <returns></returns>
        public void UpdateEnabled(int id, bool enabled)
        {
            DAL.User user = ReadOnlyRecord<DAL.User>.FetchByID(id);
            user.Enabled = enabled;
            user.Save();
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        private User GetUser(int id, string userName)
        {
            Query query = DAL.User.CreateQuery();

            if (userName == null)
            {
                query.AddWhere(DAL.User.Columns.Username, Comparison.Equals, userName);
            }
            else
            {
                query.AddWhere(DAL.User.Columns.Id, Comparison.Equals, id);
            }

            UserCollection collection = taUsers.FetchByQuery(query);

            if (collection.Count != 1)
            {
                return null;
            }

            DAL.User dalUser = collection[0];
            var profile = new UserProfile(dalUser.Id);

            User user = new User(dalUser, profile);

            return user;
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <param name="enabled">if set to <c>true</c> gets enabled users.</param>
        /// <returns></returns>
        public ICollection<User> GetUsers(bool enabled)
        {
            Query query = DAL.User.CreateQuery().AddWhere(DAL.User.Columns.Enabled, Comparison.Equals, enabled);
            UserCollection collection = taUsers.FetchByQuery(query);

#warning //TODO: optimize
            return CreateUserCollection(collection);
        }

        private static ICollection<User> CreateUserCollection(IEnumerable<DAL.User> collection)
        {
            Collection<User> users = new Collection<User>();
            foreach (DAL.User user in collection)
            {
                users.Add(new User(user, new UserProfile(user.Id)));
            }

            return users;
        }

        public ICollection<User> GetUsers()
        {
            return CreateUserCollection(taUsers.FetchAll());
        }

        public ICollection<User> GetUsersByRole(UserRole role)
        {
            Query query = DAL.User.CreateQuery().AddWhere(DAL.User.Columns.Role, Comparison.Equals, (short) role);
            return CreateUserCollection(taUsers.FetchByQuery(query));
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

            password = Encryption.Encrypt(password);

            Query query = DAL.User.CreateQuery();
            query.AddWhere(DAL.User.Columns.Username, Comparison.Equals, username);
            query.AddWhere(DAL.User.Columns.Password, Comparison.Equals, password);

            UserCollection collection = taUsers.FetchByQuery(query);

            return collection.Count == 1;
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

            Query query = DAL.User.CreateQuery().AddWhere(
                DAL.User.Columns.Username, Comparison.Equals, username);
            return taUsers.FetchByQuery(query).Count == 1;
        }

        public ICollection<User> GetDevelopersByManager(int managerID)
        {
            ManagerAssignmentCollection assignmentCollection =
                new ManagerAssignmentCollection().Where(ManagerAssignment.Columns.ManagerID,
                                                        Comparison.Equals, managerID);
#warning //TODO: optimize
            Collection<User> userCollection = new Collection<User>();
            foreach (ManagerAssignment assignment in assignmentCollection)
            {
                userCollection.Add(new User(assignment.UserID));
            }

            return userCollection;
        }

        public UserStatistics GetStatistics()
        {
            int admins = GetCount(UserRole.Administrator);
            int managers = GetCount(UserRole.Manager);
            int developers = GetCount(UserRole.Developer);
            int clients = GetCount(UserRole.Client);

            Where where = new Where
                              {
                                  ColumnName = DAL.User.Columns.Enabled,
                                  Comparison = Comparison.Equals,
                                  ParameterValue = false
                              };

            int newUsers = GetCount(where);

            return new UserStatistics(admins, managers, developers, clients, newUsers);
        }

        private static int GetCount(UserRole role)
        {
            Where where = new Where
                              {
                                  ColumnName = DAL.User.Columns.Role,
                                  Comparison = Comparison.Equals,
                                  ParameterValue = ((short) role)
                              };

            return GetCount(where);
        }

        private static int GetCount(Where where)
        {
            return DAL.User.CreateQuery().AddWhere(where).GetCount(DAL.User.Columns.Id);
        }

        public int GetManagerID(int userID)
        {
            ManagerAssignmentCollection assignments =
                new ManagerAssignmentController().FetchByQuery(
                    ManagerAssignment.CreateQuery().AddWhere(ManagerAssignment.Columns.UserID, Comparison.Equals, userID));
            if (assignments.Count != 1)
            {
                return -1;
            }

            return assignments[0].ManagerID;
        }
    }
}