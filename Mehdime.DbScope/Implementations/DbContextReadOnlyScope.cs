using System.Data;
using Mehdime.DbScope.Enums;
using Mehdime.DbScope.Interfaces;

namespace Mehdime.DbScope.Implementations
{
    public class DbContextReadOnlyScope : IDbContextReadOnlyScope
    {
        private DbContextScope _internalScope;

        public IDbContextCollection DbContexts
        {
            get { return _internalScope.DbContexts; }
        }

        public DbContextReadOnlyScope()
            : this(DbContextScopeOption.ForceCreateNew, null)
        {}

        public DbContextReadOnlyScope(IsolationLevel? isolationLevel)
            : this(DbContextScopeOption.ForceCreateNew, isolationLevel)
        {}

        public DbContextReadOnlyScope(DbContextScopeOption joiningOption, IsolationLevel? isolationLevel/*, IDbContextFactory dbContextFactory = null*/)
        {
            _internalScope = new DbContextScope(joiningOption, true, isolationLevel);
        }

        public void Dispose()
        {
            _internalScope.Dispose();
        }
    }
}