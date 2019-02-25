using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BugTracker.DAL.Models
{
    public class Bug : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateOpened { get; set; }
        public DateTime? DateClosed { get; set; }
        public List<AssignedBug> AssignedPeople { get; set; } = new List<AssignedBug>();
        public BugStatus Status { get; set; } = BugStatus.Open;
    }
}
