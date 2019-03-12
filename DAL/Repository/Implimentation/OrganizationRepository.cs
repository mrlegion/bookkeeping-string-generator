using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repository.Interface;
using Infrastructure.Dto;
using Infrastructure.Entities;
using Mehdime.DbScope.Interfaces;

namespace DAL.Repository.Implimentation
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;

        public BookkeepingLibraryContext DbContext
        {
            get
            {
                var context = _ambientDbContextLocator.Get<BookkeepingLibraryContext>();
                if (context == null)
                    throw new InvalidOperationException("No ambient DbContext of type BookkeepingLibraryContext found. This means that this repository method has been called outside of the scope of a DbContextScope. A repository must only be accessed within the scope of a DbContextScope, which takes care of creating the DbContext instances that the repositories need and making them available as ambient contexts. This is what ensures that, for any given DbContext-derived type, the same instance is used throughout the duration of a business transaction. To fix this issue, use IDbContextScopeFactory in your top-level business logic service method to create a DbContextScope that wraps the entire business transaction that your service method implements. Then access this repository within that scope. Refer to the comments in the IDbContextScope.cs file for more details.");
                return context;
            }
        }

        public OrganizationRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator 
                                       ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
        }

        public Organization Get(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));
            return DbContext.Organizations.Find(id);
        }

        public async Task<Organization> GetAsync(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));
            return await DbContext.Organizations.FindAsync(id);
        }

        public IEnumerable<Organization> GetAll()
        {
            return DbContext.Organizations.ToList();
        }

        public async Task<IEnumerable<Organization>> GetAllAsync()
        {
            return await DbContext.Organizations.ToListAsync();
        }

        public IEnumerable<Organization> GetAll(params int[] ids)
        {
            if (ids.Length == 0) throw new ArgumentNullException(nameof(ids));
            return ids.Select(Get).ToList();
        }

        public IEnumerable<OrganizationSimpleDto> GetAllSimpeInfo()
        {
            return DbContext.Organizations
                .Include(o => o.Company)
                .Include(o => o.Bank)
                .Select(o => new OrganizationSimpleDto()
                {
                    Id = o.Id,
                    CompanyId = o.Company.Id,
                    BankId = o.Bank.Id,
                    CompanyName = o.Company.Name,
                    BankName = o.Bank.Name,
                    AccountNumber = o.AccountNumber
                }).ToList();
        }

        public async Task<IEnumerable<OrganizationSimpleDto>> GetAllSimpeInfoAsync()
        {
            return await DbContext.Organizations
                .Include(o => o.Company)
                .Include(o => o.Bank)
                .Select(o => new OrganizationSimpleDto()
                {
                    Id = o.Id,
                    CompanyId = o.Company.Id,
                    BankId = o.Bank.Id,
                    CompanyName = o.Company.Name,
                    BankName = o.Bank.Name,
                    AccountNumber = o.AccountNumber
                }).ToListAsync();
        }

        public void Add(Organization organization)
        {
            if (organization == null) throw new ArgumentNullException(nameof(organization));
            DbContext.Companies.Attach(organization.Company);
            DbContext.Banks.Attach(organization.Bank);
            DbContext.Organizations.Add(organization);
        }

        public void Update(Organization organization)
        {
            if (organization == null) throw new ArgumentNullException(nameof(organization));
            DbContext.Companies.Attach(organization.Company);
            DbContext.Banks.Attach(organization.Bank);
            DbContext.Entry(organization).State = EntityState.Modified;
        }

        public void Delete(Organization organization)
        {
            if (organization == null) throw new ArgumentNullException(nameof(organization));
            DbContext.Entry(organization).State = EntityState.Deleted;
        }
    }
}