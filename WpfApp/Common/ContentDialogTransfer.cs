
namespace WpfApp.Common
{
    public class ContentDialogTransfer
    {
        public bool IsOpen { get; }

        public ContentDialogType DialogType { get; }

        public System.Windows.Controls.UserControl Content { get; }

        public ContentDialogTransfer(bool isOpen, ContentDialogType dialogType, System.Windows.Controls.UserControl content)
        {
            IsOpen = isOpen;
            DialogType = dialogType;
            Content = content;
        }
    }
}