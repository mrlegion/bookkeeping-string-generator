using System;
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
    public class BankEditViewModel : ViewModelCustom
    {
        private Bank _bank;
        // конструктор
        public BankEditViewModel(IFrameNavigationService navigationService) : base(navigationService)
        {
            Messenger.Default.Register<NotificationMessage<Bank>>(this, (m) =>
            {
                if (m.Notification != "edit") return;
                if (m.Content == null) throw new ArgumentNullException(nameof(m.Content));
                _bank = m.Content;
                BankName = _bank.Name;
                BankCity = _bank.City;
                BankBik = _bank.Bik;
                BankAccountNumber = _bank.AccountNumber;
            });
        }

        private string _bankName;

        public const string BankNamePropertyName = "BankName";

        public string BankName
        {
            get { return _bankName; }
            set
            {
                Set(BankNamePropertyName, ref _bankName, value);
                ApplyChangesCommand.RaiseCanExecuteChanged();
            }
        }

        private string _bankCity;

        public const string BankCityPropertyName = "BankCity";

        public string BankCity
        {
            get { return _bankCity; }
            set
            {
                Set(BankCityPropertyName, ref _bankCity, value);
                ApplyChangesCommand.RaiseCanExecuteChanged();
            }
        }

        private string _bankBik;

        public const string BankBikPropertyName = "BankBik";

        public string BankBik
        {
            get { return _bankBik; }
            set
            {
                Set(BankBikPropertyName, ref _bankBik, value);
                ApplyChangesCommand.RaiseCanExecuteChanged();
            }
        }

        private string _bankAccountNumber;

        public const string BankAccountNumberPropertyName = "BankAccountNumber";

        public string BankAccountNumber
        {
            get { return _bankAccountNumber; }
            set
            {
                Set(BankAccountNumberPropertyName, ref _bankAccountNumber, value);
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
            get
            {
                return _applyChangesCommand ?? (_applyChangesCommand = new RelayCommand(() =>
                {
                    if (_bank == null) _bank = new Bank();
                    _bank.Name = BankName;
                    _bank.City = BankCity;
                    _bank.Bik = BankBik;
                    _bank.AccountNumber = BankAccountNumber;

                    var service = ServiceLocator.Current.GetInstance<BankCreationService>();
                    service.CreateBank(_bank);
                    NavigationService.GoBack();
                }, CheckInfo));
            }
        }

        private bool CheckString(string s)
        {
            return !string.IsNullOrEmpty(s) && !string.IsNullOrWhiteSpace(s);
        }

        private bool CheckInfo()
        {
            return CheckString(BankName)
                   && CheckString(BankCity)
                   && CheckString(BankAccountNumber)
                   && CheckString(BankBik);
        }
    }
}