using System;
using System.Collections.Generic;
using System.Linq;
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
            _dbContextScopeFactory = dbContextScopeFactory 
                                     ?? throw new ArgumentNullException(nameof(dbContextScopeFactory));
            _bankRepository = bankRepository 
                              ?? throw new ArgumentNullException(nameof(bankRepository));
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

        public void CreateManyBank(IEnumerable<Bank> banks)
        {
            if (banks == null) throw new ArgumentNullException(nameof(banks));
            if (!banks.Any()) throw new ArgumentException(nameof(banks));

            using (var dbScopeContext = _dbContextScopeFactory.Create())
            {
                foreach (Bank bank in banks)
                    _bankRepository.Add(bank);
                dbScopeContext.SaveChanges();
            }
        }
    }
}