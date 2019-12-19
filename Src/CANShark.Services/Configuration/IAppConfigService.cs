using CANShark.Services.Configuration.Models;
using System;

namespace CANShark.Services.Configuration
{
    public interface IAppConfigService
    {
        AppConfig Config { get; set; }

        event EventHandler<IAppConfigService> ConfigurationSaved;

        void SaveConfig();

        void LoadConfig();
    }
}
