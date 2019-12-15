﻿using Avalonia;
using Avalonia.Logging.Serilog;
using Avalonia.ReactiveUI;

namespace CANShark.Desktop
{
    internal class Program
    {
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToDebug()
                .UseReactiveUI();
    }
}
