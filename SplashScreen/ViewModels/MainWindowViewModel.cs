using System;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SplashScreen.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private string? _text = "Avalonia is a cross-platform UI framework for dotnet, providing a" +
                                                 " flexible styling system and supporting a wide range of platforms" +
                                                 " such as Windows, macOS, Linux, iOS, Android and WebAssembly. ";
}