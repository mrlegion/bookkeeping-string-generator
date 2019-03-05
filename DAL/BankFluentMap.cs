using System.Data.Entity.ModelConfiguration;
using Infrastructure.Entities;

namespace DAL
{
    /// <summary>
    /// Description this class
    /// </summary>
    public class BankFluentMap : EntityTypeConfiguration<Bank>
    {
        public BankFluentMap()
        {
            ToTable("bank_info");
            HasKey(bank => bank.Id);
            Property(bank => bank.Name).HasColumnName("bank_name").HasMaxLength(250).IsRequired();
            Property(bank => bank.City).HasColumnName("bank_city").HasMaxLength(100).IsRequired();
            Property(bank => bank.AccountNumber).HasColumnName("bank_account_number").HasMaxLength(20).IsRequired();
        }
    }
}