using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CommonServiceLocator;
using Domain.Services;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using Infrastructure.Entities;
using MaterialDesignThemes.Wpf;
using WpfApp.Common;
using WpfApp.Service;
using WpfApp.UserControls;
using WpfApp.UserControls.ViewModels;
using WpfApp.UserControls.Views;

namespace WpfApp.ViewModels
{
    public class CompanyInfoViewModel : ViewModelCustom
    {
        #region Fields

        private IEnumerable<Company> _companies;
        private RelayCommand<object> _editItemCommand;
        private RelayCommand<object> _deleteItemCommand;
        private RelayCommand<object> _viewItemCommand;

        #endregion

        #region Construct

        public CompanyInfoViewModel(IFrameNavigationService navigationService)
            : base(navigationService)
        {
            CompanyInfoInitialize();
        }

        #endregion

        #region Properties
        
        public IEnumerable<Company> Companies
        {
            get { return _companies; }
            set { Set(nameof(Companies), ref _companies, value); }
        }

        public RelayCommand<object> EditItemCommand
        {
            get
            {
                return _editItemCommand ?? (_editItemCommand = new RelayCommand<object>((o) =>
                {
                    if (o != null)
                        if (o is Company company)
                            NavigationService.NavigateTo("CompanyEdit", company);
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
                        if (o is Company company)
                        {
                            // Todo: Использовать MaterialDesign DialogHost
                            var result = MessageBox.Show($"Вы точно хотите удалить выбранный банк: {company.Name}?",
                                "Подтверждение на удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (result != MessageBoxResult.Yes) return;
                            var service = ServiceLocator.Current.GetInstance<CompanyService>();
                            service.DeleteCompany(company);
                            Companies = service.GetAllCompanies();
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
                    if (o is Company company)
                    {
                        var result =
                            await DialogHelper.ViewDetailDialog<CompanyDetailsDialogView, CompanyDetailsDialogViewModel, Company>(company, "Информация о компании");
                        if (result) NavigationService.NavigateTo("CompanyEdit", o);
                    }
                }));
            }
        }

        #endregion

        #region Private Methods

        private void CompanyInfoInitialize()
        {
            DialogHelper.ShowLoadDialog(() =>
            {
                var service = ServiceLocator.Current.GetInstance<CompanyService>();
                var list = service.GetAllCompanies();
                Companies = list;
            }, $"Загрузка данных{Environment.NewLine}Подождите...");
        }

        #endregion
    }
}