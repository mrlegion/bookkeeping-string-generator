using System.Data.Entity;

namespace Mehdime.DbScope.Interfaces
{
    public interface IDbContextFactory
    {
        TDbContext CreateDbContext<TDbContext>() where TDbContext : DbContext;
    }
}