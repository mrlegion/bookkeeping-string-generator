using System.Data.Entity.ModelConfiguration;
using Infrastructure.Entities;

namespace DAL
{
    public class CompanyFluentMap : EntityTypeConfiguration<Company>
    {
        public CompanyFluentMap()
        {
            ToTable("company_info").HasKey(c => c.Id);

            Property(c => c.Name)
                .HasColumnName("company_name")
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            Property(c => c.Inn)
                .HasColumnName("column_inn")
                .HasColumnType("varchar")
                .HasMaxLength(12)
                .IsRequired();

            Property(c => c.Kpp)
                .HasColumnName("column_kpp")
                .HasColumnType("varchar")
                .HasMaxLength(9)
                .IsRequired();

            HasMany(c => c.Organizations)
                .WithRequired(o => o.Company);
        }
    }
}