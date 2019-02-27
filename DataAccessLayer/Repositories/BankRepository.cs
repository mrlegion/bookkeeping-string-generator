using DataAccessLayer.Entity;

namespace DataAccessLayer.Repositories
{
    class BankRepository : Repository<Bank>
    {
        public BankRepository() : base(new BookkeepingContext())
        {
            
        }
    }
}
