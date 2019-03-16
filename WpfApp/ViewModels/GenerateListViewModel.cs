using System;
using System.Collections.ObjectModel;
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
                }
            });
        }

        private ObservableCollection<PaymentOrder> _orders;

        public ObservableCollection<PaymentOrder> Orders
        {
            get { return _orders; }
            set { Set(nameof(Orders), ref _orders, value); }
        }

        private RelayCommand _addItemCommand;

        public RelayCommand AddItemCommand
        {
            get
            {
                return _addItemCommand ?? (_addItemCommand = new RelayCommand(() =>
                           {
                               NavigationService.NavigateTo("GenerateList");
                           }));
            }
        }

        private RelayCommand _generateCommand;

        public RelayCommand GenerateCommand
        {
            get
            {
                return _generateCommand ?? (_generateCommand = new RelayCommand(() =>
                {
                    _generator.OnGenerateList(Orders);
                    MessageBox.Show("Сборка файла");
                }, () => Orders.Count > 0));
            }
        }
    }
}