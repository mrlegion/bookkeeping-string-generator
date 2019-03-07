﻿using System.Data;
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

        public DbContextReadOnlyScope(IDbContextFactory dbContextFactory = null)
            : this(DbContextScopeOption.ForceCreateNew, null, dbContextFactory)
        {}

        public DbContextReadOnlyScope(IsolationLevel? isolationLevel, IDbContextFactory dbContextFactory = null)
            : this(DbContextScopeOption.ForceCreateNew, isolationLevel, dbContextFactory)
        {}

        public DbContextReadOnlyScope(DbContextScopeOption joiningOption, IsolationLevel? isolationLevel, IDbContextFactory dbContextFactory = null)
        {
            _internalScope = new DbContextScope(joiningOption, true, isolationLevel);
        }

        public void Dispose()
        {
            _internalScope.Dispose();
        }
    }
}