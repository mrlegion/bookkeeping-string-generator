using GalaSoft.MvvmLight;
using WpfApp.Service;

namespace WpfApp.ViewModels
{
    /// <summary>
    /// Description this class
    /// </summary>
    public class GenerateViewModel : ViewModelCustom
    {
        public GenerateViewModel(IFrameNavigationService navigationService) : base(navigationService)
        {
            Title = "Создание файла";
        }
    }
}