using BugTracker.DAL.Models;
using System.Linq;

namespace BugTracker.DAL.Queries
{
    public static class BugQueries
    {
        #region Public Methods

        public static IQueryable<Bug> OpenBugs(this IQueryable<Bug> bugs)
        {
            return bugs.Where(b => b.Status == BugStatus.Open);
        }

        #endregion Public Methods
    }
}