using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entity
{
    [Table("pay_type")]
    public class Pay
    {
        [Key]
        [Column("pay_id")]
        public int Id { get; set; }

        [Required]
        [MinLength(1), MaxLength(50)]
        [Column("pay_name")]
        public string Name { get; set; }
    }
}
