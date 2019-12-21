using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using CANShark.Desktop.Infrastructure.Dialogs;
using CANShark.Desktop.Infrastructure.Windows.Modal;
using CANShark.Desktop.Utils;
using CANShark.Desktop.ViewModels;
using CANShark.Desktop.ViewModels.Data;
using CANShark.Desktop.ViewModels.Modal;
using CANShark.Desktop.ViewModels.Notification;
using CANShark.Desktop.ViewModels.Setup;
using CANShark.Desktop.Views;
using CANShark.Services.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PropertyChanged;
using ReactiveUI;
using Serilog;

namespace CANShark.Desktop
{
    [DoNotNotify]
    public class App : Application
    {
        internal static ServiceProvider ServicePropvider { get; private set; }

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
            services.AddSingleton<SetupViewModel>();
            services.AddSingleton<NotificationViewModel>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<SetPortViewModel>();

            // Register utils
            services.AddSingleton<AppSuspendDriver>();
            services.AddTransient<AppExceptionHandler>();
            services.AddSingleton<ModalWindowManager>();
            services.AddTransient<IDialogManager, NativeDialogManager>();

            // Register services
            services.AddSingleton(ConfigoreLogging());
            services.AddSingleton<IAppConfigService, JsonConfigService>();

            return services.BuildServiceProvider();
        }

        public override void OnFrameworkInitializationCompleted()
        {
            ServicePropvider = ConfigureServices(new ServiceCollection());

            var suspension = new AutoSuspendHelper(ApplicationLifetime);
            RxApp.DefaultExceptionHandler = ServicePropvider.GetService<AppExceptionHandler>();
            RxApp.SuspensionHost.SetupDefaultSuspendResume(ServicePropvider.GetService<AppSuspendDriver>());
            suspension.OnFrameworkInitializationCompleted();

            var mainWindow = ServicePropvider.GetService<MainWindow>();
            mainWindow.DataContext = ServicePropvider.GetService<MainWindowViewModel>();
            mainWindow.Show();

            base.OnFrameworkInitializationCompleted();
        }
    }
}
