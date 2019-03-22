using System.Collections.Generic;
using System.Threading;
using CommonServiceLocator;
using Domain.Services;
using GalaSoft.MvvmLight;
using Infrastructure.Entities;
using WpfApp.Service;
using WpfApp.ViewModels;

namespace WpfApp.UserControls.ViewModels
{
    public class BankDetailDialogViewModel : ViewModelCustom
    {
        public BankDetailDialogViewModel(IFrameNavigationService navigationService) : base(navigationService)
        {}

        private string _name;

        public string Name
        {
            get { return _name; }
            set { Set(nameof(Name), ref _name, value); }
        }

        private string _bik;

        public string Bik
        {
            get { return _bik; }
            set { Set(nameof(Bik), ref _bik, value); }
        }

        private string _accountNumber;

        public string AccountNumber
        {
            get { return _accountNumber; }
            set { Set(nameof(AccountNumber), ref _accountNumber, value); }
        }

        private IEnumerable<Organization> _organizations;

        public IEnumerable<Organization> Organizations
        {
            get { return _organizations; }
            set { Set(nameof(Organizations), ref _organizations, value); }
        }

        private Bank _bank;

        public Bank Bank
        {
            get { return _bank; }
            set
            {
                Set(nameof(Bank), ref _bank, value);
                Initialize();
            }
        }

        private void Initialize()
        {
            Name = Bank.Name;
            Bik = Bank.Bik;
            AccountNumber = Bank.AccountNumber;

            ThreadPool.QueueUserWorkItem(o =>
            {
                var service = ServiceLocator.Current.GetInstance<OrganizationService>();
                Organizations = service.GetOrganizationByBankId(Bank.Id);
            });
        }
    }
}