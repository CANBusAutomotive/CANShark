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

        public AppSuspendDriver(ILogger logger)
        {
            _logger = logger;
        }

        public IObservable<Unit> InvalidateState()
        {
            return Observable.Return(Unit.Default);
        }

        public IObservable<object> LoadState()
        {
            _logger.Information("Load state");
            return Observable.Return(new object());
        }

        public IObservable<Unit> SaveState(object state)
        {
            _logger.Information("Save state");
            return Observable.Return(Unit.Default);
        }

    }
}
