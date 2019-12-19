using System.Reactive;
using CANShark.Desktop.Infrastructure.Dialogs;
using CANShark.Desktop.ViewModels.Core;
using CANShark.Services.Configuration;
using ReactiveUI;

namespace CANShark.Desktop.ViewModels.Modal
{
    public class SetupMenuViewModel : ViewModelBase
    {
        private readonly IDialogManager _dialogManager;
        private readonly IAppConfigService _appConfigService;

        public SetupMenuViewModel(IDialogManager dialogManager, IAppConfigService appConfigService)
        {
            _dialogManager = dialogManager;
            _appConfigService = appConfigService;

            SetWireSharkFolder = ReactiveCommand.CreateFromTask(async () =>
            {
                AppConfigService.Config.WiresharkPath = await _dialogManager.ShowFolderDialog();
            });
        }

        public IAppConfigService AppConfigService => _appConfigService;

        public ReactiveCommand<Unit, Unit> SetWireSharkFolder { get; set; }
    }
}
