using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;
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

            // setup connection string
            string connectionString = $"data source={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "IntegraCo\\Bookkeeping String Generation\\db\\Bookkeeping.db")};version=3";
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["Default"].ConnectionString = connectionString;
            config.Save();
            ConfigurationManager.RefreshSection("connnectionStrings");
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
