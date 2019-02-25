using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BugTracker.DAL.Models;
using Newtonsoft.Json;

namespace BugTracker.DAL
{
    public static class DbInitializer
    {
        public static void Init(BugTrackerContext context)
        {
            context.Database.EnsureCreated();
        }

        public static void Seed(BugTrackerContext context)
        {
            if (context.Set<Bug>().Any() || context.Set<Person>().Any())
            {
                return; // Don't seed if existing data is present
            }

            List<Bug> bugs;
            List<Person> people;

            using (var reader = new StreamReader(Path.Combine("SampleData", "Bugs.json")))
            {
                bugs = JsonConvert.DeserializeObject<List<Bug>>(reader.ReadToEnd());
            }
            using (var reader = new StreamReader(Path.Combine("SampleData", "People.json")))
            {
                people = JsonConvert.DeserializeObject<List<Person>>(reader.ReadToEnd());
            }

            var random = new Random(1); // Using a fixed seed gives a consistent set of seed data

            context.Set<Person>().AddRange(people);
            context.Set<Bug>().AddRange(bugs);
            context.SaveChanges();

            foreach (var bug in bugs)
            {
                var assigned = people.OrderBy(_ => random.Next()).Take(random.Next(0, 3));

                foreach (var a in assigned)
                {
                    bug.AssignedPeople.Add(
                        new AssignedBug
                        {
                            BugId = bug.Id,
                            PersonId = a.Id,
                            Person = a,
                        });
                    
                }
            }

            context.SaveChanges();
        }
    }
}