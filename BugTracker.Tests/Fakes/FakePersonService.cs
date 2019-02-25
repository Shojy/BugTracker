using System.Collections.Generic;
using BugTracker.DAL.Models;
using BugTracker.Services;

namespace BugTracker.Tests.Fakes
{
    public class FakePersonService : IPersonService
    {
        public List<Person> AllPeople()
        {
            throw new System.NotImplementedException();
        }
    }
}