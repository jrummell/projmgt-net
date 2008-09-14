using PMT.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PMT.BLL.Tests
{
    
    
    /// <summary>
    ///This is a test class for UserDataTest and is intended
    ///to contain all UserDataTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserDataTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
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


        /// <summary>
        ///A test for UsernameExists
        ///</summary>
        [TestMethod()]
        public void UsernameExists()
        {
            UserData target = new UserData();
            Assert.IsTrue(target.UsernameExists("admin"));
        }

        /// <summary>
        ///A test for UpdateUser
        ///</summary>
        [TestMethod()]
        public void UpdateUser()
        {
            UserData target = new UserData();
            User user = target.GetUser("admin");
            string lastName = user.LastName;

            user.LastName = "updated last name";
            target.UpdateUser(user);

            User updated = target.GetUser(user.ID);
            Assert.AreEqual(user.LastName, updated.LastName);

            // revert back to original last name
            updated.LastName = lastName;
            target.UpdateUser(updated);
        }

        /// <summary>
        ///A test for UpdateEnabled
        ///</summary>
        [TestMethod()]
        public void UpdateEnabled()
        {
            UserData target = new UserData();
            User user = target.GetUser("admin");

            target.UpdateEnabled(user.ID, false);

            User updated = target.GetUser(user.ID);

            Assert.AreEqual(user.Enabled, updated.Enabled);

            // revert
            target.UpdateEnabled(user.ID, true);
        }

        /// <summary>
        ///A test for InsertUser
        ///</summary>
        [TestMethod()]
        public void InsertUser()
        {
            UserData target = new UserData();

            User user = User.CreateUser(UserRole.Client);
            user.UserName = "testUser";
            target.InsertUser(user);

            Assert.IsNotNull(target.GetUser(user.ID));
            Assert.IsNotNull(target.GetUser(user.UserName));

            target.DeleteUser(user.ID);
        }

        /// <summary>
        ///A test for GetUsersByRole
        ///</summary>
        [TestMethod()]
        public void GetUsersByRole()
        {
            UserData target = new UserData(); 

            ICollection<User> users = target.GetUsersByRole(UserRole.Administrator);
            User admin = target.GetUser("admin");

            Assert.IsTrue(users.Contains(admin));
        }

        /// <summary>
        ///A test for GetUsers
        ///</summary>
        [TestMethod()]
        public void GetUsers()
        {
            UserData target = new UserData();

            Assert.IsTrue(target.GetUsers().Count > 0);
        }

        /// <summary>
        ///A test for GetUsers
        ///</summary>
        [TestMethod()]
        public void GetUsersByEnabled()
        {
            UserData target = new UserData();

            ICollection<User> enabled = target.GetUsers(true);
            foreach (User user in enabled)
            {
                Assert.AreEqual(true, user.Enabled);
            }

            ICollection<User> disabled = target.GetUsers(false);
            foreach (User user in disabled)
            {
                Assert.AreEqual(false, user.Enabled);
            }
        }

        /// <summary>
        ///A test for GetUser
        ///</summary>
        [TestMethod()]
        public void GetUserById()
        {
            UserData target = new UserData();
            int id = target.GetUser("admin").ID;
            User admin = target.GetUser(id);

            Assert.IsNotNull(admin);
            Assert.AreEqual(id, admin.ID);
        }

        /// <summary>
        ///A test for GetUser
        ///</summary>
        [TestMethod()]
        public void GetUserByUsername()
        {
            UserData target = new UserData();
            User user = target.GetUser("admin");

            Assert.IsNotNull(user);
            Assert.AreEqual("admin", user.UserName);
        }

        /// <summary>
        ///A test for GetStatistics
        ///</summary>
        [TestMethod()]
        public void GetStatistics()
        {
            UserData target = new UserData();
            
            Assert.IsNotNull(target.GetStatistics());
        }

        /// <summary>
        ///A test for GetDevelopersByManager
        ///</summary>
        [TestMethod()]
        public void GetDevelopersByManager()
        {
            UserData target = new UserData();
            User manager = target.GetUser("manager");

            ICollection<Developer> developers = target.GetDevelopersByManager(manager.ID);
            foreach (Developer developer in developers)
            {
                Assert.AreEqual(manager.ID, developer.ManagerID);
            }
        }

        /// <summary>
        ///A test for DeleteUser
        ///</summary>
        [TestMethod()]
        public void DeleteUser()
        {
            UserData target = new UserData(); // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            target.DeleteUser(id);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AuthenticateUser
        ///</summary>
        [TestMethod()]
        public void AuthenticateUser()
        {
            UserData target = new UserData(); // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            string password = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.AuthenticateUser(username, password);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UserData Constructor
        ///</summary>
        [TestMethod()]
        public void UserDataConstructor()
        {
            UserData target = new UserData();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
