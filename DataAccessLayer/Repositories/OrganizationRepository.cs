using DataAccessLayer.Entity;

namespace DataAccessLayer.Repositories
{
    public class OrganizationRepository : Repository<Organization>
    {
        public OrganizationRepository() : base(new BookkeepingContext())
        {
            
        }
    }
}
