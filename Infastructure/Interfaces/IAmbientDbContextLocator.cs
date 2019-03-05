using System.Data.Entity;

namespace Infrastructure.Interfaces
{
    public interface IAmbientDbContextLocator
    {
        TDbContext Get<TDbContext>() where TDbContext : DbContext;
    }
}