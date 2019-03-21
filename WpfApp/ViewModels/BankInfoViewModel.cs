using System.Collections.Generic;
using System.Threading;
using System.Windows;
using CommonServiceLocator;
using Domain.Services;
using GalaSoft.MvvmLight.Command;
using Infrastructure.Entities;
using WpfApp.Service;

namespace WpfApp.ViewModels
{
    /// <summary>
    /// Description this class
    /// </summary>
    public class BankInfoViewModel : ViewModelCustom
    {
        public BankInfoViewModel(IFrameNavigationService navigationService) : base(navigationService)
        {
            IsLoadData = true;

            ThreadPool.QueueUserWorkItem(o =>
            {
                var service = ServiceLocator.Current.GetInstance<BankService>();
                var list = service.GetAllBanks();
                Banks = list;
                IsLoadData = false;
            });
        }

        private bool _isLoadData;

        public bool IsLoadData
        {
            get { return _isLoadData; }
            set { Set(nameof(IsLoadData), ref _isLoadData, value); }
        }

        private IEnumerable<Bank> _banks;

        public const string BanksPropertyName = "Banks";

        public IEnumerable<Bank> Banks
        {
            get { return _banks; }
            set { Set(BanksPropertyName, ref _banks, value); }
        }

        private RelayCommand<object> _editItemCommand;

        public RelayCommand<object> EditItemCommand
        {
            get
            {
                return _editItemCommand ?? (_editItemCommand = new RelayCommand<object>((o) =>
                {
                    if (o != null)
                        if (o is Bank bank)
                            NavigationService.NavigateTo("BankEdit", bank);
                }));
            }
        }

        private RelayCommand<object> _deleteItemCommand;

        public RelayCommand<object> DeleteItemCommand
        {
            get
            {
                return _deleteItemCommand ?? (_deleteItemCommand = new RelayCommand<object>((o) =>
                {
                    if (o != null)
                        if (o is Bank bank)
                        {
                            // Todo: Использовать MaterialDesign DialogHost
                            var result = MessageBox.Show($"Вы точно хотите удалить выбранный банк: {bank.Name}?",
                                "Подтверждение на удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (result != MessageBoxResult.Yes) return;
                            var service = ServiceLocator.Current.GetInstance<BankService>();
                            service.DeleteBank(bank);
                            Banks = service.GetAllBanks();
                        }
                }));
            }
        }
    }
}