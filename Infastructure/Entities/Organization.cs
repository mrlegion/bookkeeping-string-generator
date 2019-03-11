using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class Organization : IDataErrorInfo
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public Company Company { get; set; }
        public Bank Bank { get; set; }

        public ICollection<PaymentOrder> PayerOrders { get; set; }
        public ICollection<PaymentOrder> RecipientOrders { get; set; }

        public Organization() {}

        public Organization(Company company, Bank bank, string accountNumber)
        {
            Company = company;
            Bank = bank;
            AccountNumber = accountNumber;
        }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case nameof(AccountNumber):
                        if (AccountNumber.Length < 20)
                            error = "Длина номера счёта не может быть пустой или быть меньше двадцати знаков!";
                        break;
                }

                return error;
            }
        }

        public string Error { get { throw new NotImplementedException(); } }
    }
}
