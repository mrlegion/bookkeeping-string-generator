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
        IEnumerable<Organization> GetAllByCompanyId(int id);
        Task<IEnumerable<Organization>> GetAllAsync();
        IEnumerable<Organization> GetAll(params int[] ids);
        IEnumerable<OrganizationSimpleDto> GetAllSimpeInfo();
        Task<IEnumerable<OrganizationSimpleDto>> GetAllSimpeInfoAsync();
        IEnumerable<OrganizationFullDto> GetAllFullInfo();
        void Add(Organization organization);
        void Update(Organization organization);
        void Delete(Organization organization);
        void Delete(OrganizationSimpleDto organization);
    }
}