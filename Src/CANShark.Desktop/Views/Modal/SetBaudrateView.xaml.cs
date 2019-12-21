using Avalonia.Markup.Xaml;
using CANShark.Desktop.Views.Core;

namespace CANShark.Desktop.Views.Modal
{
    public class SetBaudrateView : BaseControl
    {
        public SetBaudrateView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
