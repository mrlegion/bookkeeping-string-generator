using System;
using System.Collections.Generic;
using System.Threading;
using CommonServiceLocator;
using Domain.Services;
using Infrastructure.Entities;

namespace WpfApp.UserControls.ViewModels
{
    public class BankDetailDialogViewModel : UserControlViewModelBase<Bank>
    {
        #region Fields

        private IEnumerable<Organization> _organizations;

        #endregion

        #region Properties
        
        public IEnumerable<Organization> Organizations
        {
            get { return _organizations; }
            set { Set(nameof(Organizations), ref _organizations, value); }
        }

        #endregion

        #region Public Methods

        public override void Init(Bank entity)
        {
            Entity = entity ?? throw new ArgumentNullException(nameof(entity));

            ThreadPool.QueueUserWorkItem(o =>
            {
                var service = ServiceLocator.Current.GetInstance<OrganizationService>();
                Organizations = service.GetOrganizationByBankId(Entity.Id);
            });
        }

        #endregion
    }
}