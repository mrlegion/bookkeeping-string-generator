using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;

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

        private IEnumerable<Swatch> _swatches;

        public IEnumerable<Swatch> Swatches
        {
            get { return _swatches; }
            set { Set(nameof(Swatches), ref _swatches, value); }
        }

        public SettingWindowViewModel()
        {
            Title = "Основные настройки программы";
            Swatches = new SwatchesProvider().Swatches;
        }

        private RelayCommand<Swatch> _applyPrimaryCommand;

        public RelayCommand<Swatch> ApplyPrimaryCommand
        {
            get
            {
                return _applyPrimaryCommand ?? (_applyPrimaryCommand = new RelayCommand<Swatch>((swatch) =>
                {
                    new PaletteHelper().ReplacePrimaryColor(swatch);
                }));
            }
        }

        private RelayCommand<Swatch> _applyAccentCommand;

        public RelayCommand<Swatch> ApplyAccentCommand
        {
            get
            {
                return _applyAccentCommand ?? (_applyAccentCommand = new RelayCommand<Swatch>((swatch) =>
                {
                    new PaletteHelper().ReplaceAccentColor(swatch);
                }));
            }
        }

        private RelayCommand<bool> _changeThemeCommand;

        public RelayCommand<bool> ChangeThemeCommand
        {
            get
            {
                return _changeThemeCommand ?? (_changeThemeCommand = new RelayCommand<bool>((dark) =>
                {
                    new PaletteHelper().SetLightDark(dark);
                }));
            }
        }
    }
}