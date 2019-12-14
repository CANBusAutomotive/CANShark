using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CANShark.Desktop.Views.Data
{
    public class CommandsView : UserControl
    {
        public CommandsView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
