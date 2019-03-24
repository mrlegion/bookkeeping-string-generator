using System.Collections.Generic;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;

namespace WpfApp.ViewModels
{
    public class SettingWindowViewModel : ViewModelBase
    {
        #region Fields

        private string _title;
        private bool _isDark;
        private IEnumerable<Swatch> _swatches;
        private RelayCommand<Swatch> _applyPrimaryCommand;
        private RelayCommand<Swatch> _applyAccentCommand;
        private RelayCommand _changeThemeCommand;
        private RelayCommand _saveOnClosingCommand;
        private RelayCommand<Window> _saveAndCloseCommand;
        private RelayCommand<Window> _closeSettingCommand;

        #endregion

        #region Construct

        public SettingWindowViewModel()
        {
            Title = "Основные настройки программы";
            Swatches = new SwatchesProvider().Swatches;
            IsDark = Properties.Settings.Default.Theme;
        }

        #endregion

        #region Properties

        public string Title
        {
            get { return _title; }
            set { Set(nameof(Title), ref _title, value); }
        }

        public bool IsDark
        {
            get { return _isDark; }
            set { Set(nameof(IsDark), ref _isDark, value); }
        }

        public IEnumerable<Swatch> Swatches
        {
            get { return _swatches; }
            set { Set(nameof(Swatches), ref _swatches, value); }
        }

        public RelayCommand<Swatch> ApplyPrimaryCommand
        {
            get
            {
                return _applyPrimaryCommand ?? (_applyPrimaryCommand = new RelayCommand<Swatch>((swatch) =>
                {
                    new PaletteHelper().ReplacePrimaryColor(swatch);
                    Properties.Settings.Default.Primary = swatch.Name;
                }));
            }
        }

        public RelayCommand<Swatch> ApplyAccentCommand
        {
            get
            {
                return _applyAccentCommand ?? (_applyAccentCommand = new RelayCommand<Swatch>((swatch) =>
                {
                    new PaletteHelper().ReplaceAccentColor(swatch);
                    Properties.Settings.Default.Accent = swatch.Name;
                }));
            }
        }

        public RelayCommand ChangeThemeCommand
        {
            get
            {
                return _changeThemeCommand ?? (_changeThemeCommand = new RelayCommand(() =>
                {
                    new PaletteHelper().SetLightDark(IsDark);
                    Properties.Settings.Default.Theme = IsDark;
                }));
            }
        }

        public RelayCommand SaveOnClosingCommand
        {
            get
            {
                return _saveOnClosingCommand ?? (_saveOnClosingCommand = new RelayCommand(() =>
                {
                    Properties.Settings.Default.Save();
                }));
            }
        }

        public RelayCommand<Window> SaveAndCloseCommand
        {
            get
            {
                return _saveAndCloseCommand ?? (_saveAndCloseCommand = new RelayCommand<Window>((w) =>
                {
                    Properties.Settings.Default.Save();
                    w.Close();
                }));
            }
        }

        public RelayCommand<Window> CloseSettingCommand
        {
            get
            {
                return _closeSettingCommand ?? (_closeSettingCommand = new RelayCommand<Window>((w) =>
                {
                    w.Close();
                }));
            }
        }

        #endregion
    }
}