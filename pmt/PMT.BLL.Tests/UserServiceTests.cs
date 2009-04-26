using System;
using System.Collections.ObjectModel;
using NUnit.Framework;

namespace PMT.BLL.Tests
{
    /// <summary>
    ///This is a test class for UserService and is intended
    ///to contain all UserService Unit Tests
    ///</summary>
    [TestFixture]
    public class UserServiceTests : DataServiceTests
    {
        private const string _password = "asdf";

        public UserServiceTests()
            : base(new UserService())
        {
        }

        /// <summary>
        ///A test for UpdateUser
        ///</summary>
        [Test]
        public override void Update()
        {
            UserService target = new UserService();
            User user = (User) CreateRecord();
            Insert(user);

            user.LastName = "updated last name";
            target.Update(user);

            User updated = target.GetByID(user.ID);
            Assert.AreEqual(user.LastName, updated.LastName);
        }

        /// <summary>
        ///A test for UpdateEnabled
        ///</summary>
        [Test]
        public void UpdateEnabled()
        {
            UserService target = new UserService();
            User user = (User) CreateRecord();
            Insert(user);

            user.Enabled = !user.Enabled;
            target.Enable(user.ID, user.Enabled);

            User updated = target.GetByID(user.ID);

            Assert.AreEqual(user.Enabled, updated.Enabled);
        }

        /// <summary>
        ///A test for InsertUser
        ///</summary>
        [Test]
        public override void Insert()
        {
            UserService target = new UserService();
            User user = (User) CreateRecord();
            Insert(user);

            Assert.IsNotNull(target.GetByID(user.ID));
            Assert.IsTrue(target.Exists(user.ID));
        }

        /// <summary>
        ///A test for GetUsersByRole
        ///</summary>
        [Test]
        public void GetByRole()
        {
            UserService target = new UserService();
            Collection<User> users = target.GetByRole(UserRole.Administrator);

            Assert.IsTrue(users.Count > 0);
            foreach (User user in users)
            {
                Assert.AreEqual(UserRole.Administrator, user.Role);
            }
        }

        /// <summary>
        ///A test for GetUsers
        ///</summary>
        [Test]
        public void GetByEnabled()
        {
            // disabled
            UserService target = new UserService();
            for (int i = 0; i < 5; i++)
            {
                User user = (User) CreateRecord();
                user.Enabled = false;
                Insert(user);
            }

            // enabled
            for (int i = 0; i < 4; i++)
            {
                User user = (User) CreateRecord();
                user.Enabled = true;
                Insert(user);
            }

            Collection<User> disabled = target.GetByEnabled(false);
            Assert.IsTrue(disabled.Count >= 5);
            foreach (User user in disabled)
            {
                Assert.AreEqual(false, user.Enabled);
            }

            Collection<User> enabled = target.GetByEnabled(true);
            Assert.IsTrue(enabled.Count >= 4);
            foreach (User user in enabled)
            {
                Assert.AreEqual(true, user.Enabled);
            }
        }

        /// <summary>
        ///A test for GetUser
        ///</summary>
        [Test]
        public void GetByUsername()
        {
            UserService target = new UserService();
            User user = (User) CreateRecord();
            Insert(user);

            User user2 = target.GetByID(user.Username);

            Assert.IsNotNull(user2);
            Assert.AreEqual(user.Username, user2.Username);
        }

        /// <summary>
        ///A test for GetStatistics
        ///</summary>
        [Test]
        public void GetStatistics()
        {
            UserService target = new UserService();

            Assert.IsNotNull(target.GetStatistics());
        }

        /// <summary>
        ///A test for GetDevelopersByManager
        ///</summary>
        [Test]
        public void GetUsersByManager()
        {
            UserService target = new UserService();
            User manager = new User(UserRole.Manager, Guid.NewGuid().ToString(), _password);
            Insert(manager);

            Collection<User> developers = target.GetByManager(manager.ID);
            foreach (User developer in developers)
            {
                Assert.AreEqual(manager.ID, developer.ManagerID);
            }
        }

        [Test]
        public void GetDevelopersByManager()
        {
            UserService target = new UserService();
            User manager = new User(UserRole.Manager, Guid.NewGuid().ToString(), _password);
            Insert(manager);

            for (int i = 0; i < 5; i++)
            {
                User developer = new User(UserRole.Developer, Guid.NewGuid().ToString(), _password)
                                     {ManagerID = manager.ID};

                Insert(developer);
            }

            Collection<User> developers = target.GetDevelopersByManager(manager.ID);

            Assert.AreEqual(5, developers.Count);

            foreach (User developer in developers)
            {
                Assert.AreEqual(UserRole.Developer, developer.Role);
                Assert.AreEqual(manager.ID, developer.ManagerID);
            }
        }

        /// <summary>
        ///A test for AuthenticateUser
        ///</summary>
        [Test]
        public void Authenticate()
        {
            UserService target = new UserService();
            User user = (User) CreateRecord();
            Insert(user);

            Assert.IsTrue(target.Authenticate(user.Username, _password));
        }

        protected override IRecord CreateRecord()
        {
            return new User(UserRole.Client, Guid.NewGuid().ToString(), _password);
        }
    }
}