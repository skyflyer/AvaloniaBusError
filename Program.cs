using Avalonia;
using System;
using System.Diagnostics;

namespace AvaloniaBusError;

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
        Trace.AutoFlush = true;

        Trace.WriteLine("Program start");

        try {
            BuildAvaloniaApp()
                .StartWithClassicDesktopLifetime(args);
        } catch (Exception x) {
            Trace.WriteLine("Exception: " + x.ToString());
        } finally {
            Trace.WriteLine("Program exit");
        }
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace(Avalonia.Logging.LogEventLevel.Verbose);
}
