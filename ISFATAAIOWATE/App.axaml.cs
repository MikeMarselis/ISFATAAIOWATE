using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ISFATAAIOWATE.ViewModels;
using ISFATAAIOWATE.Views;

namespace ISFATAAIOWATE;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new AuthorizationWindow()
            {
                DataContext = new AuthorizationVM(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}