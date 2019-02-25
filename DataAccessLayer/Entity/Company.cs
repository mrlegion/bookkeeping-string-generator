using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entity
{
    [Table("company_info")]
    public class Company
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MinLength(2), MaxLength(255)]
        [Column("company_name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(12)]
        [Column("company_inn")]
        public string Inn { get; set; }

        [MaxLength(10)]
        [Column("company_kpp")]
        public string Kpp { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
