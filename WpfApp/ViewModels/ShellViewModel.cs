using System.Windows;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using WpfApp.Common;
using WpfApp.Service;

namespace WpfApp.ViewModels
{
    /// <summary>
    /// Description this class
    /// </summary>
    public class ShellViewModel : ViewModelCustom
    {
        public ShellViewModel(IFrameNavigationService navigationService) : base(navigationService)
        {
            //Messenger.Default.Register<NotificationMessage<ContentDialogTransfer>>(this, (m) =>
            //{
            //    if (m.Content is ContentDialogTransfer contentDialog)
            //    {
            //        if (!contentDialog.IsOpen)
            //        {
            //            IsOpenDialog = false;
            //            return;
            //        }
            //        var view = contentDialog.Content;
            //        var result = DialogHost.Show(view, "RootDialogHost");
            //    }
            //});
        }
        
        private RelayCommand _onExitCommand;

        public RelayCommand OnExitCommand
        {
            get
            {
                return _onExitCommand ?? (_onExitCommand = new RelayCommand(() => { Application.Current.Shutdown(); }));
            }
        }
    }
}