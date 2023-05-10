using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace DataListExample.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<string> Numbers { get; }
    public ICommand AddRandomNumberToList { get; }
    public ICommand DeleteRandomNumberToList { get; }

    public MainWindowViewModel()
    {
        Numbers = new ObservableCollection<string>();
        AddRandomNumberToList = new RelayCommand(OnAddRandomNumberToList);
        DeleteRandomNumberToList = new RelayCommand(OnDeleteRandomNumberToList, () => Numbers.Count > 0);

        for (var i = 0; i < 10; i++)
        {
            Numbers.Add($"{Random.Shared.Next(0, 100)}");
        }
    }

    private void OnAddRandomNumberToList()
    {
        Numbers.Add($"{Random.Shared.Next(0, 100)}");
    }

    private void OnDeleteRandomNumberToList()
    {
        Numbers.RemoveAt(Random.Shared.Next(0, Numbers.Count - 1));
    }
}