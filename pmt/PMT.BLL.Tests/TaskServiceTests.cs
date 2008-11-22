using System;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PMT.BLL.Tests
{
    /// <summary>
    ///This is a test class for TaskServiceTests and is intended
    ///to contain all TaskServiceTests Unit Tests
    ///</summary>
    [TestClass]
    public class TaskServiceTests : DataServiceTests
    {
        private User _developer;
        private Module _module;
        private Project _project;

        public TaskServiceTests()
            : base(new TaskService())
        {
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            ProjectService projectService = new ProjectService();
            _project = new Project("Name", "Description");
            projectService.Insert(_project);

            ModuleService moduleService = new ModuleService();
            _module = new Module(_project.ID, "Name", "Description");
            moduleService.Insert(_module);

            UserService userService = new UserService();
            _developer = new User(UserRole.Developer, Guid.NewGuid().ToString(), "asdf");
            userService.Insert(_developer);

            base.TestInitialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();

            ModuleService moduleService = new ModuleService();
            moduleService.Delete(_module.ID);

            ProjectService projectService = new ProjectService();
            projectService.Delete(_project.ID);

            UserService userService = new UserService();
            userService.Delete(_developer.ID);
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod]
        public override void Update()
        {
            TaskService target = new TaskService();
            Task task = (Task) CreateRecord();
            Insert(task);

            task.Description = "asdf 123";
            task.Complexity = TaskComplexity.High;

            target.Update(task);

            Task updated = target.GetByID(task.ID);

            Assert.AreEqual(task.Description, updated.Description);
            Assert.AreEqual(task.Complexity, updated.Complexity);
        }

        /// <summary>
        ///A test for Unassign
        ///</summary>
        [TestMethod]
        public void Unassign()
        {
            TaskService target = new TaskService();
            Task task = (Task) CreateRecord();
            Insert(task);

            target.Assign(task.ID, _developer.ID);

            target.Unassign(task.ID);

            Assert.AreEqual(0, target.GetByUser(_developer.ID).Count);
        }

        /// <summary>
        ///A test for GetTasksByModule
        ///</summary>
        [TestMethod]
        public void GetByModule()
        {
            for (int i = 0; i < 10; i++)
            {
                Insert(CreateRecord());
            }

            TaskService target = new TaskService();

            Collection<Task> actual = target.GetByModule(_module.ID);
            Assert.AreEqual(10, actual.Count);

            foreach (Task task in actual)
            {
                Assert.AreEqual(_module.ID, task.ModuleID);
            }
        }

        /// <summary>
        ///A test for GetAssignedTasks
        ///</summary>
        [TestMethod]
        public void GetAssigned()
        {
            TaskService target = new TaskService();
            for (int i = 0; i < 5; i++)
            {
                InsertAndAssign(_developer);
            }

            Collection<Task> actual = target.GetByUser(_developer.ID);
            Assert.AreEqual(5, actual.Count);

            foreach (Task task in actual)
            {
                target.Unassign(task.ID);
            }
        }

        /// <summary>
        ///A test for Assign
        ///</summary>
        [TestMethod]
        public void Assign()
        {
            TaskService target = new TaskService();
            Task task = (Task) CreateRecord();
            Insert(task);

            target.Assign(task.ID, _developer.ID);

            Assert.AreEqual(1, target.GetByUser(_developer.ID).Count);

            target.Unassign(task.ID);
        }

        private void InsertAndAssign(User user)
        {
            TaskService target = new TaskService();
            Task task = (Task) CreateRecord();
            Insert(task);

            target.Assign(task.ID, user.ID);
        }

        protected override IRecord CreateRecord()
        {
            return new Task(_module.ID, "Name", "Description", TaskComplexity.Medium);
        }
    }
}