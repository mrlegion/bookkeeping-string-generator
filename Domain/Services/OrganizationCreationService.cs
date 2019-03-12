using System;
using DAL.Repository.Interface;
using Infrastructure.Entities;
using Mehdime.DbScope.Interfaces;

namespace Domain.Services
{
    public class OrganizationCreationService
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationCreationService(IDbContextScopeFactory dbContextScopeFactory, IOrganizationRepository organizationRepository)
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
    }
}