using System.Collections.Generic;
using CommonServiceLocator;
using Domain.Services;
using GalaSoft.MvvmLight;
using Infrastructure.Entities;
using WpfApp.Service;

namespace WpfApp.ViewModels
{
    /// <summary>
    /// Description this class
    /// </summary>
    public class BankInfoViewModel : ViewModelCustom
    {
        public BankInfoViewModel(IFrameNavigationService navigationService) : base(navigationService)
        {
            var service = ServiceLocator.Current.GetInstance<BankQueryService>();
            Banks = service.GetAllBanks();
        }

        private IEnumerable<Bank> _banks;

        public const string BanksPropertyName = "Banks";

        public IEnumerable<Bank> Banks
        {
            get { return _banks; }
            set { Set(BanksPropertyName, ref _banks, value); }
        }
    }
}