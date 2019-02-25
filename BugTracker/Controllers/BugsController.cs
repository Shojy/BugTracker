using BugTracker.DAL.Models;
using BugTracker.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BugTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BugsController : Controller
    {
        #region Public Constructors

        public BugsController(IBugsService bugsService)
        {
            this.BugService = bugsService;
        }

        #endregion Public Constructors



        #region Protected Properties

        protected IBugsService BugService { get; }

        #endregion Protected Properties



        #region Public Methods

        // This should close the issue
        [HttpDelete("{id}")]
        public ActionResult<Bug> Delete(int id)
        {
            this.BugService.CloseBug(id);
            return this.Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Bug>> Get()
        {
            return this.BugService.AllBugs();
        }

        [HttpGet("{id}")]
        public ActionResult<Bug> Get(int id)
        {
            var bug = this.BugService.BugFromId(id);

            if (null == bug)
            {
                return this.NotFound();
            }

            return bug;
        }

        [HttpGet("open")]
        public ActionResult<IEnumerable<Bug>> GetOpen()
        {
            return this.BugService.OpenBugs();
        }

        [HttpPost]
        public ActionResult<Bug> Post(Bug bug)
        {
            this.BugService.CreateNewBug(bug);
            return this.Created(this.Url.Action(nameof(this.Get), new { id = bug.Id }), bug);
        }

        [HttpPut("{id}")]
        public ActionResult<Bug> Put(int id, Bug bug)
        {
            var b = this.BugService.BugFromId(id);

            if (null == b)
            {
                return this.NotFound();
            }

            bug.Id = id; // Ensure consistency
            this.BugService.UpdateBug(bug);
            return this.Ok(bug);
        }

        #endregion Public Methods
    }
}