using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BindingConvertersExample.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private int _age;
}