using CANShark.Desktop.Infrastructure.Windows.Modal;
using CANShark.Desktop.ViewModels.Core;
using CANShark.Services.Configuration;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;

namespace CANShark.Desktop.ViewModels.Modal
{
    public class SetPortViewModel : ViewModelBase
    {
        private readonly ModalWindowManager _modalWindowManager;
        private readonly IAppConfigService _appConfigService;

        public SetPortViewModel(
            ModalWindowManager modalWindowManager,
            IAppConfigService appConfigService)
        {
            _modalWindowManager = modalWindowManager;
            _appConfigService = appConfigService;

            PortList = new ObservableCollection<string>
            {
                "COM1",
                "COM2",
                "COM3"
            };

            AppyPort = ReactiveCommand.Create(() =>
            {
                _appConfigService.Config.Port = SelectedPort;
                MessageBus.Current.SendMessage<string>("closeModal");
            });
        }

        public string SelectedPort { get; set; }

        public ObservableCollection<string> PortList { get; set; }

        public ReactiveCommand<Unit, Unit> AppyPort { get; set; }
    }
}
