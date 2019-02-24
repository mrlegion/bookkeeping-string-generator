using Domain.Contexts;
using Domain.Entities;

namespace Domain.Repositories
{
    public class CompanyRepository : Repositiory<Company>
    {
        public CompanyRepository()
            : base(new OrderContext())
        {
            
        }
    }
}