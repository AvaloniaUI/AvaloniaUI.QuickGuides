using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Platform.Storage;

namespace DragDropOps.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var textCount = 0;

        SetupDnd(DragMeText, d => d.Set(DataFormats.Text,
                $"Text was dragged {++textCount} times."), 
            DragDropEffects.Copy | DragDropEffects.Move | DragDropEffects.Link);

        SetupDnd(DragMeCustom, d => d.Set(CustomFormat, "Some Custom Data Here"), DragDropEffects.Move);
    }

    private const string CustomFormat = "application/xxx-drag-custom";
    
    private void SetupDnd(IInputElement draggable, Action<DataObject> factory, DragDropEffects effects)
    {
        draggable.PointerPressed += (_, e) => DoDrag(factory, e, effects);

        AddHandler(DragDrop.DropEvent, Drop);
        AddHandler(DragDrop.DragOverEvent, DragOver);
    }

    private async void DoDrag(Action<DataObject> factory, PointerEventArgs e, DragDropEffects effects)
    {
        var dragData = new DataObject();
        factory(dragData);

        var result = await DragDrop.DoDragDrop(e, dragData, effects);
        
        DragState.Text = result switch
        {
            DragDropEffects.Move => "Data was moved.",
            DragDropEffects.Copy => "Data was copied.",
            DragDropEffects.Link => "Data was linked.",
            DragDropEffects.None => "The drag operation was canceled.",
            _ => "Unknown result"
        };
    }

    private void DragOver(object? sender, DragEventArgs e)
    {
        if (Equals(e.Source, MoveTarget))
        {
            e.DragEffects &= DragDropEffects.Move;
        }
        else
        {
            e.DragEffects &= DragDropEffects.Copy;
        }

        // Only allow if the dragged data contains text or filenames.
        if (!e.Data.Contains(DataFormats.Text)
            && !e.Data.Contains(DataFormats.Files)
            && !e.Data.Contains(CustomFormat))
            e.DragEffects = DragDropEffects.None;
    }

    private void Drop(object? sender, DragEventArgs e)
    {
        if (Equals(e.Source, MoveTarget))
        {
            e.DragEffects &= DragDropEffects.Move;
        }
        else
        {
            e.DragEffects &= DragDropEffects.Copy;
        }

        if (e.Data.Contains(DataFormats.Text))
        {
            DropState.Text = e.Data.GetText();
        }

        else if (e.Data.Contains(CustomFormat))
        {
            DropState.Text = e.Data.Get(CustomFormat)?.ToString();
        }
    }
}