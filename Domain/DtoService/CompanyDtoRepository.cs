using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Domain.Contexts;
using Domain.DTO;
using Domain.Entities;

namespace Domain.DtoService
{
    public class CompanyDtoRepository : IDtoRepository<CompanyDetailsDto>
    {
        private readonly DbContext _context;

        public CompanyDtoRepository()
        {
            _context = new OrderContext();
        }

        public IEnumerable<CompanyDetailsDto> GetDetails()
        {
            return _context.Set<Company>()
                .Join(_context.Set<Bank>(),
                    company => company.Id,
                    bank => bank.Id,
                    (company, bank) => new CompanyDetailsDto()
                    {
                        CompanyId = company.Id,
                        CompanyName = company.Name,
                        CompanyInn = company.Inn,
                        CompanyKpp = company.Kpp,
                        CompanyAccountNumber = company.AccountNumber,

                        BankId = bank.Id,
                        BankName = bank.Name,
                        BankCity = bank.City,
                        BankBik = bank.Bik,
                        BankAccountNumber = bank.AccountNumber
                    }).ToList();
        }

        public IEnumerable<CompanyDetailsDto> GetSimple()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompanyDetailsDto> GetDetailsWhere(Expression<Func<CompanyDetailsDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompanyDetailsDto> GetSimplesWhere(Expression<Func<CompanyDetailsDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}