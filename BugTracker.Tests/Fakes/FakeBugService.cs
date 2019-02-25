using System.Collections.Generic;
using System.Linq;
using BugTracker.DAL.Models;
using BugTracker.Services;

namespace BugTracker.Tests.Fakes
{
    public class FakeBugService : IBugsService
    {
        public List<Bug> StorageList { get; set; } = new List<Bug>();

        public Bug StorageSingle { get; set; }

        public Bug AssignPeopleToBug(Bug bug, params Person[] people)
        {
            this.StorageSingle = bug;
            return bug;
        }

        public List<Bug> OpenBugs()
        {
            return this.StorageList.Where(b => b.Status == BugStatus.Open).ToList();
        }

        public List<Bug> AllBugs()
        {
            return this.StorageList;
        }

        public Bug BugFromId(int id)
        {
            return this.StorageList.FirstOrDefault(b => b.Id == id);
        }

        public Bug CreateNewBug(Bug bug)
        {
            throw new System.NotImplementedException();
        }

        public Bug UpdateBug(Bug bug)
        {
            throw new System.NotImplementedException();
        }

        public void CloseBug(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}