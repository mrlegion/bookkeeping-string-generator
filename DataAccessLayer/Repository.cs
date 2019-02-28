using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public async void Update(T entity)
        {
            var item = await GetByIdAsync(entity.Id);
            if (item != null)
                Context.Entry(entity).State = EntityState.Modified;
        }

        public async void Delete(T entity)
        {
            var item = await GetByIdAsync(entity.Id);
            if (item != null)
                Context.Entry(entity).State = EntityState.Deleted;

        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async void SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public IEnumerable<T> SearchWhere(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();
        }

        public async Task<IEnumerable<T>> SearchWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
