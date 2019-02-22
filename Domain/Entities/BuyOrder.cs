namespace Domain.Entities
{
    public class BuyOrder : IEntity
    {
        public int Id { get; set; }
        public Date Date { get; set; }
        public int Number { get; set; }
        public Pay PayType { get; set; }
        public decimal Sum { get; set; }
        public string SumText { get; set; }
        public Company Payer { get; set; }
        public Company Recipient { get; set; }
        public string Description { get; set; }
    }
}