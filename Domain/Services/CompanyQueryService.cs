﻿using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DAL.Repository.Interface;
using Infrastructure.Entities;
using Mehdime.DbScope.Interfaces;

namespace Domain.Services
{
    public class CompanyQueryService
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly ICompanyRepository _companyRepository;

        public CompanyQueryService(IDbContextScopeFactory dbContextScopeFactory, ICompanyRepository companyRepository)
        {
            _dbContextScopeFactory = dbContextScopeFactory ?? throw new ArgumentNullException(nameof(dbContextScopeFactory));
            _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
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
    }
}