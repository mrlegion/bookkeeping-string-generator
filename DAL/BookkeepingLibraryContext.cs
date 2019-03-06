using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities;
using SQLite.CodeFirst;

namespace DAL
{
    public class BookkeepingLibraryContext : DbContext
    {
        protected BookkeepingLibraryContext() : base("Default") {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteDatabaseInitializer = new SqliteCreateDatabaseIfNotExists<BookkeepingLibraryContext>(modelBuilder);
            Database.SetInitializer(sqliteDatabaseInitializer);

            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(BookkeepingLibraryContext)));
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<PaymentOrder> PaymentOrders { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
    }
}
