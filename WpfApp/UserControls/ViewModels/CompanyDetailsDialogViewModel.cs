using System.Collections.Generic;
using System.Threading;

using CommonServiceLocator;

using Domain.Services;

using Infrastructure.Entities;

using WpfApp.Service;
using WpfApp.ViewModels;

namespace WpfApp.UserControls.ViewModels
{
    public class CompanyDetailsDialogViewModel : ViewModelCustom
    {
        private Company _company;

        public Company Company
        {
            get { return _company; }
            set
            {
                Set(nameof(Company), ref _company, value);
                InitializeFields();
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { Set(nameof(Name), ref _name, value); }
        }

        private string _inn;

        public string Inn
        {
            get { return _inn; }
            set { Set(nameof(Inn), ref _inn, value); }
        }

        private string _kpp;

        public string Kpp
        {
            get { return _kpp; }
            set { Set(nameof(Kpp), ref _kpp, value); }
        }

        private IEnumerable<Organization> _organizations;

        public IEnumerable<Organization> Organizations
        {
            get { return _organizations; }
            set { Set(nameof(Organizations), ref _organizations, value); }
        }

        private void InitializeFields()
        {
            Name = Company.Name;
            Inn = Company.Inn;
            Kpp = Company.Kpp;

            ThreadPool.QueueUserWorkItem((o) =>
            {
                var service = ServiceLocator.Current.GetInstance<OrganizationService>();
                Organizations = service.GetOrganizationByCompanyId(Company.Id);
            });
        }

        public CompanyDetailsDialogViewModel(IFrameNavigationService navigationService) : base(navigationService)
        {}
    }
}