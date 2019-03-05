using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
