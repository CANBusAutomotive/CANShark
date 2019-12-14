using CANShark.Desktop.ViewModels.Core;
using CANShark.Desktop.ViewModels.Data;
using CANShark.Desktop.ViewModels.Modal;
using ReactiveUI;
using System.Reactive;

namespace CANShark.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Content = new CommandsViewModel();

            ShowAboutModal = ReactiveCommand.Create(() =>
            {
                Modal = new AboutViewModel();
            });

            ShowSetupMenuModal = ReactiveCommand.Create(() =>
            {
                Modal = new SetupMenuViewModel();
            });

            CloseModal = ReactiveCommand.Create(() =>
            {
                Modal = null;
            });

        }

        public ViewModelBase Content { get; set; }

        public ViewModelBase Modal { get; set; }

        public ReactiveCommand<Unit, Unit> ShowAboutModal { get; }

        public ReactiveCommand<Unit, Unit> ShowSetupMenuModal { get; }

        public ReactiveCommand<Unit, Unit> CloseModal { get; }
    }
}
