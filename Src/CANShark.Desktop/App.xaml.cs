using Avalonia;
using Avalonia.Markup.Xaml;
using PropertyChanged;

namespace CANShark.Desktop
{
    [DoNotNotify]
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
