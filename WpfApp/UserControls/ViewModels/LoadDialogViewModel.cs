using GalaSoft.MvvmLight;

namespace WpfApp.UserControls.ViewModels
{
    public class LoadDialogViewModel : ViewModelBase
    {
        private string _message;

        public string Message
        {
            get { return _message; }
            set { Set(nameof(Message), ref _message, value); }
        }
    }
}