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

namespace WpfApp.UserControls.Elements
{
    /// <summary>
    /// Логика взаимодействия для RowDetails.xaml
    /// </summary>
    public partial class RowDetails : UserControl
    {
        public static readonly DependencyProperty TitleProperty = 
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(RowDetails), 
                new PropertyMetadata("", (o, args) =>
                {
                    if (o is RowDetails rd)
                        rd.TitleTextBlock.Text = args.NewValue.ToString();
                }));

        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty MessageProperty = 
            DependencyProperty.Register(nameof(Message), typeof(string), typeof(RowDetails),
                new PropertyMetadata("", (o, args) =>
                {
                    if (o is RowDetails rd)
                        rd.ContentTextBlock.Text = args.NewValue.ToString();
                }));

        public string Message
        {
            get => (string) GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        public RowDetails()
        {
            InitializeComponent();
        }
    }
}
