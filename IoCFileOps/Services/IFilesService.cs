using System.Threading.Tasks;
using Avalonia.Platform.Storage;

namespace IoCFileOps.Services;

public interface IFilesService
{
    public Task<IStorageFile?> OpenFileAsync();
    public Task<IStorageFile?> SaveFileAsync();
}