using Autofac;
using DAL.Repository.Implimentation;
using DAL.Repository.Interface;

namespace DAL
{
    public class DalModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BankRepository>().As<IBankRepository>();
            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>();
            builder.RegisterType<OrganizationRepository>().As<IOrganizationRepository>();
            builder.RegisterType<BookkeepingLibraryContext>();
        }
    }
}