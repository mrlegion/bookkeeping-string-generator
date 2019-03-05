using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class Bank
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string City { get; set; }
        public string Bik { get; set; }
        public string AccountNumber { get; set; }

        public ICollection<Organization> Organizations { get; set; }
    }
}
