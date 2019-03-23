using System;
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
    public class BankDetailDialogViewModel : UserControlViewModelBase
    {
        #region Fields

        private string _name;
        private string _bik;
        private string _accountNumber;
        private IEnumerable<Organization> _organizations;
        private Bank _bank;

        #endregion

        #region Properties

        public string Name
        {
            get { return _name; }
            set { Set(nameof(Name), ref _name, value); }
        }

        public string Bik
        {
            get { return _bik; }
            set { Set(nameof(Bik), ref _bik, value); }
        }

        public string AccountNumber
        {
            get { return _accountNumber; }
            set { Set(nameof(AccountNumber), ref _accountNumber, value); }
        }

        public IEnumerable<Organization> Organizations
        {
            get { return _organizations; }
            set { Set(nameof(Organizations), ref _organizations, value); }
        }

        public Bank Bank
        {
            get { return _bank; }
            set { Set(nameof(Bank), ref _bank, value); }
        }

        private bool _isCanEdit;

        public bool IsCanEdit
        {
            get { return _isCanEdit; }
            set { Set(nameof(IsCanEdit), ref _isCanEdit, value); }
        }

        #endregion

        #region Public Methods

        public override void Init(object obj)
        {
            Bank = obj as Bank;
            if (Bank == null) throw new ArgumentNullException(nameof(Bank));

            Name = Bank.Name;
            Bik = Bank.Bik;
            AccountNumber = Bank.AccountNumber;

            ThreadPool.QueueUserWorkItem(o =>
            {
                var service = ServiceLocator.Current.GetInstance<OrganizationService>();
                Organizations = service.GetOrganizationByBankId(Bank.Id);
            });
        }

        #endregion
    }
}