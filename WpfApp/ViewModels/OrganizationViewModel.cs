using System.Collections.Generic;
using System.Threading;
using System.Windows;
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

            ThreadPool.QueueUserWorkItem(o =>
            {
                IsLoadData = true;
                var service = ServiceLocator.Current.GetInstance<OrganizationService>();
                var list = service.GetAllSimpleInfoAsync().Result;
                Organizations = list;
                IsLoadData = false;
            });

        }

        private bool _isLoadData;

        public bool IsLoadData
        {
            get { return _isLoadData; }
            set { Set(nameof(IsLoadData), ref _isLoadData, value); }
        }

        private IEnumerable<OrganizationSimpleDto> _organizations;

        public const string OrganizationsPropertyName = "Organizations";

        public IEnumerable<OrganizationSimpleDto> Organizations
        {
            get { return _organizations; }
            set { Set(OrganizationsPropertyName, ref _organizations, value); }
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