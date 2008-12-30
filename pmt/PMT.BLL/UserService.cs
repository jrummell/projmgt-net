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
    public class UserService : DataService<User>
    {
        private readonly UserProfileController _profileController = new UserProfileController();
        private readonly UserController _userController = new UserController();

        public UserService()
            : base(typeof(UserController))
        {
        }

        /// <summary>
        /// Inserts a new User
        /// </summary>
        /// <returns>the inserted user's id</returns>
        public override void Insert(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (Exists(user.Username))
            {
                throw new Exception(String.Format("User {0} already exists.", user.Username));
            }

            // insert the user
            DAL.User newUser = new DAL.User
                                   {
                                       Enabled = user.Enabled,
                                       Password = user.Password,
                                       Role = ((short) user.Role),
                                       Username = user.Username
                                   };
            newUser.Save();

            // add user profile
            _profileController.Insert(newUser.Id, user.FirstName, user.LastName,
                                      user.Address, user.City, user.State, user.ZipCode, user.PhoneNumber, user.Email);

            // update the passed in user object
            user.ID = newUser.Id;
        }

        /// <summary>
        /// Deletes a User by their id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>true if successfull</returns>
        public override void Delete(int id)
        {
            _userController.Delete(id);
            _profileController.Delete(id);

            ActiveRecord<ManagerAssignment>.Delete(ManagerAssignment.Columns.UserID, id);
            ActiveRecord<ProjectAssignment>.Delete(ProjectAssignment.Columns.UserID, id);
        }

        /// <summary>
        /// Updates a user by their id
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>true if sucessfull</returns>
        public override void Update(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            _userController.Update(user.ID, user.Username, (short) user.Role, user.Enabled, user.Password);
            _profileController.Update(user.ID, user.FirstName, user.LastName, user.Address, user.City, user.State,
                                      user.ZipCode, user.PhoneNumber, user.Email);
        }

        /// <summary>
        /// Get a User by username
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public User GetByID(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("username");
            }

            Query query = DAL.User.CreateQuery()
                .AddWhere(DAL.User.Columns.Username, Comparison.Equals, username);

            return CreateRecord(query);
        }

        /// <summary>
        /// Updates the enabled.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        /// <returns></returns>
        public void Enable(int id, bool enabled)
        {
            DAL.User user = new DAL.User(id) {Enabled = enabled};
            user.Save();
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <param name="enabled">if set to <c>true</c> gets enabled users.</param>
        /// <returns></returns>
        public Collection<User> GetByEnabled(bool enabled)
        {
            Query query = DAL.User.CreateQuery().AddWhere(DAL.User.Columns.Enabled, Comparison.Equals, enabled);
            return CreateCollection(query);
        }

        public Collection<User> GetByRole(UserRole role)
        {
            Query query = DAL.User.CreateQuery().AddWhere(DAL.User.Columns.Role, Comparison.Equals, (short) role);
            return CreateCollection(query);
        }

        public Collection<User> GetByProject(int projectID)
        {
            UserCollection dalUsers = DAL.Project.GetUserCollection(projectID);
            return CreateCollection(dalUsers);
        }

        /// <summary>
        /// Authenticates the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The unhashed password.</param>
        /// <returns></returns>
        public bool Authenticate(string username, string password)
        {
            if (username == null)
            {
                throw new ArgumentNullException("username");
            }

            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            User user = new User(UserRole.Client, username, password);

            Query query = DAL.User.CreateQuery();
            query.AddWhere(DAL.User.Columns.Username, Comparison.Equals, user.Username);
            query.AddWhere(DAL.User.Columns.Password, Comparison.Equals, user.Password);

            UserCollection collection = _userController.FetchByQuery(query);

            return collection.Count == 1;
        }

        /// <summary>
        /// Users the name exists.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public bool Exists(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("username");
            }

            Query query = DAL.User.CreateQuery().AddWhere(
                DAL.User.Columns.Username, Comparison.Equals, username);
            return _userController.FetchByQuery(query).Count == 1;
        }

        public Collection<User> GetByManager(int managerID)
        {
            ManagerAssignmentCollection assignmentCollection =
                new ManagerAssignmentCollection().Where(ManagerAssignment.Columns.ManagerID,
                                                        Comparison.Equals, managerID);
#warning //TODO: optimize
            Collection<User> userCollection = new Collection<User>();
            foreach (ManagerAssignment assignment in assignmentCollection)
            {
                userCollection.Add(CreateRecord(assignment.User));
            }

            return userCollection;
        }

        public UserStatistics GetStatistics()
        {
            Dictionary<UserRole, int> dictionary = new Dictionary<UserRole, int>();

            foreach (UserRole role in Enum.GetValues(typeof (UserRole)))
            {
                dictionary.Add(role, GetCount(role));
            }

            Where where = new Where
                              {
                                  ColumnName = DAL.User.Columns.Enabled,
                                  Comparison = Comparison.Equals,
                                  ParameterValue = false
                              };

            int totalUsers = DAL.User.CreateQuery().GetCount(DAL.User.Columns.Id);
            int newUsers = GetCount(where);

            return new UserStatistics(dictionary, totalUsers, newUsers);
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns></returns>
        private static int GetCount(Where where)
        {
            return DAL.User.CreateQuery().AddWhere(where).GetCount(DAL.User.Columns.Id);
        }

        internal int GetManagerID(int userID)
        {
            Query query = ManagerAssignment.CreateQuery().AddWhere(ManagerAssignment.Columns.UserID, Comparison.Equals,
                                                                   userID);
            User user = CreateRecord(query);

            if (user != null)
            {
                return user.ID;
            }

            return -1;
        }

        public override void VerifyDefaults()
        {
            if (!Exists("admin"))
            {
                User admin = new User(UserRole.Administrator, "admin", "asdf") {Enabled = true};
                Insert(admin);
            }
        }

        protected override User CreateRecord(IActiveRecord activeRecord)
        {
#warning //TODO: optimize
            DAL.User dalUser = ((DAL.User) activeRecord);
            UserProfile profile = new UserProfile(dalUser.Id);

            User user = new User(dalUser.Id, (UserRole) dalUser.Role, dalUser.Username, dalUser.Password)
                            {
                                Address = profile.Address,
                                City = profile.City,
                                Email = profile.Email,
                                Enabled = dalUser.Enabled,
                                FirstName = profile.FirstName,
                                LastName = profile.LastName,
                                PhoneNumber = profile.PhoneNumber,
                                State = profile.State,
                                ZipCode = profile.Zip
                            };

            user.ManagerID = GetManagerID(user.ID);

            return user;
        }
    }
}