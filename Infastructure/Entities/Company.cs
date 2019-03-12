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

        public Company() {}

        public Company(string name, string inn, string kpp)
        {
            Name = name;
            Inn = inn;
            Kpp = kpp;
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
                if (obj is Company company)
                {
                    return this.Id == company.Id &&
                           this.Name == company.Name &&
                           this.Inn == company.Inn &&
                           this.Kpp == company.Kpp;
                }

            return false;
        }
    }
}
