using System.Data.Entity;
using DataAccessLayer.Entity;

namespace DataAccessLayer.Repositories
{
    public class CompanyRepository : Repository<Company>
    {
        public CompanyRepository() : base(new BookkeepingContext())
        {
        }
    }
}
