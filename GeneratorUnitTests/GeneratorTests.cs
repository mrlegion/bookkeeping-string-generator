using System;
using Domain.Helpers;
using Domain.Model;
using Infrastructure.Entities;
using NUnit.Framework;

namespace GeneratorUnitTests
{
    [TestFixture]
    public class GeneratorTests
    {
        private IGenerator _generator;
        private PaymentOrder _order;
        private string _orderToText = "";

        [SetUp]
        public void SetUp()
        {

            var payer = new Organization(new Company("Company1", "123456789012", "0"),
                new Bank("Bank1", "City1", "123456789", "12345678901234567890"),
                "12345678901234567890");

            var repicient = new Organization(new Company("Company2", "123456789012", "0"),
                new Bank("Bank2", "City2", "123456789", "12345678901234567890"),
                "12345678901234567890");

            var dt = new DateTime(2019, 03, 15);

            _generator = new Generator(new Saver());

            _order = new PaymentOrder()
            {
                Number = 123,
                Date = dt,
                InDate = dt,
                OutDate = dt,
                AcceptDate = dt,
                Total = "3250.48",
                TotalText = RuDateAndMoneyConverter.CurrencyToTxt(Double.Parse("3250,48"), true),
                Description = "Description for test Payment order",
                Payer = payer,
                Recipient = repicient,
                TypeOfPayment = "электронно",
                TypeOfPaying = "01",
                QueuePayment = "5"
            };

            var total = _order.Total.Replace('.', '-');
            total = total.Replace(',', '-');

            // Add info
            _orderToText += $"{_order.Number}\t{_order.Date.ToShortDateString()}\t{_order.InDate.ToShortDateString()}\t{_order.OutDate.ToShortDateString()}\t{_order.AcceptDate.ToShortDateString()}\t";
            _orderToText += $"{total}\t{_order.TotalText}\t{_order.Description}\t";
            _orderToText += $"{_order.TypeOfPayment}\t{_order.TypeOfPaying}\t{_order.QueuePayment}\t";

            // Payer info
            _orderToText += $"{_order.Payer.Company.Name}\t{_order.Payer.Company.Inn}\t{_order.Payer.Company.Kpp}\t";
            _orderToText += $"{_order.Payer.Bank.Name}\t{_order.Payer.Bank.City}\t{_order.Payer.Bank.Bik}\t{_order.Payer.Bank.AccountNumber}\t";
            _orderToText += $"{_order.Payer.AccountNumber}\t";

            // Recipient info
            _orderToText += $"{_order.Recipient.Company.Name}\t{_order.Recipient.Company.Inn}\t{_order.Recipient.Company.Kpp}\t";
            _orderToText += $"{_order.Recipient.Bank.Name}\t{_order.Recipient.Bank.City}\t{_order.Recipient.Bank.Bik}\t{_order.Recipient.Bank.AccountNumber}\t";
            _orderToText += $"{_order.Recipient.AccountNumber}";

        }

        [Test]
        public void GeneratorOnGenerate_Test()
        {
            _generator.OnGenerate(_order);
            Assert.AreEqual(_orderToText, _generator.Line);
        }
    }
}