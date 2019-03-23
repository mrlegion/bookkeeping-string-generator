using System;
using System.Collections.Generic;
using System.Windows;
using CommonServiceLocator;
using Domain.Services;
using GalaSoft.MvvmLight.Command;
using Infrastructure.Dto;
using WpfApp.Common;
using WpfApp.Service;

namespace WpfApp.ViewModels
{
    public class OrganizationViewModel : ViewModelCustom
    {
        #region Fields

        private IEnumerable<OrganizationSimpleDto> _organizations;
        private RelayCommand<object> _editItemCommand;
        private RelayCommand<object> _deleteItemCommand;

        #endregion

        #region Construct

        public OrganizationViewModel(IFrameNavigationService navigationService) : base(navigationService)
        {
            Title = "Информация об организациях";

            OrganizationInitialize();
        }

        #endregion

        #region Properties

        public IEnumerable<OrganizationSimpleDto> Organizations
        {
            get { return _organizations; }
            set { Set(nameof(Organizations), ref _organizations, value); }
        }

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

        #endregion

        #region Private Methods

        private void OrganizationInitialize()
        {
            DialogHelper.ShowLoadDialog(() =>
            {
                var service = ServiceLocator.Current.GetInstance<OrganizationService>();
                var list = service.GetAllSimpleInfoAsync().Result;
                Organizations = list;
            }, $"Загрузка данных{Environment.NewLine}Подождите...");
        }

        #endregion
    }
}