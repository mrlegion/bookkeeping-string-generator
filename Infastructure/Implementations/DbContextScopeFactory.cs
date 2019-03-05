using System.Data.Entity;
using Infrastructure.Interfaces;

namespace Infrastructure.Implementations
{
    public class DbContextScopeFactory : IDbContextFactory
    {
        public TDbContext CreateDbContext<TDbContext>() where TDbContext : DbContext
        {
            throw new System.NotImplementedException();
        }
    }
}