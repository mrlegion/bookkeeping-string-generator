﻿using System.Data.Entity;
using DataAccessLayer.Entity;
using SQLite.CodeFirst;

namespace DataAccessLayer
{
    public class BookkeepingContext : DbContext
    {
        public BookkeepingContext() : base("Default")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteDatabaseInitializer = new SqliteCreateDatabaseIfNotExists<BookkeepingContext>(modelBuilder);
            Database.SetInitializer(sqliteDatabaseInitializer);
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
