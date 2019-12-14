using CANShark.Desktop.ViewModels.Modal;
using ReactiveUI;
using System.Reactive;

namespace CANShark.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _content;
        private ViewModelBase _modal;

        public MainWindowViewModel()
        {
            ShowAboutModal = ReactiveCommand.Create(() =>
            {
                Modal = new AboutViewModel();
            });
        }

        public ViewModelBase Content
        {
            get => _content;
            private set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public ViewModelBase Modal
        {
            get => _modal;
            private set => this.RaiseAndSetIfChanged(ref _modal, value);
        }

        public ReactiveCommand<Unit, Unit> ShowAboutModal { get; }
    }
}
