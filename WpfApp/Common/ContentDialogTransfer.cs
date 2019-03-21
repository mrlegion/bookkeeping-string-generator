using System.Windows.Controls;

namespace WpfApp.Common
{
    public class ContentDialogTransfer
    {
        public bool IsOpen { get; }

        public ContentDialogType DialogType { get; }

        public UserControl Content { get; }

        public ContentDialogTransfer(bool isOpen, ContentDialogType dialogType, UserControl content)
        {
            IsOpen = isOpen;
            DialogType = dialogType;
            Content = content;
        }
    }
}