using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Bank
    {
        public int BankId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Bik { get; set; }
        public string AccountNumber { get; set; }
        public ICollection<Company> Companies { get; set; }
    }
}