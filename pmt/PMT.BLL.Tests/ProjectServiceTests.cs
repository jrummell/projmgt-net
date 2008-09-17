using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PMT.BLL.Tests
{
    /// <summary>
    ///This is a test class for ProjectServiceTests and is intended
    ///to contain all ProjectServiceTests Unit Tests
    ///</summary>
    [TestClass]
    public class ProjectServiceTests
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
        public static void VerifyDefaults(TestContext testContext)
        {
            UserService userService = new UserService();
            userService.VerifyDefaults();

            ProjectService projectService = new ProjectService();
            projectService.VerifyDefaults();
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod]
        public void Update()
        {
            ProjectService target = new ProjectService();
            Project project = new Project("Name", "Description", DateTime.Now);
            target.Insert(project);

            project.Description = "Updated";
            target.Update(project);

            Project updated = target.GetByID(project.ID);
            Assert.AreEqual(project.Description, updated.Description);

            // clean up
            target.Delete(project.ID);
        }

        /// <summary>
        ///A test for Unassign
        ///</summary>
        [TestMethod]
        public void Unassign()
        {
            ProjectService target = new ProjectService();
            int projectID = 1;
            int userID = 1;

            // make sure we have an assigned project
            List<Project> projects = new List<Project>(target.GetByUser(userID));
            if (projects.Count == 0 || !Contains(projects, projectID))
            {
                target.Assign(projectID, userID);
            }

            target.Unassign(projectID, userID);

            foreach (Project project in target.GetByUser(userID))
            {
                Assert.AreNotEqual(projectID, project.ID);
            }

            target.Assign(projectID, userID);
        }

        private static bool Contains(List<Project> projects, int projectID)
        {
            Project found = projects.Find(delegate(Project project) { return project.ID == projectID; });

            return found != null;
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod]
        public void Insert()
        {
            ProjectService target = new ProjectService();
            Project project = new Project("Name", "Description", DateTime.Now);
            target.Insert(project);

            Assert.IsTrue(target.Exists(project.ID));

            target.Delete(project.ID);
        }

        /// <summary>
        ///A test for GetByUser
        ///</summary>
        [TestMethod]
        public void GetByUser()
        {
            ProjectService target = new ProjectService();
            User manager = new UserService().GetByUsername("manager");
            ICollection<Project> actual = target.GetByUser(manager.ID);

            Assert.IsTrue(actual.Count > 0);
        }

        /// <summary>
        ///A test for GetByID
        ///</summary>
        [TestMethod]
        public void GetByID()
        {
            ProjectService target = new ProjectService();
            Project project = new Project("Name", "Description", DateTime.Now);
            target.Insert(project);

            Project actual = target.GetByID(project.ID);
            Assert.IsNotNull(actual);
            Assert.AreEqual(project.ID, actual.ID);
        }

        /// <summary>
        ///A test for GetAll
        ///</summary>
        [TestMethod]
        public void GetAll()
        {
            ProjectService target = new ProjectService();
            ICollection<Project> actual = target.GetAll();

            Assert.IsTrue(actual.Count > 0);
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod]
        public void Delete()
        {
            ProjectService target = new ProjectService();
            UserService userService = new UserService();
            User manager = userService.GetByUsername("manager");

            List<Project> projects = new List<Project>(target.GetByUser(manager.ID));
            Project project = projects[0];

            ICollection<User> users = userService.GetByProject(project.ID);
            
            target.Delete(project.ID);
            
            Assert.IsFalse(target.Exists(project.ID));

            // restore
            target.Insert(project);
            foreach (User user in users)
            {
                target.Assign(project.ID, user.ID);
            }
        }

        /// <summary>
        ///A test for Assign
        ///</summary>
        [TestMethod]
        public void Assign()
        {
            ProjectService target = new ProjectService();
            int projectID = 1;
            int userID = 1;

            // unassign project if it's already assigned
            List<Project> projects = new List<Project>(target.GetByUser(userID));
            if (Contains(projects, projectID))
            {
                target.Unassign(projectID, userID);
            }

            target.Assign(projectID, userID);

            Assert.IsTrue(target.GetByUser(userID).Count > 0);
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