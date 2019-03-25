using GalaSoft.MvvmLight;
using MaterialDesignThemes.Wpf;

namespace WpfApp.UserControls.ViewModels
{
    public class DialogViewModel : ViewModelBase
    {
        private PackIconKind _icon;

        public PackIconKind Icon
        {
            get { return _icon; }
            set { Set(nameof(Icon), ref _icon, value); }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { Set(nameof(Message), ref _message, value); }
        }

        public void Initialize(string message, PackIconKind icon)
        {
            Message = message;
            Icon = icon;
        }
    }
}