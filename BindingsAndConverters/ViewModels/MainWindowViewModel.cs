using CommunityToolkit.Mvvm.ComponentModel;

namespace BindingConvertersExample.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private int _age;
}