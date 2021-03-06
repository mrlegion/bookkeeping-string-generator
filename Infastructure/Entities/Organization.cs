﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class Organization
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public Company Company { get; set; }
        public Bank Bank { get; set; }

        public Organization() {}

        public Organization(Company company, Bank bank, string accountNumber)
        {
            Company = company;
            Bank = bank;
            AccountNumber = accountNumber;
        }

        public override bool Equals(object obj)
        {
            if (obj is Organization o)
                return Id == o.Id &&
                       AccountNumber == o.AccountNumber &&
                       Company.Equals(o.Company) &&
                       Bank.Equals(o.Bank);
            return false;
        }

        public override string ToString()
        {
            return $"{Company.Name} | {Bank.Name} | {AccountNumber}";
        }
    }
}
