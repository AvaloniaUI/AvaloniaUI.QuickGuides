using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IoCFileOps.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IoCFileOps.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private string? _fileText;

    [RelayCommand]
    private async Task OpenFile(CancellationToken token)
    {
        ErrorMessages?.Clear();
        try
        {
            var filesService = App.Current?.Services?.GetService<IFilesService>();
            if (filesService is null) throw new NullReferenceException("Missing File Service instance.");

            var file = await filesService.OpenFile();
            if (file is null) return;

            // Limit the text file to 1MB so that the demo wont lag.
            if ((await file.GetBasicPropertiesAsync()).Size <= 1024 * 1024 * 1)
            {
                await using var readStream = await file.OpenReadAsync();
                using var reader = new StreamReader(readStream);
                FileText = await reader.ReadToEndAsync(token);
            }
            else
            {
                throw new Exception("File exceeded 1MB limit.");
            }
        }
        catch (Exception e)
        {
            ErrorMessages?.Add(e.Message);
        }
    }

    [RelayCommand]
    private async Task SaveFile()
    {
        ErrorMessages?.Clear();
        try
        {
            var filesService = App.Current?.Services?.GetService<IFilesService>();
            if (filesService is null) throw new NullReferenceException("Missing File Service instance.");

            var file = await filesService.SaveFile();
            if (file is null) return;


            // Limit the text file to 1MB so that the demo wont lag.
            if (FileText?.Length <= 1024 * 1024 * 1)
            {
                var stream = new MemoryStream(Encoding.Default.GetBytes((string)FileText));
                await using var writeStream = await file.OpenWriteAsync();
                await stream.CopyToAsync(writeStream);
            }
            else
            {
                throw new Exception("File exceeded 1MB limit.");
            }
        }
        catch (Exception e)
        {
            ErrorMessages?.Add(e.Message);
        }
    }
}