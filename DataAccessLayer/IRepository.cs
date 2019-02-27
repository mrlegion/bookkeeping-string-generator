using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IRepository<T> where T : class, IEntity
    {
        #region Public methods

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
        void SaveAsync();

        T GetById(int id);

        Task<T> GetByIdAsync(int id);

        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();

        IEnumerable<T> SearchWhere(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> SearchWhereAsync(Expression<Func<T, bool>> predicate);

        #endregion
    }
}