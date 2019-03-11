using DAL.Repository.Interface;
using Infrastructure.Entities;
using Mehdime.DbScope.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Dto;

namespace Domain.Services
{
    public class OrganizationQueryService
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationQueryService(IDbContextScopeFactory dbContextScopeFactory, IOrganizationRepository organizationRepository)
        {
            _dbContextScopeFactory = dbContextScopeFactory
                                     ?? throw new ArgumentNullException(nameof(dbContextScopeFactory));
            _organizationRepository = organizationRepository
                                      ?? throw new ArgumentNullException(nameof(organizationRepository));
        }

        public Organization GetOrganization(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));
            using (_dbContextScopeFactory.CreateReadOnly())
            {
                var organization = _organizationRepository.GetOrganization(id);
                if (organization == null)
                    throw new ArgumentException($"Invalid value provided for id: [{id}]. Couldn't find a organization with this ID.");
                return organization;
            }
        }

        public IEnumerable<Organization> GetOrganizations()
        {
            using (_dbContextScopeFactory.CreateReadOnly())
            {
                return _organizationRepository.GetOrganizations();
            }
        }

        public IEnumerable<OrganizationSimpleDto> GetAllSimpleInfo()
        {
            using (_dbContextScopeFactory.CreateReadOnly())
            {
                return _organizationRepository.GetAllSimpeInfo();
            }
        }

        public async Task<IEnumerable<OrganizationSimpleDto>> GetAllSimpleInfoAsync()
        {
            using (_dbContextScopeFactory.CreateReadOnly())
            {
                return await _organizationRepository.GetAllSimpeInfoAsync();
            }
        }
    }
}
