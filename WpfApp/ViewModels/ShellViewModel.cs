using System;
using System.Windows;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Command;
using WpfApp.Service;
using WpfApp.Views;

namespace WpfApp.ViewModels
{
    /// <summary>
    /// Description this class
    /// </summary>
    public class ShellViewModel : ViewModelCustom
    {
        #region Fields

        private RelayCommand _onExitCommand;

        private RelayCommand<Window> _openSettingCommand;

        #endregion

        #region Construct

        public ShellViewModel(IFrameNavigationService navigationService) : base(navigationService)
        {
            Title = "Программа управления Бухгалтерией";
        }

        #endregion

        #region Properties

        public RelayCommand OnExitCommand
        {
            get
            {
                return _onExitCommand ?? (_onExitCommand = new RelayCommand(() => { Application.Current.Shutdown(); }));
            }
        }

        public RelayCommand<Window> OpenSettingCommand
        {
            get
            {
                return _openSettingCommand ?? (_openSettingCommand = new RelayCommand<Window>((w) =>
                {
                    if (w == null) throw new ArgumentNullException(nameof(w));

                    var setting = ServiceLocator.Current.GetInstance<SettingWindow>();
                    setting.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    setting.Owner = w;

                    setting.ShowDialog();
                }));
            }
        }

        #endregion
    }
}