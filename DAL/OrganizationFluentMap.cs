using System.Data.Entity.ModelConfiguration;
using Infrastructure.Entities;

namespace DAL
{
    public class OrganizationFluentMap : EntityTypeConfiguration<Organization>
    {
        public OrganizationFluentMap()
        {
            
            ToTable("organization_info").HasKey(o => o.Id);

            Property(o => o.AccountNumber)
                .HasColumnName("organization_account_number")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            Property(o => o.Id)
                .HasColumnName("organization_id");

            //HasMany(o => o.PayerOrders).WithRequired(p => p.Payer);
            //HasMany(o => o.RecipientOrders).WithRequired(p => p.Recipient);
        }
    }
}