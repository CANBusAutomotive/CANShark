using CANShark.Desktop.ViewModels.Notification;
using Serilog;
using System;

namespace CANShark.Desktop.Utils
{
    public class AppExceptionHandler : IObserver<Exception>
    {
        private readonly ILogger _logger;
        private readonly NotificationViewModel _notificationViewModel;

        public AppExceptionHandler(
            ILogger logger,
            NotificationViewModel notificationViewModel)
        {
            _logger = logger;
            _notificationViewModel = notificationViewModel;
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
            _notificationViewModel.ShowError("Unhandled error", value.Message);
            _logger.Error(value, value.Message);
        }
    }
}
