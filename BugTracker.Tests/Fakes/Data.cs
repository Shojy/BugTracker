using System;
using System.Collections.Generic;
using BugTracker.DAL.Models;
using Newtonsoft.Json;

namespace BugTracker.Tests.Fakes
{
    public class Data
    {
        /// <summary>
        /// Simple clone method to protect source objects from changing.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T Clone<T>(T obj)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));
        }

        public static List<Bug> AllBugs => Clone(new List<Bug> { OpenBug1, OpenBug2, ClosedBug1, ClosedBug2 });

        public static List<Person> AllPeople = Clone(new List<Person> { Person1, Person2, Person3 });

        public static Bug OpenBug1 = new Bug
        {
            Id = 1,
            DateOpened = new DateTime(2019, 2, 23, 11, 30, 00),
            Status = BugStatus.Open,
            Title = "First Bug",
            Description = "This is the first bug reported.",
            DateClosed = null,
            AssignedPeople = new List<AssignedBug>()
        };

        public static Bug OpenBug2 = new Bug
        {
            Id = 2,
            DateOpened = new DateTime(2019, 2, 23, 11, 35, 00),
            Status = BugStatus.Open,
            Title = "This is another bug",
            Description = "This is another bug description.",
            DateClosed = null,
            AssignedPeople = new List<AssignedBug> { new AssignedBug {  Person = Person1 } }
        };

        public static Bug ClosedBug1 = new Bug
        {
            Id = 3,
            DateOpened = new DateTime(2019, 2, 23, 11, 39, 00),
            Status = BugStatus.Closed,
            Title = "Closed Bug",
            Description = "This is a closed bug.",
            DateClosed = new DateTime(2019, 2, 23, 11, 40, 00),
            AssignedPeople = new List<AssignedBug> { new AssignedBug { Person = Person3 } }
        };


        public static Bug ClosedBug2 = new Bug
        {
            Id = 4,
            DateOpened = new DateTime(2019, 2, 23, 11, 39, 00),
            Status = BugStatus.Closed,
            Title = "Closed Bug 2",
            Description = "This is another closed bug.",
            DateClosed = new DateTime(2019, 2, 23, 11, 40, 00),
            AssignedPeople = new List<AssignedBug> { new AssignedBug {Person = Person1 }, new AssignedBug { Person = Person2 } }
        };

        public static Person Person1 = new Person
        {
            Id = 1,
            Name = "John Smith"
        };

        public static Person Person2 = new Person
        {
            Id = 2,
            Name = "Jane Doe"
        };

        public static Person Person3 = new Person
        {
            Id = 3,
            Name = "Joshua Moon"
        };
    }
}