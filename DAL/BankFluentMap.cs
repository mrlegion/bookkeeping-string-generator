using System.ComponentModel.DataAnnotations.Schema;
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
            ToTable("bank_info").HasKey(bank => bank.Id);

            Property(bank => bank.Id)
                .HasColumnName("bank_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(bank => bank.Name)
                .HasColumnName("bank_name")
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

            Property(bank => bank.City)
                .HasColumnName("bank_city")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(bank => bank.AccountNumber)
                .HasColumnName("bank_account_number")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            Property(bank => bank.Bik)
                .HasColumnName("bank_bik")
                .HasColumnType("varchar")
                .HasMaxLength(9)
                .IsRequired();

            HasMany(b => b.Organizations)
                .WithRequired(o => o.Bank);
        }
    }
}