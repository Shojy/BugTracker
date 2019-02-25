using BugTracker.DAL.Models;
using BugTracker.DAL.Queries;
using BugTracker.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Services
{
    public class BugsService : IBugsService
    {
        #region Public Constructors

        public BugsService(IRepository<Bug> repo)
        {
            this.BugsRepository = repo;
        }

        #endregion Public Constructors



        #region Protected Properties

        protected IRepository<Bug> BugsRepository { get; }

        #endregion Protected Properties



        #region Public Methods

        public List<Bug> AllBugs()
        {
            return this.BugsRepository.Query()
                .Include(b => b.AssignedPeople)
                .ThenInclude(b => b.Person)
                .ToList();
        }

        public Bug AssignPeopleToBug(Bug bug, params Person[] people)
        {
            foreach (var p in people)
            {
                bug.AssignedPeople.Add(new AssignedBug { BugId = bug.Id, Person = p, PersonId = p.Id });
            }

            this.BugsRepository.Update(bug);
            return bug;
        }

        public Bug BugFromId(int id)
        {
            return this.BugsRepository.GetId(id);
        }

        public void CloseBug(int id)
        {
            var bug = this.BugsRepository.GetId(id);
            bug.Status = BugStatus.Closed;
            this.BugsRepository.Update(bug);
        }

        public Bug CreateNewBug(Bug bug)
        {
            this.BugsRepository.Add(bug);
            return bug;
        }

        public List<Bug> OpenBugs()
        {
            return this.BugsRepository.Query()
                .OpenBugs()
                .Include(b => b.AssignedPeople)
                .ThenInclude(b => b.Person)
                .ToList();
        }

        public Bug UpdateBug(Bug bug)
        {
            this.BugsRepository.Update(bug);
            return bug;
        }

        #endregion Public Methods
    }
}