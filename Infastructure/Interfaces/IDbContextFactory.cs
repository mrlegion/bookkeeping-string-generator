using System.Data.Entity;

namespace Infrastructure.Interfaces
{
    public interface IDbContextFactory
    {
        TDbContext CreateDbContext<TDbContext>() where TDbContext : DbContext;
    }
}