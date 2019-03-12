using Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Dto;

namespace DAL.Repository.Interface
{
    public interface IOrganizationRepository
    {
        Organization Get(int id);
        Task<Organization> GetAsync(int id);
        IEnumerable<Organization> GetAll();
        Task<IEnumerable<Organization>> GetAllAsync();
        IEnumerable<Organization> GetAll(params int[] ids);
        IEnumerable<OrganizationSimpleDto> GetAllSimpeInfo();
        Task<IEnumerable<OrganizationSimpleDto>> GetAllSimpeInfoAsync();
        void Add(Organization organization);
        void Update(Organization organization);
    }
}