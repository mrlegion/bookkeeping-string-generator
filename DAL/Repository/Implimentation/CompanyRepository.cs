using System;
using System.Threading.Tasks;
using DAL.Repository.Interface;
using Infrastructure.Entities;
using Mehdime.DbScope.Implementations;

namespace DAL.Repository.Implimentation
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AmbientDbContextLocator _ambientDbContextLocator;

        private BookkeepingLibraryContext DbContext
        {
            get
            {
                var context = _ambientDbContextLocator.Get<BookkeepingLibraryContext>();
                if (context == null)
                    throw new InvalidOperationException("No ambient DbContext of type BookkeepingLibraryContext found. This means that this repository method has been called outside of the scope of a DbContextScope. A repository must only be accessed within the scope of a DbContextScope, which takes care of creating the DbContext instances that the repositories need and making them available as ambient contexts. This is what ensures that, for any given DbContext-derived type, the same instance is used throughout the duration of a business transaction. To fix this issue, use IDbContextScopeFactory in your top-level business logic service method to create a DbContextScope that wraps the entire business transaction that your service method implements. Then access this repository within that scope. Refer to the comments in the IDbContextScope.cs file for more details.");
                return context;
            }
        }

        public CompanyRepository(AmbientDbContextLocator ambientDbContextLocator)
        {
            if (ambientDbContextLocator == null) throw new ArgumentNullException(nameof(ambientDbContextLocator));
            _ambientDbContextLocator = ambientDbContextLocator;
        }

        public Company Get(int id)
        {
            return DbContext.Companies.Find(id);
        }

        public async Task<Company> GetAsync(int id)
        {
            return await DbContext.Companies.FindAsync(id);
        }

        public void Add(Company company)
        {
            DbContext.Companies.Add(company);
        }
    }
}