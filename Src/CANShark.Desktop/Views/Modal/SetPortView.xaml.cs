using Avalonia.Markup.Xaml;
using CANShark.Desktop.Views.Core;

namespace CANShark.Desktop.Views.Modal
{
    public class SetPortView : BaseControl
    {
        public SetPortView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
