using Avalonia.Controls;

namespace Porting10.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        TestTextBlock.Text = "This is a test for control name referencing.";
    }
}