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
    }
}
