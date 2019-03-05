using System;
using System.Data;
using Infrastructure.Enums;

namespace Infrastructure.Interfaces
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