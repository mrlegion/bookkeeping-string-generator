namespace Domain.DTO
{
    public class CompanyDetailsDto
    {
        public int CompanyId { get; set; }
        public int BankId { get; set; }

        public string CompanyName { get; set; }
        public string CompanyInn { get; set; }
        public string CompanyKpp { get; set; }
        public string CompanyAccountNumber { get; set; }
        public string BankName { get; set; }
        public string BankCity { get; set; }
        public string BankBik { get; set; }
        public string BankAccountNumber { get; set; }
    }
}