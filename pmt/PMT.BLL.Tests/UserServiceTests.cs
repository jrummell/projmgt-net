using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PMT.BLL.Tests
{
    /// <summary>
    ///This is a test class for UserService and is intended
    ///to contain all UserService Unit Tests
    ///</summary>
    [TestClass]
    public class UserServiceTests
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [ClassInitialize]
        public static void VerifyUsers(TestContext testContext)
        {
            // make sure we have one admin and one manager
            UserService data = new UserService();
            data.VerifyDefaults();
        }

        /// <summary>
        ///A test for UsernameExists
        ///</summary>
        [TestMethod]
        public void UsernameExists()
        {
            UserService target = new UserService();
            Assert.IsTrue(target.UsernameExists("admin"));
        }

        /// <summary>
        ///A test for UpdateUser
        ///</summary>
        [TestMethod]
        public void UpdateUser()
        {
            UserService target = new UserService();
            User user = target.GetByUsername("admin");
            string lastName = user.LastName;

            user.LastName = "updated last name";
            target.Update(user);

            User updated = target.GetByID(user.ID);
            Assert.AreEqual(user.LastName, updated.LastName);

            // revert back to original last name
            updated.LastName = lastName;
            target.Update(updated);
        }

        /// <summary>
        ///A test for UpdateEnabled
        ///</summary>
        [TestMethod]
        public void UpdateEnabled()
        {
            UserService target = new UserService();
            User user = target.GetByUsername("admin");

            bool enabled = user.Enabled;
            
            user.Enabled = !user.Enabled;
            target.Enable(user.ID, user.Enabled);

            User updated = target.GetByID(user.ID);

            Assert.AreEqual(user.Enabled, updated.Enabled);

            // revert
            target.Enable(user.ID, enabled);
        }

        /// <summary>
        ///A test for InsertUser
        ///</summary>
        [TestMethod]
        public void InsertUser()
        {
            UserService target = new UserService();

            User user = new User(UserRole.Client) {UserName = "testUser"};
            target.Insert(user);

            Assert.IsNotNull(target.GetByID(user.ID));
            Assert.IsNotNull(target.GetByUsername(user.UserName));

            target.Delete(user.ID);
        }

        /// <summary>
        ///A test for GetUsersByRole
        ///</summary>
        [TestMethod]
        public void GetUsersByRole()
        {
            UserService target = new UserService();

            ICollection<User> users = target.GetByRole(UserRole.Administrator);

            Assert.IsTrue(users.Count > 0);
            foreach (User user in users)
            {
                Assert.AreEqual(UserRole.Administrator, user.Role);
            }
        }

        /// <summary>
        ///A test for GetUsers
        ///</summary>
        [TestMethod]
        public void GetUsers()
        {
            UserService target = new UserService();

            Assert.IsTrue(target.GetAll().Count > 0);
        }

        /// <summary>
        ///A test for GetUsers
        ///</summary>
        [TestMethod]
        public void GetUsersByEnabled()
        {
            UserService target = new UserService();

            ICollection<User> enabled = target.GetByEnabled(true);
            foreach (User user in enabled)
            {
                Assert.AreEqual(true, user.Enabled);
            }

            ICollection<User> disabled = target.GetByEnabled(false);
            foreach (User user in disabled)
            {
                Assert.AreEqual(false, user.Enabled);
            }
        }

        /// <summary>
        ///A test for GetUser
        ///</summary>
        [TestMethod]
        public void GetUserById()
        {
            UserService target = new UserService();
            int id = target.GetByUsername("admin").ID;
            User admin = target.GetByID(id);

            Assert.IsNotNull(admin);
            Assert.AreEqual(id, admin.ID);
        }

        /// <summary>
        ///A test for GetUser
        ///</summary>
        [TestMethod]
        public void GetUserByUsername()
        {
            UserService target = new UserService();
            User user = target.GetByUsername("admin");

            Assert.IsNotNull(user);
            Assert.AreEqual("admin", user.UserName);
        }

        /// <summary>
        ///A test for GetStatistics
        ///</summary>
        [TestMethod]
        public void GetStatistics()
        {
            UserService target = new UserService();

            Assert.IsNotNull(target.GetStatistics());
        }

        /// <summary>
        ///A test for GetDevelopersByManager
        ///</summary>
        [TestMethod]
        public void GetDevelopersByManager()
        {
            UserService target = new UserService();
            User manager = target.GetByUsername("manager");

            ICollection<User> developers = target.GetByManager(manager.ID);
            foreach (User developer in developers)
            {
                Assert.AreEqual(manager.ID, developer.ManagerID);
            }
        }

        /// <summary>
        ///A test for DeleteUser
        ///</summary>
        [TestMethod]
        public void DeleteUser()
        {
            UserService target = new UserService();

            User user = new User(UserRole.Client) {UserName = "testUser"};
            target.Insert(user);

            target.Delete(user.ID);

            Assert.IsNull(target.GetByID(user.ID));
        }

        /// <summary>
        ///A test for AuthenticateUser
        ///</summary>
        [TestMethod]
        public void AuthenticateUser()
        {
            UserService target = new UserService();
            Assert.IsTrue(target.Authenticate("admin", "asdf"));
        }

        #region Additional test attributes

        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //

        #endregion
    }
}