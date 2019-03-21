using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
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
    public class GenerateViewModel : ViewModelCustom
    {
        private int _numberOrder;
        private DateTime _date;
        private DateTime _inDate;
        private DateTime _outDate;
        private DateTime _acceptDate;
        private string _total;
        private string _totalText;
        private IEnumerable<Organization> _organizations;
        private Organization _payer;
        private Organization _recipient;
        private string _description;
        private string _paymentType;
        private string _typeOfPaying;
        private string _queuePayment;

        private readonly IGenerator _generator;

        private bool _useOneDate;

        private bool _autoTotalText;
        private RelayCommand _generateCommand;

        public GenerateViewModel(IFrameNavigationService navigationService, IGenerator generator) : base(
            navigationService)
        {
            Title = "Создание файла";
            IsLoadedData = true;
            _generator = generator;
            Date = DateTime.Now;
            SetAllDateToOne();
            TypeOfPaying = "01";
            PaymentType = "0";
            QueuePayment = "5";

            ThreadPool.QueueUserWorkItem(o =>
            {
                var service = ServiceLocator.Current.GetInstance<OrganizationService>();
                var list = service.GetOrganizationAsync().Result;
                Organizations = list;
                Thread.Sleep(200);
                IsLoadedData = false;
            });
        }

        private bool _isLoadedData;

        public bool IsLoadedData
        {
            get { return _isLoadedData; }
            set { Set(nameof(IsLoadedData), ref _isLoadedData, value); }
        }

        public int NumberOrder
        {
            get => _numberOrder;
            set
            {
                Set(nameof(NumberOrder), ref _numberOrder, value);
                GenerateCommand.RaiseCanExecuteChanged();
            }
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                Set(nameof(Date), ref _date, value);
                if (UseOneDate) SetAllDateToOne();
            }
        }

        public DateTime InDate
        {
            get => _inDate;
            set => Set(nameof(InDate), ref _inDate, value);
        }

        public DateTime OutDate
        {
            get => _outDate;
            set => Set(nameof(OutDate), ref _outDate, value);
        }

        public DateTime AcceptDate
        {
            get => _acceptDate;
            set => Set(nameof(AcceptDate), ref _acceptDate, value);
        }

        public string Total
        {
            get => _total;
            set
            {
                value = Regex.Replace(value, "\\.|,", "-");

                Set(nameof(Total), ref _total, value);
                if (AutoTotalText) ConvertTotalToString();
                GenerateCommand.RaiseCanExecuteChanged();
            }
        }

        public string TotalText
        {
            get => _totalText;
            set
            {
                Set(nameof(TotalText), ref _totalText, value);
                GenerateCommand.RaiseCanExecuteChanged();
            }
        }

        public IEnumerable<Organization> Organizations
        {
            get => _organizations;
            set => Set(nameof(Organizations), ref _organizations, value);
        }

        public Organization Payer
        {
            get => _payer;
            set
            {
                Set(nameof(Payer), ref _payer, value);
                GenerateCommand.RaiseCanExecuteChanged();
            }
        }

        public Organization Recipient
        {
            get => _recipient;
            set
            {
                Set(nameof(Recipient), ref _recipient, value);
                GenerateCommand.RaiseCanExecuteChanged();
            }
        }

        public string Description
        {
            get => _description;
            set => Set(nameof(Description), ref _description, value);
        }

        public string PaymentType
        {
            get => _paymentType;
            set
            {
                Set(nameof(PaymentType), ref _paymentType, value);
                GenerateCommand.RaiseCanExecuteChanged();
            }
        }

        public string TypeOfPaying
        {
            get => _typeOfPaying;
            set
            {
                Set(nameof(TypeOfPaying), ref _typeOfPaying, value);
                GenerateCommand.RaiseCanExecuteChanged();
            }
        }

        public string QueuePayment
        {
            get => _queuePayment;
            set
            {
                Set(nameof(QueuePayment), ref _queuePayment, value);
                GenerateCommand.RaiseCanExecuteChanged();
            }
        }

        public bool UseOneDate
        {
            get => _useOneDate;
            set
            {
                Set(nameof(UseOneDate), ref _useOneDate, value);
                if (value) SetAllDateToOne();
            }
        }

        public bool AutoTotalText
        {
            get => _autoTotalText;
            set
            {
                Set(nameof(AutoTotalText), ref _autoTotalText, value);
                if (value) ConvertTotalToString();
            }
        }

        public RelayCommand GenerateCommand
        {
            get
            {
                return _generateCommand ?? (_generateCommand = new RelayCommand(() =>
                {
                    var item = new PaymentOrder
                    {
                        Number = NumberOrder,
                        Date = Date,
                        InDate = InDate,
                        OutDate = OutDate,
                        AcceptDate = AcceptDate,
                        Total = Total,
                        TotalText = TotalText,
                        Description = Description,
                        Payer = Payer,
                        Recipient = Recipient,
                        TypeOfPayment = PaymentType,
                        TypeOfPaying = TypeOfPaying,
                        QueuePayment = QueuePayment
                    };

                    Messenger.Default.Send(new NotificationMessage<PaymentOrder>(item, "Add new item to Queue Payment Order"));
                    NavigationService.GoBack();
                }, IsValidInfo));
            }
        }

        private void ConvertTotalToString()
        {
            if (string.IsNullOrWhiteSpace(Total) || string.IsNullOrEmpty(Total))
            {
                TotalText = "Введите сумму";
                return;
            }

            var s = Total.Replace('-', ',');

            TotalText = RuDateAndMoneyConverter.CurrencyToTxt(double.Parse(s), true);
        }

        private void SetAllDateToOne()
        {
            InDate = OutDate = AcceptDate = Date;
        }

        private bool IsValidInfo()
        {
            bool recipient = Recipient != null;
            bool payer = Payer != null;
            bool totalInfo = !string.IsNullOrEmpty(Total) && !string.IsNullOrWhiteSpace(Total) &&
                             !string.IsNullOrEmpty(TotalText) && !string.IsNullOrWhiteSpace(TotalText);
            bool options = !string.IsNullOrEmpty(TypeOfPaying) && !string.IsNullOrWhiteSpace(TypeOfPaying) &&
                           !string.IsNullOrEmpty(PaymentType) && !string.IsNullOrWhiteSpace(PaymentType) &&
                           !string.IsNullOrEmpty(QueuePayment) && !string.IsNullOrWhiteSpace(QueuePayment);
            bool number = NumberOrder > 0;

            return number && totalInfo && payer && recipient && options;
        }
    }
}