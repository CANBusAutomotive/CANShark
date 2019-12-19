using CANShark.Services.Configuration.Models;
using System;
using System.IO;
using System.Text.Json;

namespace CANShark.Services.Configuration
{
    public class JsonConfigService : IAppConfigService
    {
        private const string _configurationFileName = "appconfig.json";

        private readonly string _currentDirectory;

        private readonly string _fullPathToConfiguration;

        public event EventHandler<IAppConfigService> ConfigurationSaved;

        public JsonConfigService()
        {
            _currentDirectory = Directory.GetCurrentDirectory();
            _fullPathToConfiguration = Path.Combine(_currentDirectory, _configurationFileName);
        }

        public AppConfig Config { get; set; }

        public void LoadConfig()
        {
            try
            {
                using (var stream = new StreamReader(_fullPathToConfiguration))
                {
                    Config = JsonSerializer.Deserialize<AppConfig>(stream.ReadToEnd());
                }

                ConfigurationSaved?.Invoke(this, this);
            }
            catch (Exception)
            {
                Config = new AppConfig();
            }
        }

        public void SaveConfig()
        {
            var json = JsonSerializer.Serialize<AppConfig>(Config);
            using (StreamWriter streamwriter = File.CreateText(_fullPathToConfiguration))
            {
                streamwriter.WriteLine(json);
            }

        }
    }
}
