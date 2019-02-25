using BugTracker.DAL.Models;
using BugTracker.DAL.Queries;
using BugTracker.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BugTracker.Tests.UnitTests.DAL.Queries
{
    [TestClass]
    public class BugQueriesTests
    {
        #region Protected Properties

        protected FakeRepository<Bug> FakeRepo { get; set; }

        #endregion Protected Properties



        #region Public Methods

        [TestMethod]
        public void QueryCanFetchOpenBugs()
        {
            var bugs = this.FakeRepo.Query().OpenBugs();

            Assert.AreEqual(2, bugs.Count());
            Assert.IsTrue(bugs.All(b => b.Status == BugStatus.Open));
        }

        [TestInitialize]
        public void Setup()
        {
            this.FakeRepo = new FakeRepository<Bug> { Storage = Data.AllBugs };
        }

        #endregion Public Methods
    }
}