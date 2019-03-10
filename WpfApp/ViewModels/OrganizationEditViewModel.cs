﻿using System;
using System.Collections.Generic;
using CommonServiceLocator;
using Domain.Services;
using GalaSoft.MvvmLight.Command;
using Infrastructure.Entities;
using WpfApp.Service;

namespace WpfApp.ViewModels
{
    public class OrganizationEditViewModel : ViewModelCustom
    {
        private Organization _organization;

        public OrganizationEditViewModel(IFrameNavigationService navigationService) : base(navigationService)
        {
            Banks = ServiceLocator.Current.GetInstance<BankQueryService>().GetAllBanks();
            Companies = ServiceLocator.Current.GetInstance<CompanyQueryService>().GetAllCompanies();
        }

        private IEnumerable<Bank> _banks;

        public const string BanksPropertyName = "Banks";

        public IEnumerable<Bank> Banks
        {
            get { return _banks; }
            set { Set(BanksPropertyName, ref _banks, value); }
        }

        private IEnumerable<Company> _companies;

        public const string CompaniesPropertyName = "Companies";

        public IEnumerable<Company> Companies
        {
            get { return _companies; }
            set { Set(CompaniesPropertyName, ref _companies, value); }
        }

        private string _accountNumber;

        public const string AccountNumberPropertyName = "AccountNumber";

        public string AccountNumber
        {
            get { return _accountNumber; }
            set
            {
                Set(AccountNumberPropertyName, ref _accountNumber, value);
                ApplyChangesCommand.RaiseCanExecuteChanged();
            }
        }

        private Company _selectCompany;

        public const string SelectCompanyPropertyName = "SelectCompany";

        public Company SelectCompany
        {
            get { return _selectCompany; }
            set
            {
                Set(SelectCompanyPropertyName, ref _selectCompany, value);
                ApplyChangesCommand.RaiseCanExecuteChanged();
            }
        }

        private Bank _selectBank;

        public const string SelectBankPropertyName = "SelectBank";

        public Bank SelectBank
        {
            get { return _selectBank; }
            set
            {
                Set(SelectBankPropertyName, ref _selectBank, value);
                ApplyChangesCommand.RaiseCanExecuteChanged();
            }
        }

        private RelayCommand _applyChangesCommand;

        public RelayCommand ApplyChangesCommand
        {
            get
            {
                return _applyChangesCommand ?? (_applyChangesCommand = new RelayCommand(() =>
                {
                    if (_organization == null) _organization = new Organization();

                    _organization.AccountNumber = AccountNumber.Replace(" ", "");
                    _organization.Company = SelectCompany;
                    _organization.Bank = SelectBank;

                    var service = ServiceLocator.Current.GetInstance<OrganizationCreationService>();
                    service.CreateOrganization(_organization);
                    NavigationService.GoBack();

                }, () => SelectCompany != null && SelectBank != null && !string.IsNullOrEmpty(AccountNumber)));
            }
        }
    }
}