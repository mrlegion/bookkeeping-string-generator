using System;
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
            if (dbContextScopeFactory == null) throw new ArgumentNullException(nameof(dbContextScopeFactory));
            if (bankRepository == null) throw new ArgumentNullException(nameof(bankRepository));

            _dbContextScopeFactory = dbContextScopeFactory;
            _bankRepository = bankRepository;
        }

        //public Bank GetBank(int id)
        //{
        //    using (var dbScopeContext = _dbContextScopeFactory.CreateReadOnly())
        //    {
        //        var dbContext = dbScopeContext.DbContexts.Get<BookkeepingLibraryContext>();
        //    }
        //}
    }
}