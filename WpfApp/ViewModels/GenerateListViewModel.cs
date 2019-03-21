using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using Domain.Model;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Infrastructure.Entities;
using WpfApp.Service;

namespace WpfApp.ViewModels
{
    public class GenerateListViewModel : ViewModelCustom
    {
        private readonly IGenerator _generator;

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

        private bool _isLoadData;

        public bool IsLoadData
        {
            get { return _isLoadData; }
            set { Set(nameof(IsLoadData), ref _isLoadData, value); }
        }

        private ObservableCollection<PaymentOrder> _orders;

        public ObservableCollection<PaymentOrder> Orders
        {
            get { return _orders; }
            set
            {
                Set(nameof(Orders), ref _orders, value);
                ClearListCommand.RaiseCanExecuteChanged();
            }
        }

        private RelayCommand _clearListCommand;

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

        private RelayCommand _generateCommand;

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

        private bool OrderIsEmptyOrNull() => Orders == null || Orders.Count == 0;
    }
}