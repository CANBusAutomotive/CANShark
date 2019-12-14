using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CANShark.Desktop.Views
{
    public class StatusBarView : UserControl
    {
        public StatusBarView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
