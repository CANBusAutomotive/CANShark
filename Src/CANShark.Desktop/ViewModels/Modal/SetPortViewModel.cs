using CANShark.Desktop.Infrastructure.Windows.Modal;
using CANShark.Desktop.ViewModels.Core;
using CANShark.Services.Configuration;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.IO.Ports;
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

            RefreshPortList = ReactiveCommand.Create(() =>
            {
                PortList?.Clear();
                PortList = new ObservableCollection<string>(SerialPort.GetPortNames());
            });

            AppyPort = ReactiveCommand.Create(() =>
            {
                _appConfigService.Config.Port = SelectedPort;
                MessageBus.Current.SendMessage<string>("closeModal");
            });

            RefreshPortList.Execute().Subscribe();
        }

        public string SelectedPort { get; set; }

        public ObservableCollection<string> PortList { get; set; }

        public ReactiveCommand<Unit, Unit> RefreshPortList { get; set; }

        public ReactiveCommand<Unit, Unit> AppyPort { get; set; }
    }
}
