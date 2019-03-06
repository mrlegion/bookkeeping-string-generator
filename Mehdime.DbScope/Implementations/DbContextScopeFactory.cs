using System.Data.Entity;
using Mehdime.DbScope.Interfaces;

namespace Mehdime.DbScope.Implementations
{
    public class DbContextScopeFactory : IDbContextFactory
    {
        public TDbContext CreateDbContext<TDbContext>() where TDbContext : DbContext
        {
            throw new System.NotImplementedException();
        }
    }
}