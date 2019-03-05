﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class PaymentOrder
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }
        public DateTime AcceptDate { get; set; }
        public int Total { get; set; }
        public string TotalText { get; set; }
        public string Description { get; set; }
        public int TypeOfPaymentId { get; set; }
        public PaymentType TypeOfPayment { get; set; }
        public int PayerId { get; set; }
        public Organization Payer { get; set; }
        public int RecipientId { get; set; }
        public Organization Recipient { get; set; }
        public string TypeOfPaying { get; set; }
        public string QueuePayment { get; set; }
    }
}