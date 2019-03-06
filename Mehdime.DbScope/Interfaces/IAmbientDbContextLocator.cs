using System.Data.Entity;

namespace Mehdime.DbScope.Interfaces
{
    public interface IAmbientDbContextLocator
    {
        TDbContext Get<TDbContext>() where TDbContext : DbContext;
    }
}