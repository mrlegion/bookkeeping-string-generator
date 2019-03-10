using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WpfApp.Service;

namespace WpfApp.ViewModels
{
    /// <summary>
    /// Description this class
    /// </summary>
    public class ViewModelCustom : ViewModelBase
    {
        protected readonly IFrameNavigationService NavigationService;

        public ViewModelCustom(IFrameNavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        private RelayCommand<string> _navigateToCommand;

        public RelayCommand<string> NavigateToCommand
        {
            get
            {
                return _navigateToCommand ?? (_navigateToCommand = new RelayCommand<string>((page) =>
                {
                    if (string.IsNullOrEmpty(page)) return;
                    NavigationService.NavigateTo(page);
                }));
            }
        }

        private RelayCommand _goBackCommand;

        public RelayCommand GoBackCommand
        {
            get
            {
                return _goBackCommand ?? (_goBackCommand = new RelayCommand(() =>
                {
                    NavigationService.GoBack();
                }));
            }
        }
    }
}