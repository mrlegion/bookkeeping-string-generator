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

            builder.RegisterType<BankCreationService>();
            builder.RegisterType<BankQueryService>();
            builder.RegisterType<CompanyCreationService>();
            builder.RegisterType<CompanyQueryService>();
            builder.RegisterType<OrganizationQueryService>();
            builder.RegisterType<OrganizationCreationService>();
        }
    }
}