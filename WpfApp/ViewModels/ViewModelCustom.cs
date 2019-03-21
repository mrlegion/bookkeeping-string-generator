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
        private string _title;

        public const string TitlePropertyName = "Title";

        public string Title
        {
            get { return _title; }
            set { Set(TitlePropertyName, ref _title, value); }
        }

        protected readonly IFrameNavigationService NavigationService;

        public ViewModelCustom(IFrameNavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        private bool _isOpenDialog;

        public bool IsOpenDialog
        {
            get { return _isOpenDialog; }
            set { Set(nameof(IsOpenDialog), ref _isOpenDialog, value); }
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