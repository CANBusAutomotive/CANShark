using CANShark.Desktop.Infrastructure.Windows.Modal;
using CANShark.Desktop.ViewModels.Core;
using CANShark.Services.Configuration;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;

namespace CANShark.Desktop.ViewModels.Modal
{
    public class SetBaudrateViewModel : ViewModelBase
    {
        private readonly ModalWindowManager _modalWindowManager;
        private readonly IAppConfigService _appConfigService;

        public SetBaudrateViewModel(
            ModalWindowManager modalWindowManager,
            IAppConfigService appConfigService)
        {
            _modalWindowManager = modalWindowManager;
            _appConfigService = appConfigService;

            BaudrateList = new ObservableCollection<string>
            {
                "10",
                "20",
                "50",
                "100",
                "125",
                "250",
                "500",
                "800",
                "1000"
            };

            ApplyBaudrateCmd = ReactiveCommand.Create(() =>
            {
                _appConfigService.Config.Baudrate = SelectedBaudrate;
                MessageBus.Current.SendMessage<ModalActions>(ModalActions.Close);
            });
        }

        public string SelectedBaudrate { get; set; }

        public ObservableCollection<string> BaudrateList { get; set; }

        public ReactiveCommand<Unit, Unit> ApplyBaudrateCmd { get; set; }
    }
}
