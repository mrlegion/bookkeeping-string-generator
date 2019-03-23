using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Threading;
using MaterialDesignThemes.Wpf;
using WpfApp.UserControls;
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

        public static async Task<bool> ViewDetailDialog<TView, TModel>(object item)
            where TModel : UserControlViewModelBase
            where TView : UserControl
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var content = ServiceLocator.Current.GetInstance<TView>();
            ((TModel)content.DataContext).Init(item);

            var request = await DialogHost.Show(content, "RootDialogHost");
            if (request is bool result)
                return result;
            return false;
        }

        private static void Init(Action action) => action.Invoke();
    }
}