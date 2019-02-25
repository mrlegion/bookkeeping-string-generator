using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain
{
    public class Repositiory<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;

        public Repositiory(DbContext context)
        {
            Context = context;
        }

        public async void Add(T entity)
        {
            await Task.Run(() => Context.Set<T>().Add(entity));
        }

        public void Delete(T entity)
        {
            //var item = await Context.Set<T>().FindAsync(entity.Id);
            //if (item != null)
            //    Context.Entry(entity).State = EntityState.Deleted;
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

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWhere(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async void Save()
        {
            await Context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
