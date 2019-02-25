using BugTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.DAL
{
    public class BugTrackerContext : DbContext, IDataContext
    {
        public BugTrackerContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bug>();
            modelBuilder.Entity<Person>();
            modelBuilder.Entity<AssignedBug>();
        }
    }
}