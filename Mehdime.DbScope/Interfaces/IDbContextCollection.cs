using System;
using System.Data.Entity;

namespace Mehdime.DbScope.Interfaces
{
    public interface IDbContextCollection : IDisposable
    {
        TDbContext Get<TDbContext>() where TDbContext : DbContext;
    }
}