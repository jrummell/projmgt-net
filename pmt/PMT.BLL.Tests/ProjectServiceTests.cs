using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PMT.BLL.Tests
{
    /// <summary>
    ///This is a test class for ProjectServiceTests and is intended
    ///to contain all ProjectServiceTests Unit Tests
    ///</summary>
    [TestClass]
    public class ProjectServiceTests : DataServiceTests
    {
        public ProjectServiceTests()
            : base(new ProjectService())
        {
        }

        [TestInitialize]
        public override void TestInitialize()
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
        public override void Update()
        {
            ProjectService target = new ProjectService();
            Project project = new Project("Name", "Description");
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
            const int projectID = 1;
            const int userID = 1;

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
            Project found = projects.Find(project => project.ID == projectID);

            return found != null;
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod]
        public override void Insert()
        {
            ProjectService target = new ProjectService();
            Project project = new Project("Name", "Description");
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
        public override void GetByID()
        {
            Project project = new Project("Name", "Description");
            InsertAndGetById(project);
        }

        /// <summary>
        /// A test for Exists
        /// </summary>
        [TestMethod]
        public override void Exists()
        {
            Project project = new Project("Name", "Description");

            InsertAndGetById(project);

            ProjectService service = new ProjectService();
            Assert.IsTrue(service.Exists(project.ID));
        }

        protected override IRecord CreateRecord()
        {
            return new Project("Name", "Description");
        }

        private static void InsertAndGetById(Project project)
        {
            ProjectService target = new ProjectService();
            target.Insert(project);

            Project actual = target.GetByID(project.ID);
            Assert.IsNotNull(actual);
            Assert.AreEqual(project.ID, actual.ID);
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod]
        public override void Delete()
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
            const int projectID = 1;
            const int userID = 1;

            // unassign project if it's already assigned
            List<Project> projects = new List<Project>(target.GetByUser(userID));
            if (Contains(projects, projectID))
            {
                target.Unassign(projectID, userID);
            }

            target.Assign(projectID, userID);

            Assert.IsTrue(target.GetByUser(userID).Count > 0);
        }
    }
}