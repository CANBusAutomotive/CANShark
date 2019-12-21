using CANShark.Desktop.Infrastructure.Windows.Modal;
using CANShark.Desktop.ViewModels.Core;
using CANShark.Desktop.ViewModels.Data;
using CANShark.Desktop.ViewModels.Notification;
using CANShark.Desktop.ViewModels.Setup;
using CANShark.Services.Configuration;

namespace CANShark.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(
            NotificationViewModel notificationViewModel,
            SetupViewModel setupMenuViewModel,
            CommandsViewModel commandsViewModel,
            MainViewModel mainViewViewModel,
            IAppConfigService appConfigService,
            ModalWindowManager modalWindowManager)
        {
            SetupMenuViewModel = setupMenuViewModel;
            CommandsViewModel = commandsViewModel;
            Notification = notificationViewModel;
            MainViewViewModel = mainViewViewModel;
            AppConfigService = appConfigService;
            ModalWindowManager = modalWindowManager;

            Content = MainViewViewModel;
        }

        public ViewModelBase Content { get; set; }

        public NotificationViewModel Notification { get; set; }

        public IAppConfigService AppConfigService { get; }

        public SetupViewModel SetupMenuViewModel { get; }

        public MainViewModel MainViewViewModel { get; }

        public CommandsViewModel CommandsViewModel { get; }

        public ModalWindowManager ModalWindowManager { get; }
    }
}
