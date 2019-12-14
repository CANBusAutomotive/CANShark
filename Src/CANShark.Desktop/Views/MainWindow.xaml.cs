using Avalonia;
using Avalonia.Markup.Xaml;
using CANShark.Desktop.Views.Core;

namespace CANShark.Desktop.Views
{
    public class MainWindow : BaseWindow
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
