using Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Dto;

namespace DAL.Repository.Interface
{
    public interface IOrganizationRepository
    {
        Organization GetOrganization(int id);
        Task<Organization> GetOrganizationAsync(int id);
        IEnumerable<Organization> GetOrganizations();
        Task<IEnumerable<Organization>> GetOrganizationsAsync();
        IEnumerable<Organization> GetOrganizations(params int[] ids);
        IEnumerable<OrganizationSimpleDto> GetAllSimpeInfo();
        Task<IEnumerable<OrganizationSimpleDto>> GetAllSimpeInfoAsync();
        void AddOrganization(Organization organization);
    }
}