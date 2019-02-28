using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WpfApp.Service;

namespace WpfApp.ViewModels
{
    /// <summary>
    /// Description this class
    /// </summary>
    public class ShellViewModel : ViewModelCustom
    {
        #region Fields

        #endregion

        #region Ctor
        public ShellViewModel(IFrameNavigationService navigationService) : base(navigationService)
        {
        }
        #endregion

        #region Properties

        #endregion

        #region Commands

        #endregion

        #region Public methods

        #endregion

        #region Private methods

        #endregion

        #region Exceptions

        #endregion

        private RelayCommand _goBackCommand;

        public RelayCommand GoBackCommand
        {
            get
            {
                return _goBackCommand ?? (_goBackCommand = new RelayCommand(() =>
                {
                    NavigationService.GoBack();
                    GoBackCommand.RaiseCanExecuteChanged();
                }, () => NavigationService.CanGoBack));
            }
        }
    }
}