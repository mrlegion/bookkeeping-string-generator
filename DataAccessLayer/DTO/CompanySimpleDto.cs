namespace DataAccessLayer.DTO
{
    public class CompanySimpleDto
    {
        public int CompanyId { get; set; }
        public int BankId { get; set; }

        public string CompanyName { get; set; }
        public string CompanyInn { get; set; }
        public string CompanyKpp { get; set; }
        public string CompanyAccountNumber { get; set; }
        public string BankName { get; set; }
    }
}
