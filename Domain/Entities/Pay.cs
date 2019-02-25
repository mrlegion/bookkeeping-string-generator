using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Pay
    {
        public int PayId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}