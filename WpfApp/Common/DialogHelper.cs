using System;
using System.Threading;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Threading;
using MaterialDesignThemes.Wpf;
using WpfApp.UserControls.ViewModels;
using WpfApp.UserControls.Views;

namespace WpfApp.Common
{
    public class DialogHelper
    {
        public static void ShowLoadDialog(Action callback, string message)
        {
            var content = ServiceLocator.Current.GetInstance<LoadDialogView>();
            ((LoadDialogViewModel)content.DataContext).Message = message;

            DialogHost.Show(content, "RootDialogHost",
                delegate (object sender, DialogOpenedEventArgs args)
                {
                    ThreadPool.QueueUserWorkItem(o =>
                    {
                        Init(callback);
                        DispatcherHelper.CheckBeginInvokeOnUI(() => args.Session.Close(false));
                    });
                });
        }

        private static void Init(Action action) => action.Invoke();
    }
}