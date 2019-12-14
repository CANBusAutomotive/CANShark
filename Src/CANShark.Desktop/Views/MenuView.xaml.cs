using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CANShark.Desktop.Views
{
    public class MenuView : UserControl
    {
        public MenuView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
