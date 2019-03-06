using System;
using DAL.Repository.Interface;
using Infrastructure.Entities;
using Mehdime.DbScope.Interfaces;

namespace Domain.Services
{
    public class BankCreationService
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IBankRepository _bankRepository;

        public BankCreationService(IDbContextScopeFactory dbContextScopeFactory, IBankRepository bankRepository)
        {
            if (dbContextScopeFactory == null) throw new ArgumentNullException(nameof(dbContextScopeFactory));
            if (bankRepository == null) throw new ArgumentNullException(nameof(bankRepository));

            _dbContextScopeFactory = dbContextScopeFactory;
            _bankRepository = bankRepository;
        }

        public void CreateBank(Bank bank)
        {
            if (bank == null) throw new ArgumentNullException(nameof(bank));

            using (var dbScopeContext = _dbContextScopeFactory.Create())
            {
                _bankRepository.Add(bank);
                dbScopeContext.SaveChanges();
            }
        }
    }
}