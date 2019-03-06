using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace Mehdime.DbScope.Interfaces
{
    public interface IDbContextScope : IDisposable
    {
        IDbContextCollection DbContexts { get; }

        int SaveChanges();
        Task<int> SaveChangeAsync();
        Task<int> SaveChangeAsync(CancellationToken cancelToken);
        void RefreshEntitiesInParentScope(IEnumerable entities);
        Task RefreshEntitiesInParentScopeAsync(IEnumerable entities);
    }
}