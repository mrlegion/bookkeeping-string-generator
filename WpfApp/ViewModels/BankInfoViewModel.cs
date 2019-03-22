using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using CommonServiceLocator;
using Domain.Services;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using Infrastructure.Entities;
using MaterialDesignThemes.Wpf;
using WpfApp.Service;
using WpfApp.UserControls.ViewModels;
using WpfApp.UserControls.Views;

namespace WpfApp.ViewModels
{
    /// <summary>
    /// Description this class
    /// </summary>
    public class BankInfoViewModel : ViewModelCustom
    {
        #region Fields

        private IEnumerable<Bank> _banks;
        private RelayCommand<object> _editItemCommand;
        private RelayCommand<object> _deleteItemCommand;

        #endregion

        #region Construct

        public BankInfoViewModel(IFrameNavigationService navigationService) : base(navigationService)
        {

            ThreadPool.QueueUserWorkItem(o =>
            {
                var service = ServiceLocator.Current.GetInstance<BankService>();
                var list = service.GetAllBanks();
                Banks = list;
            });
        }

        #endregion

        #region Properties

        public IEnumerable<Bank> Banks
        {
            get { return _banks; }
            set { Set(nameof(Banks), ref _banks, value); }
        }

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

        #endregion

        #region Private Methods

        private void BankInfoInitialize()
        {
            var content = ServiceLocator.Current.GetInstance<LoadDialogView>();
            var model = ServiceLocator.Current.GetInstance<LoadDialogViewModel>();
            model.Message = $"Загрузка данных{Environment.NewLine}Подождите...";
            content.DataContext = model;
            DialogHost.Show(content, "RootDialogHost",
                delegate (object sender, DialogOpenedEventArgs args)
                {
                    ThreadPool.QueueUserWorkItem((o) =>
                    {
                        var service = ServiceLocator.Current.GetInstance<BankService>();
                        var list = service.GetAllBanks();
                        Banks = list;
                        DispatcherHelper.CheckBeginInvokeOnUI(() => { args.Session.Close(false); });
                    });
                });
        }

        #endregion
    }
}