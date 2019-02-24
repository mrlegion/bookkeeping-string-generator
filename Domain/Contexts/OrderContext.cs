using System.Data.Entity;
using Domain.Entities;

namespace Domain.Contexts
{
    public class OrderContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Pay> Pays { get; set; }
        public DbSet<Date> Dates { get; set; }
        public DbSet<BuyOrder> BuyOrders { get; set; }
    }
}