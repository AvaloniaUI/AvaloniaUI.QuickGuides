using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using ImageExample.Helpers;

namespace ImageExample.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public Bitmap? ImageFromBinding { get; } = ImageHelper.LoadFromResource(new ("avares://ImageExample/Assets/abstract.jpg"));
    public Task<Bitmap?> ImageFromWebsite { get; } = ImageHelper.LoadFromWeb(new ("https://upload.wikimedia.org/wikipedia/commons/4/41/NewtonsPrincipia.jpg"));
}