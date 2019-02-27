using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entity
{
    [Table("organization_info")]
    public class Organization : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("account_number")]
        public string AccountNumber { get; set; }

        [Column("company_id")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [Column("bank_id")]
        public int BankId { get; set; }
        public Bank Bank { get; set; }
    }
}
