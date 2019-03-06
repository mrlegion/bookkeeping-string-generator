using GalaSoft.MvvmLight;
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
        }
    }
}