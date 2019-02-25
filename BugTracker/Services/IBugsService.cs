using System.Collections.Generic;
using BugTracker.DAL.Models;

namespace BugTracker.Services
{
    public interface IBugsService
    {
        Bug AssignPeopleToBug(Bug bug, params Person[] people);

        List<Bug> OpenBugs();
        List<Bug> AllBugs();

        Bug BugFromId(int id);

        Bug CreateNewBug(Bug bug);

        Bug UpdateBug(Bug bug);
        void CloseBug(int id);
    }
}