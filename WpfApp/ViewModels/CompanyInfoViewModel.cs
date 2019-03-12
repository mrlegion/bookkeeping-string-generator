using System.Collections.Generic;
using System.Windows;
using CommonServiceLocator;
using Domain.Services;
using GalaSoft.MvvmLight.Command;
using Infrastructure.Entities;
using WpfApp.Service;

namespace WpfApp.ViewModels
{
    public class CompanyInfoViewModel : ViewModelCustom
    {
        public CompanyInfoViewModel(IFrameNavigationService navigationService)
            : base(navigationService)
        {
            var service = ServiceLocator.Current.GetInstance<CompanyService>();
            Companies = service.GetAllCompanies();
        }

        private IEnumerable<Company> _companies;

        public const string CompaniesPropertyName = "Companies";

        public IEnumerable<Company> Companies
        {
            get { return _companies; }
            set { Set(CompaniesPropertyName, ref _companies, value); }
        }

        private RelayCommand<object> _editItemCommand;

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

        private RelayCommand<object> _deleteItemCommand;

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
    }
}