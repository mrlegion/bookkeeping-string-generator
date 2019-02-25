using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain
{
    public interface IRepository<T> : IDisposable where T: class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();

        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAllWhere(Expression<Func<T, bool>> predicate);
    }
}