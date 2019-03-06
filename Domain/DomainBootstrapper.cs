using Domain.Services;
using GalaSoft.MvvmLight.Ioc;
using Mehdime.DbScope;

namespace Domain
{
    public class DomainBootstrapper
    {
        public static void Init()
        {
            // call bootstrapper in DbScope
            DbScopeBootstapper.Init();

            // services
            SimpleIoc.Default.Register<BankCreationService>();
            SimpleIoc.Default.Register<BankQueryService>();
        }
    }
}