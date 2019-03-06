using System.Data.Entity;
using Mehdime.DbScope.Interfaces;

namespace Mehdime.DbScope.Implementations
{
    public class AmbientDbContextLocator : IAmbientDbContextLocator
    {
        public TDbContext Get<TDbContext>() where TDbContext : DbContext
        {
            var ambientDbContextScope = DbContextScope.GetAmbientScope();
            return ambientDbContextScope == null
                ? null
                : ambientDbContextScope.DbContexts.Get<TDbContext>();
        }
    }
}