using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using CANShark.Desktop.Utils;
using CANShark.Desktop.ViewModels;
using CANShark.Desktop.ViewModels.Data;
using CANShark.Desktop.ViewModels.Modal;
using CANShark.Desktop.ViewModels.Notification;
using CANShark.Desktop.Views;
using Microsoft.Extensions.DependencyInjection;
using PropertyChanged;
using ReactiveUI;
using Serilog;

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

        private ILogger ConfigoreLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            return Log.Logger;
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
            services.AddSingleton<NotificationViewModel>();

            // Register utils
            services.AddSingleton<AppSuspendDriver>();
            services.AddTransient<AppExceptionHandler>();

            // Register services
            services.AddSingleton(ConfigoreLogging());

            return services.BuildServiceProvider();
        }

        public override void OnFrameworkInitializationCompleted()
        {
            _sp = ConfigureServices(new ServiceCollection());

            var suspension = new AutoSuspendHelper(ApplicationLifetime);
            RxApp.DefaultExceptionHandler = _sp.GetService<AppExceptionHandler>();
            RxApp.SuspensionHost.SetupDefaultSuspendResume(_sp.GetService<AppSuspendDriver>());
            suspension.OnFrameworkInitializationCompleted();

            var mainWindow = _sp.GetService<MainWindow>();
            mainWindow.DataContext = _sp.GetService<MainWindowViewModel>();
            mainWindow.Show();

            base.OnFrameworkInitializationCompleted();
        }
    }
}
