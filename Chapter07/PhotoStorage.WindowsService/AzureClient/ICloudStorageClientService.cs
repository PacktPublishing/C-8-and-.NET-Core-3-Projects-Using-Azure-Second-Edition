using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStorage.WindowsService.AzureClient
{
    public interface ICloudStorageClientService
    {
        Task<bool> RenameFile(string name, string oldName);
        Task UploadFile(string fullPath);
        //Task UpdateFile(string fullPath);
        Task<bool> FileExists(string name);
    }
}
