using System.Collections;
using System.Collections.Generic;
using BugTracker.DAL.Models;
using BugTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        protected IPersonService PersonService { get; }

        public PeopleController(IPersonService personService)
        {
            this.PersonService = personService;
        }

        // GET
        public ActionResult<IEnumerable<Person>> Get()
        {
            return this.PersonService.AllPeople();
        }
    }
}