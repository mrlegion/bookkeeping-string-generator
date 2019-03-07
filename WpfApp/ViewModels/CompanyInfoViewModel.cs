using System.Collections.Generic;
using CommonServiceLocator;
using Domain.Services;
using GalaSoft.MvvmLight;
using Infrastructure.Entities;
using WpfApp.Service;

namespace WpfApp.ViewModels
{
    public class CompanyInfoViewModel : ViewModelCustom
    {
        public CompanyInfoViewModel(IFrameNavigationService navigationService)
            : base(navigationService)
        {
            var service = ServiceLocator.Current.GetInstance<CompanyQueryService>();
            Companies = service.GetAllCompanies();
        }

        private IEnumerable<Company> _companies;

        public const string CompaniesPropertyName = "Companies";

        public IEnumerable<Company> Companies
        {
            get { return _companies; }
            set { Set(CompaniesPropertyName, ref _companies, value); }
        }
    }
}