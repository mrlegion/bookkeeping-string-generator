using System.Collections.Generic;
using CommonServiceLocator;
using Domain.Services;
using GalaSoft.MvvmLight;
using Infrastructure.Dto;
using Infrastructure.Entities;
using WpfApp.Service;

namespace WpfApp.ViewModels
{
    /// <summary>
    /// Description this class
    /// </summary>
    public class OrganizationViewModel : ViewModelCustom
    {
        public OrganizationViewModel(IFrameNavigationService navigationService) : base(navigationService)
        {
            var service = ServiceLocator.Current.GetInstance<OrganizationQueryService>();
            Organizations = service.GetAllSimpleInfo();
        }

        private IEnumerable<OrganizationSimpleDto> _organizations;

        public const string OrganizationsPropertyName = "Organizations";

        public IEnumerable<OrganizationSimpleDto> Organizations
        {
            get { return _organizations; }
            set { Set(OrganizationsPropertyName, ref _organizations, value); }
        }
    }
}