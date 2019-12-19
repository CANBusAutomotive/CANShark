using Avalonia;
using Avalonia.Logging.Serilog;
using Avalonia.ReactiveUI;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CANShark.Desktop
{
    internal class Program
    {
        public static int Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;


            return BuildAvaloniaApp()
             .StartWithClassicDesktopLifetime(args);
        }

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToDebug()
                .UseReactiveUI();

        private static void CurrentDomainOnUnhandledException(
            object sender, UnhandledExceptionEventArgs e)
        {
            var error = e.ExceptionObject.ToString();
            Console.Error.WriteLine(error);
            Console.Error.WriteLine();

            var file = "fatal.log";
            File.AppendAllText(file, error);
            File.AppendAllText(file, Environment.NewLine);
        }

        private static void TaskSchedulerOnUnobservedTaskException(
            object sender, UnobservedTaskExceptionEventArgs e)
        {
            var error = e.Exception.ToString();
            Console.WriteLine(error);
            Console.Error.WriteLine();

            var file = "fatal.log";
            File.AppendAllText(file, error);
            File.AppendAllText(file, Environment.NewLine);
        }
    }
}
