using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DAL.Repository.Interface;
using Infrastructure.Entities;
using Mehdime.DbScope.Interfaces;

namespace Domain.Services
{
    public class BankQueryService
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IBankRepository _bankRepository;

        public BankQueryService(IDbContextScopeFactory dbContextScopeFactory, IBankRepository bankRepository)
        {
            _dbContextScopeFactory = dbContextScopeFactory ?? throw new ArgumentNullException(nameof(dbContextScopeFactory));
            _bankRepository = bankRepository ?? throw new ArgumentNullException(nameof(bankRepository));
        }

        public Bank GetBank(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            using (var dbScopeContext = _dbContextScopeFactory.CreateReadOnly())
            {
                var dbContext = dbScopeContext.DbContexts.Get<BookkeepingLibraryContext>();
                return dbContext.Banks.Find(id);
            }
        }

        public IEnumerable<Bank> GetAllBanks()
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var dbContext = dbContextScope.DbContexts.Get<BookkeepingLibraryContext>();
                return dbContext.Banks.ToList();
            }
        }
    }
}