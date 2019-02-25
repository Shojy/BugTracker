using System.Collections.Generic;
using System.Linq;
using BugTracker.DAL.Models;
using BugTracker.DAL.Repositories;

namespace BugTracker.Services
{
    public class PersonService : IPersonService
    {
        protected IRepository<Person> PersonRepository { get; }

        public PersonService(IRepository<Person> personRepository)
        {
            this.PersonRepository = personRepository;
        }

        public List<Person> AllPeople()
        {
            return this.PersonRepository.Query().ToList();
        }
    }
}