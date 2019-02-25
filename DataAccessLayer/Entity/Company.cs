using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entity
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2), MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(12)]
        public string Inn { get; set; }

        [MaxLength(10)]
        public string Kpp { get; set; }

        [Required]
        [MaxLength(20)]
        public string AccountNumber { get; set; }

        public Bank BankId { get; set; }
    }
}
