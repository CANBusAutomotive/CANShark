using CANShark.Desktop.ViewModels.Core;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using Splat;
using System;
using System.Reactive.Linq;

namespace CANShark.Desktop.Infrastructure.Windows.Modal
{
    public class ModalWindowManager : ViewModelBase
    {
        public ModalWindowManager()
        {
            MessageBus.Current.Listen<ModalActions>()
                .Where(x => x ==  ModalActions.Close)
                .Subscribe(_ => CloseModal());
        }

        public ViewModelBase Content { get; set; }

        public void ShowModalFor<T>() where T : ViewModelBase
        {
            Content = App.ServicePropvider.GetService<T>()
                ?? throw new ArgumentException($"{typeof(T).FullName} is not registered");
        }

        public void CloseModal()
        {
            Content = null;
        }
    }
}
