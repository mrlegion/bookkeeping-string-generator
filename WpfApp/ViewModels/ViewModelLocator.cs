using System;
using System.Windows.Media;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using WpfApp.Service;
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
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            InitComponents();
            InitNavigation();

            InitDao();

            InitViews();
            InitViewModels();
        }

        public ShellViewModel Shell => ServiceLocator.Current.GetInstance<ShellViewModel>();
        public AdministrationViewModel Administration => ServiceLocator.Current.GetInstance<AdministrationViewModel>();
        public OrganizationViewModel Organization => ServiceLocator.Current.GetInstance<OrganizationViewModel>();
        public BankInfoViewModel BankInfo => ServiceLocator.Current.GetInstance<BankInfoViewModel>();
        public BankEditViewModel BankEdit => ServiceLocator.Current.GetInstance<BankEditViewModel>();
        public CompanyInfoViewModel CompanyInfo => ServiceLocator.Current.GetInstance<CompanyInfoViewModel>();
        public CompanyEditViewModel CompanyEdit => ServiceLocator.Current.GetInstance<CompanyEditViewModel>();
        public GenerateViewModel Generate => ServiceLocator.Current.GetInstance<GenerateViewModel>();
        public HomeViewModel Home => ServiceLocator.Current.GetInstance<HomeViewModel>();

        private static void InitViewModels()
        {
            SimpleIoc.Default.Register<ShellViewModel>();
            SimpleIoc.Default.Register<AdministrationViewModel>();
            SimpleIoc.Default.Register<OrganizationViewModel>();
            SimpleIoc.Default.Register<BankInfoViewModel>();
            SimpleIoc.Default.Register<BankEditViewModel>();
            SimpleIoc.Default.Register<CompanyInfoViewModel>();
            SimpleIoc.Default.Register<CompanyEditViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<GenerateViewModel>();
        }

        private static void InitViews()
        {
            SimpleIoc.Default.Register<ShellWindow>();
            SimpleIoc.Default.Register<AdministrationView>();
            SimpleIoc.Default.Register<OrganizationView>();
            SimpleIoc.Default.Register<CompanyEditView>();
            SimpleIoc.Default.Register<CompanyInfoView>();
            SimpleIoc.Default.Register<BankEditView>();
            SimpleIoc.Default.Register<BankInfoView>();
            SimpleIoc.Default.Register<HomeView>();
            SimpleIoc.Default.Register<GenerateView>();
        }

        private static void InitComponents()
        {
        }

        private static void InitNavigation()
        {
            var service = new FrameNavigationService("RootFrame");
            service.Configure("Admin", new Uri("../Views/AdministrationView.xaml", UriKind.Relative));
            service.Configure("Organization", new Uri("../Views/OrganizationView.xaml", UriKind.Relative));
            service.Configure("Bank", new Uri("../Views/BankInfoView.xaml", UriKind.Relative));
            service.Configure("BankEdit", new Uri("../Views/BankEditView.xaml", UriKind.Relative));
            service.Configure("Company", new Uri("../Views/CompanyInfoView.xaml", UriKind.Relative));
            service.Configure("CompanyEdit", new Uri("..\\Views\\CompanyEditView.xaml", UriKind.Relative));
            service.Configure("Home", new Uri("..\\Views\\HomeView.xaml", UriKind.Relative));
            service.Configure("Generate", new Uri("../Views/GenerateView.xaml", UriKind.Relative));
            SimpleIoc.Default.Register<IFrameNavigationService>(() => service);
        }

        // TODO: Вынести в другое место
        private static void InitDao()
        {
        }
    }
}