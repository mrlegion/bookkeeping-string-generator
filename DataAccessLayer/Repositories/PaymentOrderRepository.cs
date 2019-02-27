using DataAccessLayer.Entity;

namespace DataAccessLayer.Repositories
{
    public class PaymentOrderRepository : Repository<PaymentOrder>
    {
        public PaymentOrderRepository() : base(new BookkeepingContext())
        {
            
        }
    }
}
