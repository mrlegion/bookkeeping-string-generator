using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
    }
}
