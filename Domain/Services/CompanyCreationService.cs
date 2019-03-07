using System;
using System.Threading.Tasks;
using DAL.Repository.Interface;
using Infrastructure.Entities;
using Mehdime.DbScope.Interfaces;

namespace Domain.Services
{
    public class CompanyCreationService
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly ICompanyRepository _companyRepository;

        public CompanyCreationService(IDbContextScopeFactory dbContextScopeFactory, ICompanyRepository companyRepository)
        {
            if (dbContextScopeFactory == null) throw new ArgumentNullException(nameof(dbContextScopeFactory));
            if (companyRepository == null) throw new ArgumentNullException(nameof(companyRepository));

            _dbContextScopeFactory = dbContextScopeFactory;
            _companyRepository = companyRepository;
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
    }
}