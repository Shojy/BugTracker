using System.Collections.Generic;
using System.Linq;
using BugTracker.DAL.Models;
using Microsoft.EntityFrameworkCore.Design;

namespace BugTracker.DAL.Repositories
{
    public interface IRepository<TModel> where TModel : Entity
    {
        IQueryable<TModel> Query();
        TModel GetId(int id);
        void Add(TModel entity);
        void Update(TModel entity);
    }
}