using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain
{
    /// <summary>
    /// Description this class
    /// </summary>
    public interface IDtoRepository<T> : IDisposable where T: class
    {
        IEnumerable<T> GetDetails();
        IEnumerable<T> GetSimple();
        IEnumerable<T> GetDetailsWhere(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetSimplesWhere(Expression<Func<T, bool>> predicate);
    }
}