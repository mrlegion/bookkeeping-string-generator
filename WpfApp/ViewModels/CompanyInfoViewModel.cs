using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using CommonServiceLocator;
using Domain.Services;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using Infrastructure.Entities;
using MaterialDesignThemes.Wpf;
using WpfApp.Service;
using WpfApp.UserControls.ViewModels;
using WpfApp.UserControls.Views;

namespace WpfApp.ViewModels
{
    public class CompanyInfoViewModel : ViewModelCustom
    {
        #region Fields

        private bool _isLoadData;
        private IEnumerable<Company> _companies;
        private RelayCommand<object> _editItemCommand;
        private RelayCommand<object> _deleteItemCommand;
        private RelayCommand<Company> _viewItemCommand;

        #endregion

        #region Construct

        public CompanyInfoViewModel(IFrameNavigationService navigationService)
            : base(navigationService)
        {
            CompanyInfoInitialize();
        }

        #endregion

        #region Properties

        public bool IsLoadData
        {
            get { return _isLoadData; }
            set { Set(nameof(IsLoadData), ref _isLoadData, value); }
        }


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

        public RelayCommand<Company> ViewItemCommand
        {
            get
            {
                return _viewItemCommand ?? (_viewItemCommand = new RelayCommand<Company>(async (o) =>
                {
                    if (o == null) return;

                    var content = ServiceLocator.Current.GetInstance<CompanyDetailsDialogView>();
                    var model = ServiceLocator.Current.GetInstance<CompanyDetailsDialogViewModel>();
                    model.Company = o;
                    content.DataContext = model;
                    var result = await DialogHost.Show(content, "RootDialogHost");
                    if (result is bool b)
                        if (b) NavigationService.NavigateTo("CompanyEdit", o);
                }));
            }
        }

        #endregion

        #region Private Methods

        private void CompanyInfoInitialize()
        {
            var content = ServiceLocator.Current.GetInstance<LoadDialogView>();
            var model = ServiceLocator.Current.GetInstance<LoadDialogViewModel>();
            model.Message = $"Загрузка данных{Environment.NewLine}Подождите...";
            content.DataContext = model;
            DialogHost.Show(content, "RootDialogHost",
                delegate (object sender, DialogOpenedEventArgs args)
                {
                    ThreadPool.QueueUserWorkItem((o) =>
                    {
                        var service = ServiceLocator.Current.GetInstance<CompanyService>();
                        var list = service.GetAllCompanies();
                        Companies = list;
                        DispatcherHelper.CheckBeginInvokeOnUI(() => { args.Session.Close(false); });
                    });
                });
        }

        #endregion
    }
}