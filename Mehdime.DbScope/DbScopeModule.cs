using Autofac;
using Mehdime.DbScope.Implementations;
using Mehdime.DbScope.Interfaces;

namespace Mehdime.DbScope
{
    public class DbScopeModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AmbientContextSuppressor>();
            builder.RegisterType<AmbientDbContextLocator>().As<IAmbientDbContextLocator>();
            builder.RegisterType<DbContextScope>().As<IDbContextScope>();
            builder.RegisterType<DbContextCollection>().As<IDbContextCollection>();
            builder.RegisterType<DbContextFactory>().As<IDbContextFactory>();
            builder.RegisterType<DbContextReadOnlyScope>().As<IDbContextReadOnlyScope>();
            builder.RegisterType<DbContextScopeFactory>().As<IDbContextScopeFactory>();
        }
    }
}