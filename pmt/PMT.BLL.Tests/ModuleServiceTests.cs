using System;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PMT.BLL.Tests
{
    /// <summary>
    ///This is a test class for ModuleServiceTests and is intended
    ///to contain all ModuleServiceTests Unit Tests
    ///</summary>
    [TestClass]
    public class ModuleServiceTests : DataServiceTests
    {
        private Project _project;

        public ModuleServiceTests()
            : base(new ModuleService())
        {
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod]
        public override void Update()
        {
            ModuleService target = new ModuleService();
            Module module = (Module) CreateRecord();
            Insert(module);

            module.Description = "asdf 123";
            target.Update(module);

            Module updated = target.GetByID(module.ID);
            Assert.AreEqual(module.Description, updated.Description);
        }

        /// <summary>
        ///A test for GetByProject
        ///</summary>
        [TestMethod]
        public void GetByProject()
        {
            for (int i = 0; i < 10; i++)
            {
                Insert(CreateRecord());
            }

            ModuleService target = new ModuleService();
            Collection<Module> collection = target.GetByProject(_project.ID);

            Assert.IsTrue(collection.Count >= 10);

            foreach (Module module in collection)
            {
                Assert.AreEqual(_project.ID, module.ProjectID);
            }
        }

        protected override IRecord CreateRecord()
        {
            return new Module(_project.ID, "Name", "Description");
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            ProjectService projectService = new ProjectService();
            _project = new Project("Name", "Description")
                           {
                               StartDate = DateTime.Now.AddDays(-7),
                               ExpEndDate = DateTime.Now.AddDays(1)
                           };

            projectService.Insert(_project);

            base.TestInitialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();

            ProjectService projectService = new ProjectService();
            projectService.Delete(_project.ID);
        }
    }
}