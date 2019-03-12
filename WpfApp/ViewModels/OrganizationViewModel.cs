using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using CommonServiceLocator;
using Domain.Services;
using GalaSoft.MvvmLight.Command;
using Infrastructure.Dto;
using Infrastructure.Entities;
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
            Organizations = await ServiceLocator.Current.GetInstance<OrganizationService>().GetAllSimpleInfoAsync().ConfigureAwait(false);
            InProgress = false;
        }

        private RelayCommand<object> _editItemCommand;

        public RelayCommand<object> EditItemCommand
        {
            get
            {
                return _editItemCommand ?? (_editItemCommand = new RelayCommand<object>((o) =>
                {
                    if (o != null)
                        if (o is OrganizationSimpleDto dto)
                            NavigationService.NavigateTo("OrganizationEdit", dto);
                }));
            }
        }

        private RelayCommand _onLoadedCommand;

        public RelayCommand OnLoadedCommand
        {
            get
            {
                return _onLoadedCommand ?? (_onLoadedCommand = new RelayCommand(Init));
            }
        }

        private RelayCommand<object> _deleteItemCommand;

        public RelayCommand<object> DeleteItemCommand
        {
            get
            {
                return _deleteItemCommand ?? (_deleteItemCommand = new RelayCommand<object>((o) =>
                {
                    if (o != null)
                        if (o is OrganizationSimpleDto organization)
                        {
                            // Todo: Использовать MaterialDesign DialogHost
                            var result = MessageBox.Show($"Вы точно хотите удалить выбранную организацию?",
                                "Подтверждение на удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (result != MessageBoxResult.Yes) return;
                            var service = ServiceLocator.Current.GetInstance<OrganizationService>();
                            service.DeleteOrganization(organization);
                            Organizations = service.GetAllSimpleInfo();
                        }
                }));
            }
        }
    }
}