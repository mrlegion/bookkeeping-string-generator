using System.Threading.Tasks;
using Infrastructure.Entities;

namespace DAL.Repository.Interface
{
    public interface IBankRepository
    {
        Bank Get(int id);
        Task<Bank> GetAsync(int id);
        void Add(Bank bank);
        void Update(Bank bank);
    }
}