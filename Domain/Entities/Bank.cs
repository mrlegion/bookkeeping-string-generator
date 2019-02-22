using System.Collections.Generic;

namespace Domain.Entities
{
    public class Bank : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Bik { get; set; }
        public string AccountNumber { get; set; }
        public ICollection<Company> Companies { get; set; }
    }
}