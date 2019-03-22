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
using WpfApp.Service;

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
                return _clearListCommand ?? (_clearListCommand = new RelayCommand(() =>
                {
                    if (Orders == null) return;
                    if (Orders.Count == 0) return;

                    // Todo: Переделать на DialogHost
                    var result = MessageBox.Show("Вы точно хотите очистить список платежных поручений?",
                        "Очистка списка", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
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
                    IsLoadData = true;
                    ThreadPool.QueueUserWorkItem(o =>
                    {
                        _generator.OnGenerateList(Orders);
                        Thread.Sleep(1000);
                        IsLoadData = false;
                    });
                }, () => Orders.Count > 0));
            }
        }

        public RelayCommand<PaymentOrder> ViewDetailCommand
        {
            get
            {
                return _viewDetailCommand ?? (_viewDetailCommand = new RelayCommand<PaymentOrder>((o) =>
                {
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
                return _deleteItemCommand ?? (_deleteItemCommand = new RelayCommand<PaymentOrder>((o) =>
                {
                    if (o == null) return; // Todo : Сообщить пользователю, что не выбран никакой объект

                    var result = MessageBox.Show("Вы точно хотите удалить выбранное платежное поручение?",
                        "Удаление платежного поручения", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        bool deleted = Orders.Remove(o);
                        if (deleted)
                            MessageBox.Show("Платежное поручение успешно удалено!", "Успешно", MessageBoxButton.OK,
                                MessageBoxImage.Information);
                        else MessageBox.Show("Ошибка при попытки удалить платежное поручение!", "Ошибка", MessageBoxButton.OK,
                            MessageBoxImage.Error);

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