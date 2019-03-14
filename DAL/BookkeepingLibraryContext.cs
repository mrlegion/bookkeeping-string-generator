using System.Data.Entity;
using System.Reflection;
using Infrastructure.Entities;
using SQLite.CodeFirst;

namespace DAL
{
    public class BookkeepingLibraryContext : DbContext
    {
        public BookkeepingLibraryContext() : base("Default")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteDatabaseInitializer = new SqliteCreateDatabaseIfNotExists<BookkeepingLibraryContext>(modelBuilder);
            Database.SetInitializer(sqliteDatabaseInitializer);

            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(BookkeepingLibraryContext)));
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        // ToDo: it is realy need? Maybe it is need deleted
        //public DbSet<PaymentOrder> PaymentOrders { get; set; }
        //public DbSet<PaymentType> PaymentTypes { get; set; }
    }
}
