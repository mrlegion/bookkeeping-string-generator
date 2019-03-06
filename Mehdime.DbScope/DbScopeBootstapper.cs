using GalaSoft.MvvmLight.Ioc;
using Mehdime.DbScope.Implementations;
using Mehdime.DbScope.Interfaces;

namespace Mehdime.DbScope
{
    public class DbScopeBootstapper
    {
        public static void Init()
        {
            SimpleIoc.Default.Register<IAmbientDbContextLocator, AmbientDbContextLocator>();
            //SimpleIoc.Default.Register<IDbContextCollection, DbContextCollection>();
            SimpleIoc.Default.Register<IDbContextScopeFactory, DbContextScopeFactory>();
            //SimpleIoc.Default.Register<IDbContextReadOnlyScope, DbContextReadOnlyScope>();
            //SimpleIoc.Default.Register<IDbContextScope, DbContextScope>();
        }
    }
}