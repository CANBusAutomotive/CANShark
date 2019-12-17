using System;
using System.Reactive;
using CANShark.Desktop.Infrastructure.Dialogs;
using CANShark.Desktop.ViewModels.Core;
using ReactiveUI;

namespace CANShark.Desktop.ViewModels.Modal
{
    public class SetupMenuViewModel : ViewModelBase
    {
        private readonly IDialogManager _dialogManager;

        public SetupMenuViewModel(IDialogManager dialogManager)
        {
            _dialogManager = dialogManager;

            SetWireSharkFolder = ReactiveCommand.CreateFromTask(async () =>
            {
                throw new NotImplementedException();
                SharkFolder = await _dialogManager.ShowFolderDialog();
            });
        }

        public string SerialPort { get; set; }

        public string BaudRate { get; set; }

        public string SharkFolder { get; set; }

        public ReactiveCommand<Unit, Unit> SetWireSharkFolder { get; set; }
    }
}
