using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp.UserControls.Elements
{
    public partial class GroupElemets : UserControl
    {
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register(nameof(Heading), typeof(string), typeof(GroupElemets),
                new PropertyMetadata(default, delegate(DependencyObject o, DependencyPropertyChangedEventArgs args)
                {
                    if (o is GroupElemets ge)
                        ge.Header.Text = args.NewValue.ToString();
                }));

        public string Heading
        {
            get => (string)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        public static readonly DependencyProperty InfoProperty =
            DependencyProperty.Register(nameof(Info), typeof(IDictionary<string, string>), typeof(GroupElemets),
                new PropertyMetadata(default, delegate (DependencyObject o, DependencyPropertyChangedEventArgs args)
                {
                    if (o is GroupElemets ge)
                        if (args.NewValue is IDictionary<string, string> dictionary)
                            foreach (var values in dictionary)
                                ge.Root.Children.Add(new RowDetails {Title = values.Key, Message = values.Value});
                }));

        public IDictionary<string, string> Info
        {
            get => (IDictionary<string, string>)GetValue(HeaderProperty);
            set => SetValue(InfoProperty, value);
        }

        public static readonly DependencyProperty ExpandedProperty =
            DependencyProperty.Register(nameof(Expanded), typeof(bool), typeof(GroupElemets),
                new PropertyMetadata(false, delegate (DependencyObject o, DependencyPropertyChangedEventArgs args)
                {
                    if (o is GroupElemets ge)
                        if (args.NewValue is bool expand)
                            ge.GropExpander.IsExpanded = expand;
                }));

        public bool Expanded
        {
            get => (bool)GetValue(HeaderProperty);
            set => SetValue(InfoProperty, value);
        }

        public GroupElemets()
        {
            InitializeComponent();
        }
    }
}
