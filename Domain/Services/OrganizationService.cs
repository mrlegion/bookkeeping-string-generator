using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Repository.Interface;
using Infrastructure.Dto;
using Infrastructure.Entities;
using Mehdime.DbScope.Interfaces;

namespace Domain.Services
{
    public class OrganizationService
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IDbContextScopeFactory dbContextScopeFactory, IOrganizationRepository organizationRepository)
        {
            _dbContextScopeFactory = dbContextScopeFactory
                ?? throw new ArgumentNullException(nameof(dbContextScopeFactory));
            _organizationRepository = organizationRepository
                ?? throw new ArgumentNullException(nameof(organizationRepository));
        }

        public void CreateOrganization(Organization organization)
        {
            if (organization == null) throw new ArgumentNullException(nameof(organization));
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                _organizationRepository.Add(organization);
                dbContextScope.SaveChanges();
            }
        }

        public Organization GetOrganization(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));
            using (_dbContextScopeFactory.CreateReadOnly())
            {
                var organization = _organizationRepository.Get(id);
                if (organization == null)
                    throw new ArgumentException($"Invalid value provided for id: [{id}]. Couldn't find a organization with this ID.");
                return organization;
            }
        }

        public IEnumerable<Organization> GetOrganizations()
        {
            using (_dbContextScopeFactory.CreateReadOnly())
            {
                return _organizationRepository.GetAll();
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

        public void UpdateOrganization(Organization organization)
        {
            if (organization == null) throw new ArgumentNullException(nameof(organization));
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                _organizationRepository.Update(organization);
                dbContextScope.SaveChanges();
            }
        }

        public async Task UpdateOrganizationAsync(Organization organization)
        {
            if (organization == null) throw new ArgumentNullException(nameof(organization));
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                _organizationRepository.Update(organization);
                await dbContextScope.SaveChangeAsync();
            }
        }

        public void DeleteOrganization(Organization organization)
        {
            if (organization == null) throw new ArgumentNullException(nameof(organization));
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                _organizationRepository.Delete(organization);
                dbContextScope.SaveChanges();
            }
        }

        public void DeleteOrganization(OrganizationSimpleDto organization)
        {
            if (organization == null) throw new ArgumentNullException(nameof(organization));
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                _organizationRepository.Delete(organization);
                dbContextScope.SaveChanges();
            }
        }

        public async Task DeleteOrganizationAsync(Organization organization)
        {
            if (organization == null) throw new ArgumentNullException(nameof(organization));
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                _organizationRepository.Delete(organization);
                await dbContextScope.SaveChangeAsync();
            }
        }
    }
}