using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CommonServiceLocator;
using Domain.Helpers;
using Domain.Model;
using Domain.Services;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Infrastructure.Entities;
using WpfApp.Common;
using WpfApp.Service;

using Configuration = WpfApp.Properties.Settings;

namespace WpfApp.ViewModels
{
    public class GenerateViewModel : ViewModelCustom
    {
        #region Fields

        private int _number;
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
        private string _typeOfPayment;
        private string _typeOfPaying;
        private string _queuePayment;
        private readonly IGenerator _generator;
        private bool _useOneDate;
        private bool _autoTotalText;
        private RelayCommand _generateCommand;
        private char _moneySeparate;
        private bool _isEditableItem;
        private PaymentOrder _order;
 
        #endregion

        #region Construct

        public GenerateViewModel(IFrameNavigationService navigationService, IGenerator generator) : base(
            navigationService)
        {
            Title = "Создание файла";
            _generator = generator;
            Date = Configuration.Default.DefaultDate;
            SetAllDateToOne();

            AutoTotalText = Configuration.Default.TotalToString;
            UseOneDate = Configuration.Default.IsOneDate;
            TypeOfPaying = Configuration.Default.TypeOfPaying;
            TypeOfPayment = Configuration.Default.TypeOfPayment;
            QueuePayment = Configuration.Default.QueuePayment;

            _moneySeparate = Configuration.Default.MoneySeparator;

            GenerateInitialize();

            if (NavigationService.Parameter != null)
                if (NavigationService.Parameter is PaymentOrder order)
                    FillAllInformation(order);
        }

        #endregion

        #region Properties

        public int Number
        {
            get => _number;
            set
            {
                Set(nameof(Number), ref _number, value);
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
                value = Regex.Replace(value, "\\.|,|-", _moneySeparate.ToString());

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

        public string TypeOfPayment
        {
            get => _typeOfPayment;
            set
            {
                Set(nameof(TypeOfPayment), ref _typeOfPayment, value);
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

        public bool IsEditableItem
        {
            get => _isEditableItem;
            set
            {
                Set(nameof(IsEditableItem), ref _isEditableItem, value);
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
                    string message = "Add";
                    if (_isEditableItem)
                    {
                        message = "Edit";
                        // _order.Number = Number;
                        _order.Date = Date;
                        _order.InDate = InDate;
                        _order.OutDate = OutDate;
                        _order.AcceptDate = AcceptDate;
                        _order.Total = Total;
                        _order.TotalText = TotalText;
                        _order.Description = Description;
                        _order.Payer = Payer;
                        _order.Recipient = Recipient;
                        _order.TypeOfPayment = TypeOfPayment;
                        _order.TypeOfPaying = TypeOfPaying;
                        _order.QueuePayment = QueuePayment;
                    }
                    else
                        _order = new PaymentOrder
                        {
                            Number = Number,
                            Date = Date,
                            InDate = InDate,
                            OutDate = OutDate,
                            AcceptDate = AcceptDate,
                            Total = Total,
                            TotalText = TotalText,
                            Description = Description,
                            Payer = Payer,
                            Recipient = Recipient,
                            TypeOfPayment = TypeOfPayment,
                            TypeOfPaying = TypeOfPaying,
                            QueuePayment = QueuePayment
                        };

                    Messenger.Default.Send(new NotificationMessage<PaymentOrder>(_order, message));
                    NavigationService.GoBack();
                }, IsValidInfo));
            }
        }

        #endregion

        #region Public Methods

        private void FillAllInformation(PaymentOrder order)
        {
            _order = order;
            Number = _order.Number;
            Date = _order.Date;
            InDate = _order.InDate;
            OutDate = _order.OutDate;
            AcceptDate = _order.AcceptDate;
            Total = _order.Total;
            TotalText = _order.TotalText;
            Description = _order.Description;
            Payer = _order.Payer;
            Recipient = _order.Recipient;
            TypeOfPaying = _order.TypeOfPaying;
            TypeOfPayment = _order.TypeOfPayment;
            QueuePayment = _order.QueuePayment;
            IsEditableItem = true;
        }

        private void ConvertTotalToString()
        {
            if (string.IsNullOrWhiteSpace(Total) || string.IsNullOrEmpty(Total))
            {
                TotalText = "Введите сумму";
                return;
            }

            var s = Total.Replace(_moneySeparate, ',');

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
                           !string.IsNullOrEmpty(TypeOfPayment) && !string.IsNullOrWhiteSpace(TypeOfPayment) &&
                           !string.IsNullOrEmpty(QueuePayment) && !string.IsNullOrWhiteSpace(QueuePayment);
            bool number = Number > 0;

            return number && totalInfo && payer && recipient && options;
        }

        private void GenerateInitialize()
        {
            DialogHelper.ShowLoadDialog(() =>
            {
                var service = ServiceLocator.Current.GetInstance<OrganizationService>();
                var list = service.GetOrganizationAsync().Result;
                Organizations = list;
            }, $"Загрузка данных{Environment.NewLine}Подождите...");
        }

        #endregion
    }
}