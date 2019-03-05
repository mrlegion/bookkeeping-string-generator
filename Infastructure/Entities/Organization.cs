using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class Organization
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int BankId { get; set; }
        public Bank Bank { get; set; }
    }
}
