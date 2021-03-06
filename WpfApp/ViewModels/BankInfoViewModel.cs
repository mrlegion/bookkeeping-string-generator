﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using CommonServiceLocator;
using Domain.Services;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using Infrastructure.Entities;
using MaterialDesignThemes.Wpf;
using WpfApp.Common;
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
        private RelayCommand<object> _viewItemCommand;

        #endregion

        #region Construct

        public BankInfoViewModel(IFrameNavigationService navigationService) : base(navigationService)
        {
            BankInfoInitialize();
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
                return _deleteItemCommand ?? (_deleteItemCommand = new RelayCommand<object>(async (o) =>
                {
                    if (o != null)
                        if (o is Bank bank)
                        {
                            var result = await DialogHelper.ShowQuestenDialog(
                                $"Вы точно хотите удалить выбранный банк: {bank.Name}?",
                                PackIconKind.Delete);
                            if (result)
                            {
                                var service = ServiceLocator.Current.GetInstance<BankService>();
                                service.DeleteBank(bank);
                                Banks = service.GetAllBanks();
                            }
                        }
                }));
            }
        }

        public RelayCommand<object> ViewItemCommand
        {
            get
            {
                return _viewItemCommand ?? (_viewItemCommand = new RelayCommand<object>(async (o) =>
                {
                    if (o is Bank bank)
                    {
                        bool result =
                            await DialogHelper.ViewDetailDialog<BankDetailDialogView, BankDetailDialogViewModel, Bank>(bank, "Информация о банке");
                        if (result) NavigationService.NavigateTo("BankEdit", bank);
                    }
                }));
            }
        }

        #endregion

        #region Private Methods

        private void BankInfoInitialize()
        {
            DialogHelper.ShowLoadDialog(() =>
            {
                var service = ServiceLocator.Current.GetInstance<BankService>();
                var list = service.GetAllBanks();
                Banks = list;
            }, $"Загрузка данных{Environment.NewLine}Подождите...");
        }

        #endregion
    }
}