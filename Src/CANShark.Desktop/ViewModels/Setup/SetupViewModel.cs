using System.Reactive;
using CANShark.Desktop.Infrastructure.Dialogs;
using CANShark.Desktop.Infrastructure.Windows.Modal;
using CANShark.Desktop.ViewModels.Core;
using CANShark.Desktop.ViewModels.Modal;
using CANShark.Services.Configuration;
using ReactiveUI;

namespace CANShark.Desktop.ViewModels.Setup
{
    public class SetupViewModel : ViewModelBase
    {
        private readonly IDialogManager _dialogManager;
        private readonly ModalWindowManager _modalWindowManager;

        public SetupViewModel(
            IDialogManager dialogManager,
            IAppConfigService appConfigService,
            ModalWindowManager modalWindowManager)
        {
            _dialogManager = dialogManager;
            AppConfigService = appConfigService;
            _modalWindowManager = modalWindowManager;

            SetWireSharkFolderCmd = ReactiveCommand.CreateFromTask(async () =>
            {
                AppConfigService.Config.WiresharkPath = await _dialogManager.ShowFolderDialog();
            });

            SetPortCmd = ReactiveCommand.Create(() =>
            {
                _modalWindowManager.ShowModalFor<SetPortViewModel>();
            });
        }

        public IAppConfigService AppConfigService { get; }

        public ReactiveCommand<Unit, Unit> SetWireSharkFolderCmd { get; set; }

        public ReactiveCommand<Unit, Unit> SetPortCmd { get; set; }
    }
}
