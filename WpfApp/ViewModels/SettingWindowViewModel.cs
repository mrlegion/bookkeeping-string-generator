using GalaSoft.MvvmLight;

namespace WpfApp.ViewModels
{
    public class SettingWindowViewModel : ViewModelBase
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set { Set(nameof(Title), ref _title, value); }
        }

        public SettingWindowViewModel()
        {
            Title = "Основные настройки программы";
        }
    }
}