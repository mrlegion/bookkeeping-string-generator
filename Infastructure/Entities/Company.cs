using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Inn { get; set; }
        public string Kpp { get; set; }

        public ICollection<Organization> Organizations { get; set; }
    }
}
