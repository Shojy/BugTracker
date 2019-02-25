using BugTracker.DAL.Models;
using BugTracker.Services;
using BugTracker.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BugTracker.Tests.UnitTests.Services
{
    [TestClass]
    public class BugsServiceTests
    {
        #region Protected Fields

        protected FakeRepository<Bug> FakeRepo;
        protected BugsService ServiceUnderTest;

        #endregion Protected Fields



        #region Public Methods

        [TestMethod]
        public void ServiceClosesClosedBug()
        {
            var bug = Data.Clone(Data.ClosedBug1);

            this.ServiceUnderTest.CloseBug(bug.Id);

            var b = this.FakeRepo.Storage.FirstOrDefault(x => x.Id == bug.Id);

            Assert.IsNotNull(b);
            Assert.AreEqual(BugStatus.Closed, b.Status);
        }

        [TestMethod]
        public void ServiceClosesOpenBug()
        {
            var bug = Data.Clone(Data.OpenBug1);

            this.ServiceUnderTest.CloseBug(bug.Id);

            var b = this.FakeRepo.Storage.FirstOrDefault(x => x.Id == bug.Id);

            Assert.IsNotNull(b);
            Assert.AreEqual(BugStatus.Closed, b.Status);
        }

        [TestMethod]
        public void ServiceGetsOpenBugs()
        {
            var bugs = this.ServiceUnderTest.OpenBugs();

            Assert.AreEqual(2, bugs.Count);
            Assert.IsTrue(bugs.TrueForAll(b => b.Status == BugStatus.Open));
        }

        [TestInitialize]
        public void Setup()
        {
            this.FakeRepo = new FakeRepository<Bug> { Storage = Data.AllBugs };
            this.ServiceUnderTest = new BugsService(this.FakeRepo);
        }

        #endregion Public Methods
    }
}