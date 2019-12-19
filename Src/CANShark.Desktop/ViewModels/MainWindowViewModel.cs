using CANShark.Desktop.ViewModels.Core;
using CANShark.Desktop.ViewModels.Data;
using CANShark.Desktop.ViewModels.Modal;
using CANShark.Desktop.ViewModels.Notification;
using CANShark.Services.Configuration;
using ReactiveUI;
using Serilog;
using System.Reactive;

namespace CANShark.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ILogger _logger;
        private readonly SetupMenuViewModel _setupMenuViewModel;
        private readonly AboutViewModel _aboutViewModel;
        private readonly CommandsViewModel _commandsViewModel;
        private readonly MainViewModel _mainViewViewModel;
        private readonly IAppConfigService _appConfigService;

        public MainWindowViewModel(
            ILogger logger,
            NotificationViewModel notificationViewModel,
            SetupMenuViewModel setupMenuViewModel,
            AboutViewModel aboutViewModel,
            CommandsViewModel commandsViewModel,
            MainViewModel mainViewViewModel,
            IAppConfigService appConfigService)
        {
            _logger = logger;
            _setupMenuViewModel = setupMenuViewModel;
            _aboutViewModel = aboutViewModel;
            _commandsViewModel = commandsViewModel;
            Notification = notificationViewModel;
            _mainViewViewModel = mainViewViewModel;
            _appConfigService = appConfigService;

            Content = _mainViewViewModel;

            ShowAboutModal = ReactiveCommand.Create(() =>
            {
                Modal = _aboutViewModel;
            });

            ShowSetupMenuModal = ReactiveCommand.Create(() =>
            {
                _logger.Information("Setup window");
                Modal = _setupMenuViewModel;
            });

            CloseModal = ReactiveCommand.Create(() =>
            {
                Modal = null;
            });
        }

        public ViewModelBase Content { get; set; }

        public ViewModelBase Modal { get; set; }

        public NotificationViewModel Notification { get; set; }

        public ReactiveCommand<Unit, Unit> ShowAboutModal { get; }

        public ReactiveCommand<Unit, Unit> ShowSetupMenuModal { get; }

        public ReactiveCommand<Unit, Unit> CloseModal { get; }

        public ILogger Logger => _logger;

        public IAppConfigService AppConfigService => _appConfigService;

        public SetupMenuViewModel SetupMenuViewModel => _setupMenuViewModel;

        public AboutViewModel AboutViewModel => _aboutViewModel;

        public MainViewModel MainViewViewModel => _mainViewViewModel;

        public CommandsViewModel CommandsViewModel => _commandsViewModel;
    }
}
