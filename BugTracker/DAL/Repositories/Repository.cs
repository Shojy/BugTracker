using BugTracker.DAL.Models;
using System.Linq;

namespace BugTracker.DAL.Repositories
{
    public class Repository<TModel> : IRepository<TModel> where TModel : Entity
    {
        #region Public Constructors

        public Repository(IDataContext context)
        {
            this.Context = context;
        }

        #endregion Public Constructors



        #region Protected Properties

        protected IDataContext Context { get; }

        #endregion Protected Properties



        #region Public Methods

        public void Add(TModel entity)
        {
            this.Context.Set<TModel>().Add(entity);
            this.Context.SaveChanges();
        }

        public TModel GetId(int id)
        {
            return this.Context.Set<TModel>().Find(id);
        }

        public IQueryable<TModel> Query()
        {
            return this.Context.Set<TModel>().AsQueryable();
        }

        public void Update(TModel entity)
        {
            this.Context.Set<TModel>().Update(entity);
            this.Context.SaveChanges();
        }

        #endregion Public Methods
    }
}