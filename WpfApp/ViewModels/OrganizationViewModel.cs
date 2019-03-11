using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommonServiceLocator;
using Domain.Services;
using GalaSoft.MvvmLight.Command;
using Infrastructure.Dto;
using WpfApp.Service;

namespace WpfApp.ViewModels
{
    public class OrganizationViewModel : ViewModelCustom
    {
        public OrganizationViewModel(IFrameNavigationService navigationService) : base(navigationService)
        {
            Title = "Информация об организациях";
        }

        private IEnumerable<OrganizationSimpleDto> _organizations;

        public const string OrganizationsPropertyName = "Organizations";

        public IEnumerable<OrganizationSimpleDto> Organizations
        {
            get { return _organizations; }
            set { Set(OrganizationsPropertyName, ref _organizations, value); }
        }

        private bool _inProgress;

        public const string InProgressPropertyName = "InProgress";

        public bool InProgress
        {
            get { return _inProgress; }
            set { Set(InProgressPropertyName, ref _inProgress, value); }
        }

        private async void Init()
        {
            InProgress = true;
            Organizations = await ServiceLocator.Current.GetInstance<OrganizationQueryService>().GetAllSimpleInfoAsync().ConfigureAwait(false);
            InProgress = false;
        }

        private RelayCommand _onLoadedCommand;

        public RelayCommand OnLoadedCommand { get { return _onLoadedCommand ?? (_onLoadedCommand = new RelayCommand(Init)); } }
    }
}