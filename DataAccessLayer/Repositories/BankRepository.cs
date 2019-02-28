using DataAccessLayer.Entity;

namespace DataAccessLayer.Repositories
{
    public class BankRepository : Repository<Bank>
    {
        public BankRepository() : base(new BookkeepingContext())
        {
            
        }
    }
}
