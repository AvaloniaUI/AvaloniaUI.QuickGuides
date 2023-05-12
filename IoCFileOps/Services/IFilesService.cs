using System.Threading.Tasks;
using Avalonia.Platform.Storage;

namespace IoCFileOps.Services;

public interface IFilesService
{
    public Task<IStorageFile?> OpenFile();
    public Task<IStorageFile?> SaveFile();
}