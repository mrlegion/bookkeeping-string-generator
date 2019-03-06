using System;
using System.Data;
using Mehdime.DbScope.Enums;

namespace Mehdime.DbScope.Interfaces
{
    public interface IDbContextScopeFactory
    {
        IDbContextScope Create(DbContextScopeOption joiningOption = DbContextScopeOption.JoinExisting);
        IDbContextReadOnlyScope CreateReadOnly(DbContextScopeOption joiningOption = DbContextScopeOption.JoinExisting);
        IDbContextScope CreateWithTransaction(IsolationLevel isolationLevel);
        IDbContextReadOnlyScope CreateReadOnlyWithTransaction(IsolationLevel isolationLevel);
        IDisposable SuppressAmbientContext();
    }
}