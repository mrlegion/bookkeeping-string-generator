using GalaSoft.MvvmLight;
using MaterialDesignThemes.Wpf;
using WpfApp.Service;

namespace WpfApp.ViewModels
{
    public class AdministrationViewModel : ViewModelCustom
    {
        public AdministrationViewModel(IFrameNavigationService navigationService) : base(navigationService)
        {
        }
    }
}