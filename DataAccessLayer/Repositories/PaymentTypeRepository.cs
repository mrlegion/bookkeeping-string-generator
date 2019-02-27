using DataAccessLayer.Entity;

namespace DataAccessLayer.Repositories
{
    public class PaymentTypeRepository : Repository<PaymentType>
    {
        public PaymentTypeRepository() : base(new BookkeepingContext())
        {
            
        }
    }
}
