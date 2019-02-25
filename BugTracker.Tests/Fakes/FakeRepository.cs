using System;
using System.Collections.Generic;
using System.Linq;
using BugTracker.DAL.Models;
using BugTracker.DAL.Repositories;

namespace BugTracker.Tests.Fakes
{
    public class FakeRepository<TModel> : IRepository<TModel> where TModel : Entity
    {
        public List<TModel> Storage { get; set; } = new List<TModel>();
    

        public IQueryable<TModel> Query()
        {
            return this.Storage.AsQueryable();
        }

        public TModel GetId(int id)
        {
            return this.Storage.FirstOrDefault(b => b.Id == id);
        }

        public void Add(TModel entity)
        {
            this.Storage.Add(entity);
        }
        
        public void Update(TModel entity)
        {
            // Simple replace
            var item = this.Storage.First(e => e.Id == entity.Id);
            this.Storage.Insert(this.Storage.IndexOf(item), entity);
            this.Storage.Remove(item);
        }
    }
}