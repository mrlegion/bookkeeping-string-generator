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

            DialogHost.Show(content, Properties.Settings.Default.Indentifier,
                delegate (object sender, DialogOpenedEventArgs args)
                {
                    ThreadPool.QueueUserWorkItem(o =>
                    {
                        callback.Invoke();
                        DispatcherHelper.CheckBeginInvokeOnUI(() => args.Session.Close(false));
                    });
                });
        }

        public static async void ShowInformerDialog(string message, PackIconKind icon)
        {
            var content = ServiceLocator.Current.GetInstance<DialogView>();
            ((DialogViewModel) content.DataContext).Initialize(message, icon);
            await DialogHost.Show(content, Properties.Settings.Default.Indentifier);
        }

        public static async Task<bool> ShowQuestenDialog(string message, PackIconKind icon)
        {
            var content = ServiceLocator.Current.GetInstance<DialogQuestingView>();
            ((DialogViewModel)content.DataContext).Initialize(message, icon);
            var result = await DialogHost.Show(content, Properties.Settings.Default.Indentifier);
            if (result is bool request) return request;
            return false;
        }

        public static async Task<bool> ViewDetailDialog<TView, TModel, TEntity>(TEntity item, string title)
            where TModel : UserControlViewModelBase<TEntity>
            where TView : UserControl
            where TEntity : class
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var content = ServiceLocator.Current.GetInstance<TView>();
            ((TModel)content.DataContext).Init(item, title);

            var request = await DialogHost.Show(content, Properties.Settings.Default.Indentifier);
            if (request is bool result)
                return result;
            return false;
        }
    }
}