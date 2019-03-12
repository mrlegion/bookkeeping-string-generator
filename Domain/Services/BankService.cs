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
    public class BankService
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IBankRepository _bankRepository;

        public BankService(IDbContextScopeFactory dbContextScopeFactory, IBankRepository bankRepository)
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

        public void UpdateBank(Bank bank)
        {
            if (bank == null) throw new ArgumentNullException(nameof(bank));
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                _bankRepository.Update(bank);
                dbContextScope.SaveChanges();
            }
        }

        public async Task UpdateBankAsync(Bank bank)
        {
            if (bank == null) throw new ArgumentNullException(nameof(bank));
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                _bankRepository.Update(bank);
                await dbContextScope.SaveChangeAsync();
            }
        }

        public void DeleteBank(Bank bank)
        {
            if (bank == null) throw new ArgumentNullException(nameof(bank));
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                _bankRepository.Delete(bank);
                dbContextScope.SaveChanges();
            }
        }

        public async Task DeleteBankAsync(Bank bank)
        {
            if (bank == null) throw new ArgumentNullException(nameof(bank));
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                _bankRepository.Delete(bank);
                await dbContextScope.SaveChangeAsync();
            }
        }
    }
}