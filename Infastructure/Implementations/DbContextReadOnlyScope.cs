using Infrastructure.Enums;
using Infrastructure.Interfaces;
using System.Data;

namespace Infrastructure.Implementations
{
    public class DbContextReadOnlyScope : IDbContextReadOnlyScope
    {
        private DbContextScope _internalScope;

        public IDbContextCollection DbContexts
        {
            get { return _internalScope.DbContexts; }
        }

        public DbContextReadOnlyScope(IDbContextFactory dbContextFactory = null)
            : this(DbContextScopeOption.ForceCreateNew, null, dbContextFactory)
        {}

        public DbContextReadOnlyScope(IsolationLevel? isolationLevel, IDbContextFactory dbContextFactory = null)
            : this(DbContextScopeOption.ForceCreateNew, isolationLevel, dbContextFactory)
        {}

        public DbContextReadOnlyScope(DbContextScopeOption joiningOption, IsolationLevel? isolationLevel, IDbContextFactory dbContextFactory = null)
        {
            _internalScope = new DbContextScope(joiningOption, true, isolationLevel, dbContextFactory);
        }

        public void Dispose()
        {
            _internalScope.Dispose();
        }
    }
}