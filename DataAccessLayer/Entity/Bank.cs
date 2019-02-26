using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entity
{
    [Table("bank_info")]
    public class Bank
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MinLength(2), MaxLength(255)]
        [Column("bank_name")]
        public string Name { get; set; }
        [Required]
        [MinLength(2), MaxLength(255)]
        [Column("bank_city_name")]
        public string City { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("bank_bik")]
        public string Bik { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("bank_account_number")]
        public string AccountNumber { get; set; }

        public ICollection<Organization> Organizations { get; set; }
    }
}
