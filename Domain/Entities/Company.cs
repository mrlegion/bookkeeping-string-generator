namespace Domain.Entities
{
    public class Company : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Inn { get; set; }
        public string Kpp { get; set; }
        public string AccountNumber { get; set; }
        public Bank BankId { get; set; }
    }
}