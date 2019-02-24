using System.Data.Entity;
using Domain.Contexts;
using Domain.Entities;

namespace Domain.Repositories
{
    public class BuyOrderRepository : Repositiory<BuyOrder>
    {
        public BuyOrderRepository() 
            : base(new OrderContext())
        {
        }
    }
}