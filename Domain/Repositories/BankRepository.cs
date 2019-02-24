using System.Data.Entity;
using Domain.Contexts;
using Domain.Entities;

namespace Domain.Repositories
{
    public class BankRepository : Repositiory<Bank>
    {
        public BankRepository() : base(new OrderContext())
        {
        }
    }
}