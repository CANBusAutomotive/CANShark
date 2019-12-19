using CANShark.Services.Configuration;
using ReactiveUI;
using Serilog;
using System;
using System.Reactive;
using System.Reactive.Linq;

namespace CANShark.Desktop.Utils
{
    public class AppSuspendDriver : ISuspensionDriver
    {
        private readonly ILogger _logger;
        private readonly IAppConfigService _appConfigService;

        public AppSuspendDriver(ILogger logger, IAppConfigService appConfigService)
        {
            _logger = logger;
            _appConfigService = appConfigService;
        }

        public IObservable<Unit> InvalidateState()
        {
            return Observable.Return(Unit.Default);
        }

        public IObservable<object> LoadState()
        {
            _appConfigService.LoadConfig();
            _logger.Information("Load config");
            return Observable.Return(new object());
        }

        public IObservable<Unit> SaveState(object state)
        {
            _appConfigService.SaveConfig();
            _logger.Information("Save config");
            return Observable.Return(Unit.Default);
        }
    }
}
