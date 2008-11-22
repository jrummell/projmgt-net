using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private User _manager;

        public ProjectServiceTests()
            : base(new ProjectService())
        {
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            UserService userService = new UserService();
            _manager = new User(UserRole.Manager, "Name" + new Random().Next(), "asdf");
            userService.Insert(_manager);

            base.TestInitialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            UserService userService = new UserService();
            userService.Delete(_manager.ID);

            base.TestCleanup();
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
            Project project = (Project) CreateRecord();
            target.Insert(project);

            target.Assign(project.ID, _manager.ID);

            target.Unassign(project.ID, _manager.ID);
            
            CollectionAssert.DoesNotContain(target.GetByUser(_manager.ID), project);
        }

        /// <summary>
        ///A test for GetByUser
        ///</summary>
        [TestMethod]
        public void GetByUser()
        {
            ProjectService target = new ProjectService();
            Project project = (Project) CreateRecord();
            Insert(project);

            target.Assign(project.ID, _manager.ID);

            Collection<Project> actual = target.GetByUser(_manager.ID);

            Assert.IsTrue(actual.Count == 1);

            target.Unassign(project.ID, _manager.ID);
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
            Project project = (Project) CreateRecord();
            Insert(project);

            target.Assign(project.ID, _manager.ID);

            Assert.IsTrue(target.GetByUser(_manager.ID).Count == 1);

            target.Unassign(project.ID, _manager.ID);
        }

        protected override IRecord CreateRecord()
        {
            return new Project("Name", "Description");
        }
    }
}