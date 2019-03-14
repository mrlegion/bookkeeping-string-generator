namespace Infrastructure.Dto
{
    public class OrganizationFullDto
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }

        // Info about Company
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyInn { get; set; }
        public string CompanyKpp { get; set; }

        // Info about Bank
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string BankCity { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankBik { get; set; }
    }
}