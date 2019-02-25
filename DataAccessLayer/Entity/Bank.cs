using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entity
{
    public class Bank
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2), MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MinLength(2), MaxLength(255)]
        public string City { get; set; }

        [Required]
        [MaxLength(10)]
        public string Bik { get; set; }

        [Required]
        [MaxLength(20)]
        public string AccountNumber { get; set; }

        public ICollection<Company> Companies { get; set; }
    }
}
