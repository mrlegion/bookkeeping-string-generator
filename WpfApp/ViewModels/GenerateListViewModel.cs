using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using CommonServiceLocator;
using Domain.Helpers;
using Domain.Model;
using Domain.Services;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Infrastructure.Entities;
using MaterialDesignThemes.Wpf;
using WpfApp.Common;
using WpfApp.Service;
using WpfApp.UserControls.ViewModels;
using WpfApp.UserControls.Views;

namespace WpfApp.ViewModels
{
    public class GenerateListViewModel : ViewModelCustom
    {
        #region Fields

        private readonly IGenerator _generator;
        private bool _isLoadData;
        private ObservableCollection<PaymentOrder> _orders;
        private RelayCommand _clearListCommand;
        private RelayCommand _generateCommand;
        private RelayCommand<PaymentOrder> _viewDetailCommand;
        private RelayCommand<object> _editItemCommand;
        private RelayCommand<PaymentOrder> _deleteItemCommand;
        private RelayCommand _addNewItemToListCommand;

        #endregion

        #region Construct

        public GenerateListViewModel(IFrameNavigationService navigationService, IGenerator generator) : base(navigationService)
        {
            Title = "Список информации для сборки";

            _generator = generator;

            if (Orders == null) Orders = new ObservableCollection<PaymentOrder>();

            //if (NavigationService.Parameter is PaymentOrder order)
            //    Orders.Add(order);

            Messenger.Default.Register<NotificationMessage<PaymentOrder>>(this, (m) =>
            {
                if (m == null) throw new ArgumentNullException(nameof(m));
                if (m.Content is PaymentOrder order)
                {
                    Orders.Add(order);
                    GenerateCommand.RaiseCanExecuteChanged();
                    ClearListCommand.RaiseCanExecuteChanged();
                }
            });
        }

        #endregion

        #region Properties

        public bool IsLoadData
        {
            get { return _isLoadData; }
            set { Set(nameof(IsLoadData), ref _isLoadData, value); }
        }

        public ObservableCollection<PaymentOrder> Orders
        {
            get { return _orders; }
            set
            {
                Set(nameof(Orders), ref _orders, value);
                ClearListCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand ClearListCommand
        {
            get
            {
                return _clearListCommand ?? (_clearListCommand = new RelayCommand(async () =>
                {
                    if (Orders == null) return;
                    if (Orders.Count == 0) return;

                    bool result = await DialogHelper.ShowQuestenDialog(
                        "Вы точно хотите очистить список платежных поручений?",
                        PackIconKind.Delete);
                    if (result)
                    {
                        Orders.Clear();
                        ClearListCommand.RaiseCanExecuteChanged();
                    }
                }, () => !OrderIsEmptyOrNull()));
            }
        }

        public RelayCommand GenerateCommand
        {
            get
            {
                return _generateCommand ?? (_generateCommand = new RelayCommand(() =>
                {
                    DialogHelper.ShowLoadDialog(() =>
                    {
                        _generator.OnGenerateList(Orders);
                        Thread.Sleep(1000);
                    }, $"Идет создание файла{Environment.NewLine}Подождите...");
                }, () => Orders.Count > 0));
            }
        }

        public RelayCommand<PaymentOrder> ViewDetailCommand
        {
            get
            {
                return _viewDetailCommand ?? (_viewDetailCommand = new RelayCommand<PaymentOrder>(async (o) =>
                {
                    if (o == null)
                    {
                        DialogHelper.ShowInformerDialog("Не выбранно платежное поручение!", PackIconKind.Error);
                        return;
                    }

                    bool result =
                        await DialogHelper
                            .ViewDetailDialog<PaymentOrderDetailView, PaymentOrderDetailViewModel, PaymentOrder>(o,
                                "Информация о платежном поручении");
                    if (result) NavigationService.NavigateTo("Generate", o);
                }));
            }
        }

        public RelayCommand<object> EditItemCommand
        {
            get
            {
                return _editItemCommand ?? (_editItemCommand = new RelayCommand<object>((o) =>
                {
                    if (o == null) return;
                    NavigationService.NavigateTo("Generate", o);
                }));
            }
        }

        public RelayCommand<PaymentOrder> DeleteItemCommand
        {
            get
            {
                return _deleteItemCommand ?? (_deleteItemCommand = new RelayCommand<PaymentOrder>(async (o) =>
                {
                    if (o == null)
                    {
                        DialogHelper.ShowInformerDialog("Не выбранно платежное поручение для удаления!", PackIconKind.Error);
                        return;
                    }

                    bool result = await DialogHelper.ShowQuestenDialog(
                        "Вы точно хотите удалить выбранное платежное поручение?",
                        PackIconKind.Delete);

                    if (result)
                    {
                        bool deleted = Orders.Remove(o);
                        if (deleted) DialogHelper.ShowInformerDialog("Платежное поручение успешно удалено!", PackIconKind.Check);
                        else DialogHelper.ShowInformerDialog("Ошибка при попытки удалить платежное поручение!", PackIconKind.Error);
                        ClearListCommand.RaiseCanExecuteChanged();
                    }
                }));
            }
        }

        public RelayCommand AddNewItemToListCommand
        {
            get
            {
                return _addNewItemToListCommand ?? (_addNewItemToListCommand = new RelayCommand(() =>
                {
                    var item = new PaymentOrder()
                    {
                        Number = new Random().Next(10, 9999),
                        Date = DateTime.Now,
                        InDate = DateTime.Now,
                        OutDate = DateTime.Now,
                        AcceptDate = DateTime.Now,
                        Total = "3424-56",
                        TotalText = RuDateAndMoneyConverter.CurrencyToTxt(3424.56d, true),
                        Description = "SomeOne Description",
                        Payer = ServiceLocator.Current.GetInstance<OrganizationService>().GetOrganization(7),
                        Recipient = ServiceLocator.Current.GetInstance<OrganizationService>().GetOrganization(2),
                        TypeOfPaying = "01",
                        TypeOfPayment = "электронно",
                        QueuePayment = "5"
                    };
                    Orders.Add(item);
                }));
            }
        }

        #endregion

        #region Private methods

        private bool OrderIsEmptyOrNull() => Orders == null || Orders.Count == 0;

        #endregion
    }
}