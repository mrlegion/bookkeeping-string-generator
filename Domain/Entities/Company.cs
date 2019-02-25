using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Inn { get; set; }
        public string Kpp { get; set; }
        public string AccountNumber { get; set; }
        public Bank BankId { get; set; }
    }
}