using System;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using Domain;
using GalaSoft.MvvmLight.Ioc;
using WpfApp.Service;
using WpfApp.UserControls.ViewModels;
using WpfApp.UserControls.Views;
using WpfApp.Views;

namespace WpfApp.ViewModels
{
    /// <summary>
    /// ViewModelLocator для управления доступа к ViewModels
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new DomainModule());
            builder.RegisterModule(new NavigationModule());

            // register viewmodel
            builder.RegisterType<ShellViewModel>();
            builder.RegisterType<AdministrationViewModel>();
            builder.RegisterType<OrganizationViewModel>();
            builder.RegisterType<BankEditViewModel>();
            builder.RegisterType<BankInfoViewModel>();
            builder.RegisterType<CompanyEditViewModel>();
            builder.RegisterType<CompanyInfoViewModel>();
            builder.RegisterType<GenerateViewModel>();
            builder.RegisterType<HomeViewModel>();
            builder.RegisterType<OrganizationEditViewModel>();
            builder.RegisterType<GenerateListViewModel>().SingleInstance();

            // register view
            builder.RegisterType<ShellWindow>();
            builder.RegisterType<AdministrationView>();
            builder.RegisterType<OrganizationView>();
            builder.RegisterType<BankEditView>();
            builder.RegisterType<BankInfoView>();
            builder.RegisterType<CompanyEditView>();
            builder.RegisterType<CompanyInfoView>();
            builder.RegisterType<GenerateView>();
            builder.RegisterType<HomeView>();
            builder.RegisterType<OrganizationEditView>();
            builder.RegisterType<GenerateListView>();

            // register dialogs
            builder.RegisterType<LoadDialogView>();
            builder.RegisterType<LoadDialogViewModel>();
            builder.RegisterType<CompanyDetailsDialogView>();
            builder.RegisterType<CompanyDetailsDialogViewModel>();
            builder.RegisterType<BankDetailDialogView>();
            builder.RegisterType<BankDetailDialogViewModel>();

            var container = builder.Build();
            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
        }

        public ShellViewModel Shell => ServiceLocator.Current.GetInstance<ShellViewModel>();
        public AdministrationViewModel Administration => ServiceLocator.Current.GetInstance<AdministrationViewModel>();
        public OrganizationViewModel OrganizationInfo => ServiceLocator.Current.GetInstance<OrganizationViewModel>();
        public BankInfoViewModel BankInfo => ServiceLocator.Current.GetInstance<BankInfoViewModel>();
        public BankEditViewModel BankEdit => ServiceLocator.Current.GetInstance<BankEditViewModel>();
        public CompanyInfoViewModel CompanyInfo => ServiceLocator.Current.GetInstance<CompanyInfoViewModel>();
        public CompanyEditViewModel CompanyEdit => ServiceLocator.Current.GetInstance<CompanyEditViewModel>();
        public GenerateViewModel Generate => ServiceLocator.Current.GetInstance<GenerateViewModel>();
        public HomeViewModel Home => ServiceLocator.Current.GetInstance<HomeViewModel>();
        public OrganizationEditViewModel OrganizationEdit => ServiceLocator.Current.GetInstance<OrganizationEditViewModel>();
        public GenerateListViewModel GenerateList => ServiceLocator.Current.GetInstance<GenerateListViewModel>();

        // dialogs
        public LoadDialogViewModel LoadDialog => ServiceLocator.Current.GetInstance<LoadDialogViewModel>();
        public CompanyDetailsDialogViewModel CompanyDetailsDialog => ServiceLocator.Current.GetInstance<CompanyDetailsDialogViewModel>();
        public BankDetailDialogViewModel BankDetailDialog => ServiceLocator.Current.GetInstance<BankDetailDialogViewModel>();

        internal class NavigationModule : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                var service = new FrameNavigationService("RootFrame");
                service.Configure("Admin", new Uri("..\\Views\\AdministrationView.xaml", UriKind.Relative));
                service.Configure("OrganizationInfo", new Uri("..\\Views\\OrganizationView.xaml", UriKind.Relative));
                service.Configure("Bank", new Uri("..\\Views\\BankInfoView.xaml", UriKind.Relative));
                service.Configure("BankEdit", new Uri("..\\Views\\BankEditView.xaml", UriKind.Relative));
                service.Configure("Company", new Uri("..\\Views\\CompanyInfoView.xaml", UriKind.Relative));
                service.Configure("CompanyEdit", new Uri("..\\Views\\CompanyEditView.xaml", UriKind.Relative));
                service.Configure("Home", new Uri("..\\Views\\HomeView.xaml", UriKind.Relative));
                service.Configure("Generate", new Uri("..\\Views\\GenerateView.xaml", UriKind.Relative));
                service.Configure("OrganizationEdit", new Uri("..\\Views\\OrganizationEditView.xaml", UriKind.Relative));
                service.Configure("GenerateList", new Uri("..\\Views\\GenerateListView.xaml", UriKind.Relative));
                builder.Register(c => service).As<IFrameNavigationService>();
            }
        }
    }
}