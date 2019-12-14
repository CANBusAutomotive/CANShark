using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CANShark.Desktop.Views.Modal
{
    public class SetupMenuView : UserControl
    {
        public SetupMenuView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
