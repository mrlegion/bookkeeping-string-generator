using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
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
            InitViews();
            InitViewModels();
        }

        public ShellViewModel Shell => ServiceLocator.Current.GetInstance<ShellViewModel>();
        public AdministrationViewModel Administration => ServiceLocator.Current.GetInstance<AdministrationViewModel>();
        public OrganizationViewModel Organization => ServiceLocator.Current.GetInstance<OrganizationViewModel>();
        public BankInfoView BankInfo => ServiceLocator.Current.GetInstance<BankInfoView>();
        public BankEditView BankEdit => ServiceLocator.Current.GetInstance<BankEditView>();
        public CompanyInfoView CompanyInfo => ServiceLocator.Current.GetInstance<CompanyInfoView>();
        public CompanyEditViewModel CompanyEdit => ServiceLocator.Current.GetInstance<CompanyEditViewModel>();
        

        private static void InitViewModels()
        {
            SimpleIoc.Default.Register<ShellViewModel>();
            SimpleIoc.Default.Register<AdministrationViewModel>();
            SimpleIoc.Default.Register<OrganizationViewModel>();
            SimpleIoc.Default.Register<BankInfoViewModel>();
            SimpleIoc.Default.Register<BankEditViewModel>();
            SimpleIoc.Default.Register<CompanyInfoViewModel>();
            SimpleIoc.Default.Register<CompanyEditViewModel>();
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
        }

        private static void InitComponents()
        {
        }
    }
}