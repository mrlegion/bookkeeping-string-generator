using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Repository.Interface;
using Infrastructure.Entities;
using Mehdime.DbScope.Interfaces;

namespace Domain.Services
{
    public class CompanyService
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(IDbContextScopeFactory dbContextScopeFactory, ICompanyRepository companyRepository)
        {
            _dbContextScopeFactory = dbContextScopeFactory ?? throw new ArgumentNullException(nameof(dbContextScopeFactory));
            _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
        }

        public void CreateCompany(Company company)
        {
            if (company == null) throw new ArgumentNullException(nameof(company));

            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                _companyRepository.Add(company);
                dbContextScope.SaveChanges();
            }
        }

        public async Task GreateCompanyAsync(Company company)
        {
            if (company == null) throw new ArgumentNullException(nameof(company));

            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                _companyRepository.Add(company);
                await dbContextScope.SaveChangeAsync();
            }
        }

        public Company GetCompany(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var dbContext = dbContextScope.DbContexts.Get<BookkeepingLibraryContext>();
                return dbContext.Companies.Find(id);
            }
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var dbContext = dbContextScope.DbContexts.Get<BookkeepingLibraryContext>();
                return dbContext.Companies.ToList();
            }
        }

        public void UpdateCompany(Company company)
        {
            if (company == null) throw new ArgumentNullException(nameof(company));
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                _companyRepository.Update(company);
                dbContextScope.SaveChanges();
            }
        }

        public async Task UpdateCompanyAsync(Company company)
        {
            if (company == null) throw new ArgumentNullException(nameof(company));
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                _companyRepository.Update(company);
                await dbContextScope.SaveChangeAsync();
            }
        }

        public void DeleteCompany(Company company)
        {
            if (company == null) throw new ArgumentNullException(nameof(company));
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                _companyRepository.Delete(company);
                dbContextScope.SaveChanges();
            }
        }

        public async Task DeleteCompanyAsync(Company company)
        {
            if (company == null) throw new ArgumentNullException(nameof(company));
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                _companyRepository.Delete(company);
                await dbContextScope.SaveChangeAsync();
            }
        }
    }
}