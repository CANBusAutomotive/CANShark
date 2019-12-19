using PropertyChanged;

namespace CANShark.Services.Configuration.Models
{
    [AddINotifyPropertyChangedInterface]
    public class AppConfig
    {
        public string Baudrate { get; set; } = "500";

        public string Port { get; set; } = "COM1";

        public string WiresharkPath { get; set; } = @"c:\Program Files\USBPcap\";

        public double WindowHeight { get; set; } = 450;

        public double WindowWidth { get; set; } = 500;
    }
}
