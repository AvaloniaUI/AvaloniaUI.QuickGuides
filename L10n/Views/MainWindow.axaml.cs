using System.Globalization;
using Avalonia.Controls;

namespace L10n.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        L10n.Resources.Culture = new CultureInfo("tl-PH");
    }
}