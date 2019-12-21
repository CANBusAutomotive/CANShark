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
            MessageBus.Current.Listen<string>()
                .Where(x => x == "closeModal")
                .Subscribe(_ => CloseModal());
        }

        public ViewModelBase Content { get; set; }

        public void ShowModalFor<TType>() where TType : ViewModelBase
        {
            Content = App.ServicePropvider.GetService<TType>();
        }

        public void CloseModal()
        {
            Content = null;
        }
    }
}
