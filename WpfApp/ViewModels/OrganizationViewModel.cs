﻿using System;
using System.Collections.Generic;
using System.Windows;
using CommonServiceLocator;
using Domain.Services;
using GalaSoft.MvvmLight.Command;
using Infrastructure.Dto;
using Infrastructure.Entities;
using MaterialDesignThemes.Wpf;
using WpfApp.Common;
using WpfApp.Service;
using WpfApp.UserControls.ViewModels;
using WpfApp.UserControls.Views;

namespace WpfApp.ViewModels
{
    public class OrganizationViewModel : ViewModelCustom
    {
        #region Fields

        private IEnumerable<OrganizationSimpleDto> _organizations;
        private RelayCommand<object> _editItemCommand;
        private RelayCommand<object> _deleteItemCommand;
        private RelayCommand<object> _viewItemCommand;

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
                return _deleteItemCommand ?? (_deleteItemCommand = new RelayCommand<object>(async (o) =>
                {
                    if (o != null)
                        if (o is OrganizationSimpleDto organization)
                        {
                            var result = await DialogHelper.ShowQuestenDialog(
                                "Вы точно хотите удалить выбранную организацию?", 
                                PackIconKind.Delete);
                            if (result)
                            {
                                var service = ServiceLocator.Current.GetInstance<OrganizationService>();
                                service.DeleteOrganization(organization);
                                Organizations = service.GetAllSimpleInfo();
                            }
                        }
                }));
            }
        }

        public RelayCommand<object> ViewItemCommand
        {
            get
            {
                return _viewItemCommand ?? (_viewItemCommand = new RelayCommand<object>(async (o) =>
                {
                    if (o is OrganizationSimpleDto dto)
                    {
                        Organization full = ServiceLocator.Current.GetInstance<OrganizationService>().GetOrganization(dto.Id);

                        bool result = await DialogHelper
                            .ViewDetailDialog<OrganizationDetailDialogView, OrganizationDetailDialogViewModel, Organization>(full, "Информация об организации");
                        if (result) NavigationService.NavigateTo("OrganizationEdit", dto);

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