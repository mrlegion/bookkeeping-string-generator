using System;
using System.Collections.Generic;
using System.Threading;

using CommonServiceLocator;

using Domain.Services;

using Infrastructure.Entities;

namespace WpfApp.UserControls.ViewModels
{
    public class CompanyDetailsDialogViewModel : UserControlViewModelBase<Company>
    {
        private IEnumerable<Organization> _organizations;

        public IEnumerable<Organization> Organizations
        {
            get { return _organizations; }
            set { Set(nameof(Organizations), ref _organizations, value); }
        }

        public override void Init(Company entity)
        {
            Entity = entity ?? throw new ArgumentNullException(nameof(entity));

            ThreadPool.QueueUserWorkItem((o) =>
            {
                var service = ServiceLocator.Current.GetInstance<OrganizationService>();
                Organizations = service.GetOrganizationByCompanyId(Entity.Id);
            });
        }
    }
}