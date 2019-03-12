using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using CommonServiceLocator;
using Domain.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Infrastructure.Entities;
using WpfApp.Service;

namespace WpfApp.ViewModels
{
    /// <summary>
    /// Description this class
    /// </summary>
    public class CompanyEditViewModel : ViewModelCustom
    {
        private Company _company;

        public CompanyEditViewModel(IFrameNavigationService navigationService) : base(navigationService)
        {
            if (IsEditable())
                if (NavigationService.Parameter is Company company)
                {
                    _company = company;
                    CompanyName = _company.Name;
                    CompanyInn = _company.Inn;
                    CompanyKpp = _company.Kpp;
                }
        }

        private string _companyName;

        public const string CompanyNamePropertyName = "CompanyName";

        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                Set(CompanyNamePropertyName, ref _companyName, value);
                ApplyChangesCommand.RaiseCanExecuteChanged();
            }
        }

        private string _companyInn;

        public const string CompanyInnPropertyName = "CompanyInn";

        public string CompanyInn
        {
            get { return _companyInn; }
            set
            {
                Set(CompanyInnPropertyName, ref _companyInn, value);
                ApplyChangesCommand.RaiseCanExecuteChanged();
            }
        }

        private string _companyKpp;

        public const string CompanyKppPropertyName = "CompanyKpp";

        public string CompanyKpp
        {
            get { return _companyKpp; }
            set
            {
                Set(CompanyKppPropertyName, ref _companyKpp, value);
                ApplyChangesCommand.RaiseCanExecuteChanged();
            }
        }

        private string _comments;

        public const string CommentsPropertyName = "Comments";

        public string Comments
        {
            get { return _comments; }
            set { Set(CommentsPropertyName, ref _comments, value); }
        }

        private bool _openDialog;

        public const string OpenDialogPropertyName = "OpenDialog";

        public bool OpenDialog
        {
            get { return _openDialog; }
            set { Set(OpenDialogPropertyName, ref _openDialog, value); }
        }

        private RelayCommand _applyChangesCommand;

        public RelayCommand ApplyChangesCommand
        {
            get { return _applyChangesCommand ?? (_applyChangesCommand = new RelayCommand(() =>
            {
                if (_company == null) _company = new Company(CompanyName, CompanyInn, CompanyKpp);
                else
                {
                    _company.Name = CompanyName;
                    _company.Inn = CompanyInn;
                    _company.Kpp = CompanyKpp;
                }

                if (IsEditable())
                {
                    System.Diagnostics.Debug.WriteLine("Update company");
                }
                else
                {
                    var service = ServiceLocator.Current.GetInstance<CompanyService>();
                    service.CreateCompany(_company);
                    System.Diagnostics.Debug.WriteLine("Create new company");
                }

                NavigationService.GoBack();
            }, CheckInfo)); }
        }

        private bool IsEditable() => NavigationService.Parameter != null;

        private bool CheckString(string s)
        {
            return !string.IsNullOrEmpty(s) && !string.IsNullOrWhiteSpace(s);
        }

        private bool CheckInfo()
        {
            return CheckString(CompanyName)
                   && CheckString(CompanyInn)
                   && CheckString(CompanyKpp);
        }
    }
}