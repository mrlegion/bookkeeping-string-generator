using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using Microsoft.WindowsAPICodePack.Dialogs;
using WpfApp.Properties;

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
        private bool _isOneDate;
        private DateTime _defaultDate;
        private string _typeOfPayment;
        private string _typeOfPaying;
        private string _queuePayment;
        private string _moneySeparator;
        private bool _totalToString;
        private List<string> _separators;
        private string _folder;
        private RelayCommand _selectFolderCommand;

        #endregion

        #region Construct

        public SettingWindowViewModel()
        {
            Title = "Основные настройки программы";
            Swatches = new SwatchesProvider().Swatches;
            Separators = new List<string> {"Дефис", "Точка", "Запятая"};

            IsDark = Settings.Default.Theme;
            TotalToString = Settings.Default.TotalToString;
            IsOneDate = Settings.Default.IsOneDate;
            DefaultDate = Settings.Default.DefaultDate;
            TypeOfPayment = Settings.Default.TypeOfPayment;
            TypeOfPaying = Settings.Default.TypeOfPaying;
            QueuePayment = Settings.Default.QueuePayment;
            Folder = Settings.Default.DefaultFolder;

            MoneySeparator = SetSeparator(Settings.Default.MoneySeparator);
        }

        #endregion

        #region Properties

        public List<string> Separators
        {
            get { return _separators; }
            set { Set(nameof(Separators), ref _separators, value); }
        }

        public string Title
        {
            get => _title;
            set => Set(nameof(Title), ref _title, value);
        }

        public bool IsDark
        {
            get => _isDark;
            set => Set(nameof(IsDark), ref _isDark, value);
        }

        public IEnumerable<Swatch> Swatches
        {
            get => _swatches;
            set => Set(nameof(Swatches), ref _swatches, value);
        }

        public RelayCommand<Swatch> ApplyPrimaryCommand
        {
            get
            {
                return _applyPrimaryCommand ?? (_applyPrimaryCommand = new RelayCommand<Swatch>(swatch =>
                {
                    new PaletteHelper().ReplacePrimaryColor(swatch);
                    Settings.Default.Primary = swatch.Name;
                }));
            }
        }

        public RelayCommand<Swatch> ApplyAccentCommand
        {
            get
            {
                return _applyAccentCommand ?? (_applyAccentCommand = new RelayCommand<Swatch>(swatch =>
                {
                    new PaletteHelper().ReplaceAccentColor(swatch);
                    Settings.Default.Accent = swatch.Name;
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
                    Settings.Default.Theme = IsDark;
                }));
            }
        }

        public RelayCommand SaveOnClosingCommand
        {
            get
            {
                return _saveOnClosingCommand ?? (_saveOnClosingCommand = new RelayCommand(() =>
                {
                    Settings.Default.Save();
                }));
            }
        }

        public RelayCommand<Window> SaveAndCloseCommand
        {
            get
            {
                return _saveAndCloseCommand ?? (_saveAndCloseCommand = new RelayCommand<Window>(w =>
                {
                    Settings.Default.Save();
                    w.Close();
                }));
            }
        }

        public RelayCommand<Window> CloseSettingCommand
        {
            get
            {
                return _closeSettingCommand ?? (_closeSettingCommand = new RelayCommand<Window>(w => { w.Close(); }));
            }
        }

        public bool TotalToString
        {
            get => _totalToString;
            set
            {
                Set(nameof(TotalToString), ref _totalToString, value);
                Settings.Default.TotalToString = value;
            }
        }

        public bool IsOneDate
        {
            get => _isOneDate;
            set
            {
                Set(nameof(IsOneDate), ref _isOneDate, value);
                Settings.Default.IsOneDate = value;
            }
        }

        public DateTime DefaultDate
        {
            get => _defaultDate;
            set
            {
                Set(nameof(DefaultDate), ref _defaultDate, value);
                Settings.Default.DefaultDate = value;
            }
        }

        public string TypeOfPayment
        {
            get => _typeOfPayment;
            set
            {
                Set(nameof(TypeOfPayment), ref _typeOfPayment, value);
                Settings.Default.TypeOfPayment = value;
            }
        }

        public string TypeOfPaying
        {
            get => _typeOfPaying;
            set
            {
                Set(nameof(TypeOfPaying), ref _typeOfPaying, value);
                Settings.Default.TypeOfPaying = value;
            }
        }

        public string QueuePayment
        {
            get => _queuePayment;
            set
            {
                Set(nameof(QueuePayment), ref _queuePayment, value);
                Settings.Default.QueuePayment = value;
            }
        }

        public string MoneySeparator
        {
            get => _moneySeparator;
            set
            {
                Set(nameof(MoneySeparator), ref _moneySeparator, value);
                Settings.Default.MoneySeparator = GetSeparator();
            }
        }

        public string Folder
        {
            get { return _folder; }
            set { Set(nameof(Folder), ref _folder, value); }
        }

        public RelayCommand SelectFolderCommand
        {
            get
            {
                return _selectFolderCommand ?? (_selectFolderCommand = new RelayCommand(() =>
                {
                    CommonFileDialog dialog = new CommonOpenFileDialog()
                    {
                        Title = "Выбор папки для сохранения",
                        IsFolderPicker = true,
                        InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                    };

                    if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                        if (Directory.Exists(dialog.FileName))
                        {
                            Folder = dialog.FileName;
                            Settings.Default.DefaultFolder = Folder;
                        }
                }));
            }
        }

        #endregion

        #region Private methods

        private string SetSeparator(char defaultMoneySeparator)
        {
            switch (defaultMoneySeparator)
            {
                case '-': return "Дефис";
                case '.': return "Точка";
                case ',': return "Запятая";
                default: throw new ArgumentException("Not found separator type");
            }
        }

        private char GetSeparator()
        {
            if (MoneySeparator == null) throw new ArgumentNullException(nameof(MoneySeparator));
            switch (MoneySeparator)
            {
                case "Дефис": return '-';
                case "Точка": return '.';
                case "Запятая": return ',';
                default: throw new ArgumentException("Not found separator type");
            }
        }

        #endregion
    }
}