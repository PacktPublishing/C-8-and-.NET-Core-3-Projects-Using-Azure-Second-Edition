using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStorage.WindowsService.AzureClient
{
    public class AzureStorageClientService : ICloudStorageClientService
    {
        private string _connectionString;
        public AzureStorageClientService()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            _connectionString = configuration["ConnectionStrings:netcodephotostorage"];
        }

        public async Task<bool> FileExists(string name)
        {
            var blob = GetBlockBlobReference(name);

            return await blob.ExistsAsync();            
        }

        public async Task<bool> RenameFile(string name, string oldName)
        {
            var blobNew = GetBlockBlobReference(name);
            var blobOld = GetBlockBlobReference(oldName);

            if (await blobNew.ExistsAsync()) return false;

            await blobNew.StartCopyAsync(blobOld);
            await blobOld.DeleteAsync();

            return true;
        }

        public async Task UploadFile(string fullPath)
        {
            string fileName = Path.GetFileName(fullPath);

            var blob = GetBlockBlobReference(fileName);

            using (var fileStream = System.IO.File.OpenRead(fullPath))
            {
                await blob.UploadFromStreamAsync(fileStream);
            }
        }

        private CloudBlockBlob GetBlockBlobReference(string fileName)
        {
            if (CloudStorageAccount.TryParse(_connectionString,
                out CloudStorageAccount storageAccount))
            {
                var client = storageAccount.CreateCloudBlobClient();
                var container = client.GetContainerReference("photos");
                var blob = container.GetBlockBlobReference(fileName);

                return blob;
            }
            else
            {
                throw new Exception("Unable to parse the storage account");
            }
        }
    }
}
