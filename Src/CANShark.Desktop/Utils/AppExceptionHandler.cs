using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace CANShark.Desktop.Utils
{
    public class AppExceptionHandler : IObserver<Exception>
    {
        private readonly ILogger _logger;

        public AppExceptionHandler(
            ILogger logger)
        {
            _logger = logger;
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Exception value)
        {
            _logger.Error(value, value.Message);
        }
    }
}
