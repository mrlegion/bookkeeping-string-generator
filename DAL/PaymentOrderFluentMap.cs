using System.Data.Entity.ModelConfiguration;
using Infrastructure.Entities;

namespace DAL
{
    public class PaymentOrderFluentMap : EntityTypeConfiguration<PaymentOrder>
    {
        public PaymentOrderFluentMap()
        {
            ToTable("order_info").HasKey(o => o.Id);

            Property(o => o.Id).HasColumnName("order_id");

            Property(o => o.Number)
                .HasColumnName("order_number")
                .HasColumnType("int")
                .IsRequired();

            Property(o => o.Date)
                .HasColumnName("order_date")
                .IsRequired();

            Property(o => o.InDate)
                .HasColumnName("order_in_date")
                .IsRequired();

            Property(o => o.OutDate)
                .HasColumnName("order_out_date")
                .IsRequired();

            Property(o => o.AcceptDate)
                .HasColumnName("order_accept_date")
                .IsRequired();

            Property(o => o.Total)
                .HasColumnName("order_total")
                .HasColumnType("int")
                .IsRequired();

            Property(o => o.TotalText)
                .HasColumnName("order_total_text")
                .HasColumnType("varchar")
                .HasMaxLength(500)
                .IsRequired();

            Property(o => o.Description)
                .HasColumnName("order_description")
                .HasColumnType("varchar")
                .IsRequired();

            Property(o => o.TypeOfPaying)
                .HasColumnName("order_type_of_paying")
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();

            Property(o => o.QueuePayment)
                .HasColumnName("order_queue_payment")
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}