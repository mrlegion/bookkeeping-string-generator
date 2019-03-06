using System.Data.Entity.ModelConfiguration;
using Infrastructure.Entities;

namespace DAL
{
    public class PayFluentMap : EntityTypeConfiguration<PaymentType>
    {
        public PayFluentMap()
        {
            ToTable("payment_type").HasKey(p => p.Id);

            Property(p => p.Id)
                .HasColumnName("type_id");

            Property(p => p.Name)
                .HasColumnName("type_name")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            HasMany(p => p.PaymentOrders)
                .WithRequired(o => o.TypeOfPayment);
        }
    }
}