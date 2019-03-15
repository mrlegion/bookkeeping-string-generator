﻿using System;
using System.Collections.Generic;
using CommonServiceLocator;
using Domain.Helpers;
using Domain.Model;
using Domain.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Infrastructure.Dto;
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

        private readonly IIntToString _converter;
        private readonly IGenerator _generator;

        private bool _useOneDate;

        private bool _autoTotalText;
        private RelayCommand _generateCommand;

        public GenerateViewModel(IFrameNavigationService navigationService, IIntToString converter, IGenerator generator) : base(navigationService)
        {
            Title = "Создание файла";
            _converter = converter;
            _generator = generator;
            Organizations = ServiceLocator.Current.GetInstance<OrganizationService>().GetOrganizations();
            Date = DateTime.Now;
            SetAllDateToOne();
        }

        public int NumberOrder
        {
            get { return _numberOrder; }
            set { Set(nameof(NumberOrder), ref _numberOrder, value); }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                Set(nameof(Date), ref _date, value);
                if (UseOneDate) SetAllDateToOne();
            }
        }

        public DateTime InDate
        {
            get { return _inDate; }
            set { Set(nameof(InDate), ref _inDate, value); }
        }

        public DateTime OutDate
        {
            get { return _outDate; }
            set { Set(nameof(OutDate), ref _outDate, value); }
        }

        public DateTime AcceptDate
        {
            get { return _acceptDate; }
            set { Set(nameof(AcceptDate), ref _acceptDate, value); }
        }

        public string Total
        {
            get { return _total; }
            set
            {
                Set(nameof(Total), ref _total, value);
                if (AutoTotalText) ConvertTotalToString();
            }
        }

        public string TotalText
        {
            get { return _totalText; }
            set { Set(nameof(TotalText), ref _totalText, value); }
        }

        public IEnumerable<Organization> Organizations
        {
            get { return _organizations; }
            set { Set(nameof(Organizations), ref _organizations, value); }
        }

        public Organization Payer
        {
            get { return _payer; }
            set { Set(nameof(Payer), ref _payer, value); }
        }

        public Organization Recipient
        {
            get { return _recipient; }
            set { Set(nameof(Recipient), ref _recipient, value); }
        }

        public string Description
        {
            get { return _description; }
            set { Set(nameof(Description), ref _description, value); }
        }

        public string PaymentType
        {
            get { return _paymentType; }
            set { Set(nameof(PaymentType), ref _paymentType, value); }
        }

        public string TypeOfPaying
        {
            get { return _typeOfPaying; }
            set { Set(nameof(TypeOfPaying), ref _typeOfPaying, value); }
        }

        public string QueuePayment
        {
            get { return _queuePayment; }
            set { Set(nameof(QueuePayment), ref _queuePayment, value); }
        }

        public bool UseOneDate
        {
            get { return _useOneDate; }
            set
            {
                Set(nameof(UseOneDate), ref _useOneDate, value);
                if (value) SetAllDateToOne();
            }
        }

        public bool AutoTotalText
        {
            get { return _autoTotalText; }
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
                    var item = new PaymentOrder()
                    {
                        Number = this.NumberOrder,
                        Date = this.Date,
                        InDate = this.InDate,
                        OutDate = this.OutDate,
                        AcceptDate = this.AcceptDate,
                        Total = this.Total,
                        TotalText = this.TotalText,
                        Description = this.Description,
                        Payer = this.Payer,
                        Recipient = this.Recipient,
                        TypeOfPayment = this.PaymentType,
                        TypeOfPaying = this.TypeOfPaying,
                        QueuePayment = this.QueuePayment
                    };

                    _generator.OnGenerate(item);
                    NavigationService.GoBack();
                }));
            }
        }

        private void ConvertTotalToString()
        {
            if (string.IsNullOrWhiteSpace(Total) || string.IsNullOrEmpty(Total))
            {
                TotalText = "Введите сумму";
                return;
            }
            TotalText = _converter.NumberToString(Total);
        }

        private void SetAllDateToOne()
        {
            InDate = OutDate = AcceptDate = Date;
        }
    }
}