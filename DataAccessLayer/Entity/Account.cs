using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entity
{
    [Table("company_account_bank")]
    public class Account
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("account_number")]
        public string AccountNumber { get; set; }

        [Column("company_id")]
        public int CompanyId { get; set; }

        [Column("company")]
        public Company Company { get; set; }

        [Column("bank_id")]
        public int BankId { get; set; }

        [Column("bank")]
        public Bank Bank { get; set; }
    }
}
