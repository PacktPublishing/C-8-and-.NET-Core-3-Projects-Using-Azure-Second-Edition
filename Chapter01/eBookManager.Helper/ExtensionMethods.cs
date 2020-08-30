using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using eBookManager.Engine;

namespace eBookManager.Helper
{
    public static class ExtensionMethods
    {
        public static int ToInt(this string value, int defaultInteger = 0)
        {
            return int.TryParse(value, out var validInteger)
                ? validInteger
                : defaultInteger;
        }

        public static double ToMegabytes(this long bytes) =>
            (bytes > 0) ? (bytes / 1024f) / 1024f : bytes;

        public static bool StorageSpaceExists(this List<StorageSpace> space,
            string nameValueToCheck, out int storageSpaceId)
        {
            storageSpaceId = 0;
            if (space.Count == 0)
            {
                return false;
            }

            storageSpaceId = (from r in space
                              select r.ID).Max() + 1;
            var count = (from r in space
                         where r.Name.Equals(nameValueToCheck)
                         select r).Count();
            return count > 0;
        }

        public static async Task WriteToDataStore(this List<StorageSpace> value,
            string storagePath)
        {
            using var fs = File.Create(storagePath);
            await JsonSerializer.SerializeAsync(fs, value);
        }

        public static async Task<List<StorageSpace>> ReadFromDataStore(this List<StorageSpace> value, string storagePath)
        {
            if (!File.Exists(storagePath))
            {
                var newFile = File.Create(storagePath);
                newFile.Close();
            }

            using var fs = File.OpenRead(storagePath);
            if (fs.Length == 0)
            {
                return new List<StorageSpace>();
            }

            var storageList = await JsonSerializer.DeserializeAsync<List<StorageSpace>>(fs);

            return storageList;
        }
    }
}
