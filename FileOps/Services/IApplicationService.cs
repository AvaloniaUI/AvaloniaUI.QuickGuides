using System.Threading.Tasks;
using Avalonia.Platform.Storage;

namespace FileOpsExample.Services;

public interface IApplicationService
{
    public Task<IStorageFile?> OpenFile();
    public Task<IStorageFile?> SaveFile();
}