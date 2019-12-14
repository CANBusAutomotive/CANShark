﻿using Avalonia.Markup.Xaml;
using CANShark.Desktop.Views.Core;

namespace CANShark.Desktop.Views
{
    public class MenuView : BaseControl
    {
        public MenuView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
