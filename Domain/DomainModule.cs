using Autofac;
using DAL;
using Domain.Services;
using Mehdime.DbScope;

namespace Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DalModule());
            builder.RegisterModule(new DbScopeModule());

            builder.RegisterType<BankService>();
            builder.RegisterType<CompanyService>();
            builder.RegisterType<OrganizationService>();
        }
    }
}