using CANShark.Desktop.ViewModels.Core;

namespace CANShark.Desktop.ViewModels.Modal
{
    public class SetupMenuViewModel : ViewModelBase
    {
        public string SerialPort { get; set; }

        public string BaudRate { get; set; }
    }
}
