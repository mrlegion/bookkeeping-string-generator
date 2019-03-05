using System;
using System.Data.Entity;

namespace Infrastructure.Interfaces
{
    public interface IDbContextCollection : IDisposable
    {
        TDbContext Get<TDbContext>() where TDbContext : DbContext;
    }
}