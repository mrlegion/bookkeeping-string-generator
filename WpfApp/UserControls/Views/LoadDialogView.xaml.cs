using System.Windows.Controls;

namespace WpfApp.UserControls.Views
{
    /// <summary>
    /// Логика взаимодействия для LoadDataDialogView.xaml
    /// </summary>
    public partial class LoadDialogView : UserControl
    {
        public string Text
        {
            get => Message.Text;
            set => Message.Text = value;
        }
        public LoadDialogView()
        {
            InitializeComponent();
        }
    }
}
