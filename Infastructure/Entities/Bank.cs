using System.Collections.Generic;

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

        public Bank() {}

        public Bank(string name, string city, string bik, string accountNumber)
        {
            Name = name;
            City = city;
            Bik = bik;
            AccountNumber = accountNumber;
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
                if (obj is Bank bank)
                {
                    return this.Id == bank.Id &&
                           this.Name == bank.Name &&
                           this.City == bank.City &&
                           this.Bik == bank.Bik &&
                           this.AccountNumber == bank.AccountNumber;
                }
            return false;
        }
    }
}
