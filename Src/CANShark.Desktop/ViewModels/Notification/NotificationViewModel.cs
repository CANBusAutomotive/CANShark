using CANShark.Desktop.ViewModels.Core;

namespace CANShark.Desktop.ViewModels.Notification
{
    public class NotificationViewModel : ViewModelBase
    {
        public ViewModelBase Content { get; set; }

        public void ShowError(string title, string message)
        {
            Content = new ErrorNotificationViewModel(title, message);
        }

        public void CloseNotification()
        {
            Content = null;
        }
    }


    public class NotificationViewModelBase : ViewModelBase
    {
        public NotificationViewModelBase(string title, string message)
        {
            Title = title;
            Message = message;
        }

        public string Title { get; } = string.Empty;

        public string Message { get; } = string.Empty;
    }

    public class ErrorNotificationViewModel : NotificationViewModelBase
    {
        public ErrorNotificationViewModel(string title, string message)
            : base(title, message)
        {
        }
    }

    public class InfoNotificationViewModel : NotificationViewModelBase
    {
        public InfoNotificationViewModel(string title, string message)
            : base(title, message)
        {
        }
    }
}
