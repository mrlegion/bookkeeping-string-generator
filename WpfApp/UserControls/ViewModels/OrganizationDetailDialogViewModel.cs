using System;
using System.Collections.Generic;
using Infrastructure.Entities;

namespace WpfApp.UserControls.ViewModels
{
    public class OrganizationDetailDialogViewModel : UserControlViewModelBase<Organization>
    {
        private IDictionary<string, string> _general;

        public IDictionary<string, string> General
        {
            get { return _general; }
            set { Set(nameof(General), ref _general, value); }
        }

        private IDictionary<string, string> _company;

        public IDictionary<string, string> Company
        {
            get { return _company; }
            set { Set(nameof(Company), ref _company, value); }
        }

        private IDictionary<string, string> _bank;

        public IDictionary<string, string> Bank
        {
            get { return _bank; }
            set { Set(nameof(Bank), ref _bank, value); }
        }

        public override void Init(Organization entity, string title)
        {
            base.Init(entity, title);

            General = new Dictionary<string, string>() { { "Номер счёта организации:", Entity.AccountNumber } };
            Company = new Dictionary<string, string>()
            {
                { "Наименование компании:", Entity.Company.Name },
                { "Номер ИНН компании:", Entity.Company.Inn },
                { "Номер КПП компании:", Entity.Company.Kpp },
            };
            Bank = new Dictionary<string, string>()
            {
                { "Наименование банка:", Entity.Bank.Name },
                { "Город банка:", Entity.Bank.City },
                { "Номер БИК:", Entity.Bank.Bik },
                { "Номер счёта банка:", Entity.Bank.AccountNumber },
            };
        }
    }
}