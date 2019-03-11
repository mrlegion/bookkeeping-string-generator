using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Messaging;
using Infrastructure.Entities;
using WpfApp.Service;
using DataGrid = System.Windows.Controls.DataGrid;

namespace WpfApp.Views
{
    /// <summary>
    /// Логика взаимодействия для BankInfoView.xaml
    /// </summary>
    public partial class BankInfoView : Page
    {
        public BankInfoView()
        {
            InitializeComponent();
        }

        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (((DataGrid) sender).SelectedItem is Bank bank)
            {
                ServiceLocator.Current.GetInstance<IFrameNavigationService>().NavigateTo("BankEdit", bank);
            }
        }
    }
}
