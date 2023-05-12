using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using IoCFileOps.Services;
using IoCFileOps.ViewModels;
using IoCFileOps.Views;
using Microsoft.Extensions.DependencyInjection;

namespace IoCFileOps;

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
            desktop.MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel()
            };

            var services = new ServiceCollection();

            services.AddSingleton<IFilesService>(x => new FilesService(desktop.MainWindow));

            Services = services.BuildServiceProvider();
        }

        base.OnFrameworkInitializationCompleted();
    }
    
    public new static App? Current => Application.Current as App;

    /// <summary>
    /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
    /// </summary>
    public IServiceProvider? Services { get; private set; }
}