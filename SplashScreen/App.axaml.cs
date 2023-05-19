using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using SplashScreen.ViewModels;
using SplashScreen.Views;

namespace SplashScreen;

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
            desktop.MainWindow = new SplashWindow(() =>
            {
                
                var mainWindow = new MainWindow()
                {
                    DataContext = new MainWindowViewModel()
                };

                mainWindow.Show();
                mainWindow.Focus();
                
                desktop.MainWindow = mainWindow;
            });
        }

        base.OnFrameworkInitializationCompleted();
        
    }
}