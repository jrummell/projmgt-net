using System;
using System.Collections;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PMT.BLL.Tests
{
    public abstract class DataServiceTests
    {
        private readonly Collection<IRecord> _insertedRecords = new Collection<IRecord>();
        private readonly IDataService _dataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataServiceTests"/> class.
        /// </summary>
        /// <param name="dataService">The data service.</param>
        protected DataServiceTests(IDataService dataService)
        {
            if (dataService == null)
            {
                throw new ArgumentNullException("dataService");
            }

            _dataService = dataService;
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public virtual void TestInitialize()
        {
            _dataService.VerifyDefaults();
        }

        [TestCleanup]
        public virtual void TestCleanup()
        {
            foreach (IRecord record in _insertedRecords)
            {
                _dataService.Delete(record.ID);
            }
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod]
        public abstract void Update();

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod]
        public virtual void Insert()
        {
            IRecord record = CreateRecord();
            Insert(record);

            Assert.IsTrue(_dataService.Exists(record.ID));
        }

        /// <summary>
        ///A test for GetByID
        ///</summary>
        [TestMethod]
        public virtual void GetByID()
        {
            IRecord record = CreateRecord();
            Insert(record);

            Assert.IsNotNull(_dataService.GetByID(record.ID));
        }

        /// <summary>
        ///A test for Exists
        ///</summary>
        public virtual void Exists()
        {
            IRecord record = CreateRecord();
            Insert(record);

            Assert.IsTrue(_dataService.Exists(record.ID));
        }

        /// <summary>
        ///A test for GetAll
        ///</summary>
        [TestMethod]
        public virtual void GetAll()
        {
            for (int i = 0; i < 15; i++)
            {
                Insert(CreateRecord());
            }

            ICollection actual = _dataService.GetAll();
            Assert.IsTrue(actual.Count >= 15);
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod]
        public virtual void Delete()
        {
            IRecord record = CreateRecord();

            _dataService.Delete(record.ID);
            Assert.IsNull(_dataService.GetByID(record.ID));
            Assert.IsFalse(_dataService.Exists(record.ID));
        }

        /// <summary>
        /// Inserts the specified record.
        /// </summary>
        /// <param name="record">The record.</param>
        protected virtual void Insert(IRecord record)
        {
            if (record == null)
            {
                throw new ArgumentNullException("record");
            }

            _dataService.Insert(record);

            _insertedRecords.Add(record);
        }

        /// <summary>
        /// Creates the record.
        /// </summary>
        /// <returns></returns>
        protected abstract IRecord CreateRecord();
    }
}