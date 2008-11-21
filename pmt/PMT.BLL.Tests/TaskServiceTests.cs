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
        private Module _module;
        private Project _project;

        public TaskServiceTests()
            : base(new TaskService())
        {
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod]
        public override void Update()
        {
            TaskService target = new TaskService();
            Task task = (Task) CreateRecord();
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
            TaskService target = new TaskService(); // TODO: Initialize to an appropriate value
            int taskID = 0; // TODO: Initialize to an appropriate value
            int devID = 0; // TODO: Initialize to an appropriate value
            target.Unassign(taskID, devID);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
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
            Assert.IsTrue(actual.Count >= 10);

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
            User user = new User(UserRole.Developer, "dev", "asdf");
            UserService userService = new UserService();
            userService.Insert(user);

            TaskService target = new TaskService();
            for (int i = 0; i < 5; i++)
            {
                InsertAndAssign(user);
            }

            Collection<Task> actual = target.GetAssigned();
            Assert.AreEqual(10, actual.Count);

            foreach (Task task in actual)
            {
                target.Unassign(task.ID, user.ID);
            }

            userService.Delete(user.ID);
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

        /// <summary>
        ///A test for Assign
        ///</summary>
        [TestMethod]
        public void Assign()
        {
            TaskService target = new TaskService();
            int taskID = 0; // TODO: Initialize to an appropriate value
            int devID = 0; // TODO: Initialize to an appropriate value
            target.Assign(taskID, devID);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
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
        }
    }
}