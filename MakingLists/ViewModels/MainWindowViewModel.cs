using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace MakingLists.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<string> Numbers { get; } 

    public MainWindowViewModel()
    {
        Numbers = new ObservableCollection<string>();
        for (var i = 0; i < 10; i++)
        {
            Numbers.Add($"{Random.Shared.Next(0, 100)}");
        }
        Numbers.CollectionChanged += (sender, args) =>
        {
            if (args.Action is NotifyCollectionChangedAction.Add or NotifyCollectionChangedAction.Remove)
            {
                DeleteRandomNumberToListCommand.NotifyCanExecuteChanged();
            }
        };
    }

    [RelayCommand]
    private void AddRandomNumberToList()
    {
        Numbers.Add($"{Random.Shared.Next(0, 100)}");
    }
    
    [RelayCommand(CanExecute = nameof(CanDeleteRandomNumberToList))]
    private void DeleteRandomNumberToList()
    {
        Numbers.RemoveAt(Random.Shared.Next(0, Numbers.Count - 1));
    }

    private bool CanDeleteRandomNumberToList()
    {
        return Numbers.Count > 0;
    }
}