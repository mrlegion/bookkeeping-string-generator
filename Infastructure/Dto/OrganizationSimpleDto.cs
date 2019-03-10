namespace Infrastructure.Dto
{
    public class OrganizationSimpleDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int BankId { get; set; }
        public string CompanyName { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }

        public OrganizationSimpleDto()
        {
            
        }

        public OrganizationSimpleDto(int id, int companyId, int bankId, string companyName, string bankName, string accountNumber)
        {
            CompanyId = companyId;
            BankId = bankId;
            CompanyName = companyName;
            BankName = bankName;
            AccountNumber = accountNumber;
        }
    }
}