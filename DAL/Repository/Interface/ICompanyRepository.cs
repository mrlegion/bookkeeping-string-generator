using System.Threading.Tasks;
using Infrastructure.Entities;

namespace DAL.Repository.Interface
{
    public interface ICompanyRepository
    {
        Company Get(int id);
        Task<Company> GetAsync(int id);
        void Add(Company company);
    }
}