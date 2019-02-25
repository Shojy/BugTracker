using System;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.DAL
{
    public interface IDataContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();

    }
}