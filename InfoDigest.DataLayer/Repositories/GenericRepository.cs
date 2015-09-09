using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace InfoDigest.DataLayer.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class 
    {
        private DbSet<TEntity> DBSet { get; set; }
        private DbContext Context { get; set; }

        public GenericRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required", "context");
            }
            Context = context;
            DBSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return DBSet;
        }

        public async Task<TEntity> GetById(int id)
        {
            return await DBSet.FindAsync(id);
        }

        public void Add(TEntity entity)
        {
            DbEntityEntry<TEntity> entry = Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                DBSet.Add(entity);
            }
        }

        public void Update(TEntity entity)
        {
            DbEntityEntry<TEntity> entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                DBSet.Attach(entity);
            }
            entry.State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            DbEntityEntry<TEntity> entry = Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                DBSet.Attach(entity);
                DBSet.Remove(entity);
            }
        }

        public async void Delete(int id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }

        public void Detach(TEntity entity)
        {
            DbEntityEntry<TEntity> entry = Context.Entry(entity);
            entry.State = EntityState.Detached;
        }
    }
}