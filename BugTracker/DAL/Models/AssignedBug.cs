using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.DAL.Models
{
    public class AssignedBug
    {
        public int Id { get; set; }
        public int BugId { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
