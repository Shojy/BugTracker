using System.Collections.Generic;
using BugTracker.DAL.Models;

namespace BugTracker.Services
{
    public interface IPersonService
    {
        List<Person> AllPeople();
    }
}