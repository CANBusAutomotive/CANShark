using Avalonia;
using Avalonia.Markup.Xaml;
using CANShark.Desktop.ViewModels;
using CANShark.Desktop.ViewModels.Data;
using CANShark.Desktop.ViewModels.Modal;
using CANShark.Desktop.Views;
using Microsoft.Extensions.DependencyInjection;
using PropertyChanged;

namespace CANShark.Desktop
{
    [DoNotNotify]
    public class App : Application
    {
        private ServiceProvider _sp;

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private ServiceProvider ConfigureServices(ServiceCollection services)
        {
            services = new ServiceCollection();

            // Register windows
            services.AddSingleton<MainWindow>();

            // Register viewModels
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<CommandsViewModel>();
            services.AddSingleton<AboutViewModel>();
            services.AddSingleton<SetupMenuViewModel>();

            return services.BuildServiceProvider();
        }

        public override void OnFrameworkInitializationCompleted()
        {
            _sp = ConfigureServices(new ServiceCollection());

            var mainWindow = _sp.GetService<MainWindow>();
            mainWindow.DataContext = _sp.GetService<MainWindowViewModel>();
            mainWindow.Show();

            base.OnFrameworkInitializationCompleted();
        }
    }
}
