using Avalonia.Markup.Xaml;
using CANShark.Desktop.Views.Core;

namespace CANShark.Desktop.Views.Modal
{
    public class SetupMenuView : BaseControl
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
