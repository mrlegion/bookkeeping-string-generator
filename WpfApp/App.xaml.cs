using System;
using System.Data;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight.Threading;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DispatcherHelper.Initialize();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var ph = new PaletteHelper();
            ph.SetLightDark(WpfApp.Properties.Settings.Default.Theme);

            var accint = new SwatchesProvider().Swatches.FirstOrDefault(s => s.Name == WpfApp.Properties.Settings.Default.Accent);
            var primary = new SwatchesProvider().Swatches.FirstOrDefault(s => s.Name == WpfApp.Properties.Settings.Default.Primary);

            if (accint != null && primary != null)
            {
                ph.ReplaceAccentColor(accint);
                ph.ReplacePrimaryColor(primary);
            }
            
            base.OnStartup(e);
        }
    }
}
