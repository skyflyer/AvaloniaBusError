using System.Diagnostics;
using Avalonia.Controls.ApplicationLifetimes;
using AvaloniaBusError;
using MiniMvvm;

namespace AvaloniaBusError;

public class ApplicationViewModel : ViewModelBase
{
    public string IconPath { get; set; } = "/Assets/test_icon.ico";

    public MiniCommand ExitCommand { get; }
    
    public ApplicationViewModel()
    {
        Trace.WriteLine("ApplicationViewModel ctor");
        ExitCommand = MiniCommand.Create(() =>
            {
                (App.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.Shutdown();
            });
    }
}