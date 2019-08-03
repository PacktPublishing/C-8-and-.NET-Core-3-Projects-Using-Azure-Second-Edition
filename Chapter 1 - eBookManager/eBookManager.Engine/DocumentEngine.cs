using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookManager.Engine
{
    public class DocumentEngine
    {
        /*
        public List<string> BooksFound { get; private set; }
        public int BooksFoundCount { get; private set; }
        public void GetAllFiles(string folder)
        {
            // https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-write-a-simple-parallel-for-loop
            //IReadOnlyList<Document> docList = 
            // https://stackoverflow.com/questions/41561365/running-async-foreach-loop-c-sharp-async-await

            var fileEntries = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories);
            var rangePartitioner = Partitioner.Create(0, fileEntries.Count()); //.Length);
            List<string> lstResults = new List<string>();
            
            Parallel.ForEach(rangePartitioner, (range, loopState) =>
            {
                // Loop over each range element without a delegate invocation.
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    if (!(fileEntries.ElementAtOrDefault(i) == null))
                        lstResults.Add(fileEntries.ElementAtOrDefault(i));
                }
            });
            BooksFound = lstResults;

            //string[] subFolders = Directory.GetDirectories(folder);
            //foreach (string sub in subFolders)
            //{
            //    GetAllFiles(sub);
            //}

            BooksFoundCount = lstResults.Count();
            
        }
        */

        public (DateTime dateCreated, DateTime dateLastAccessed, string fileName, string fileExtension, long fileLength, bool error) GetFileProperties(string filePath)
        {
            var returnTuple = (created: DateTime.MinValue, lastDateAccessed: DateTime.MinValue, name: "", ext: "", fileSize: 0L, error: false);
            
            try
            {
                FileInfo fi = new FileInfo(filePath);
                fi.Refresh();
                returnTuple = (fi.CreationTime, fi.LastAccessTime, fi.Name, fi.Extension, fi.Length, false);
            }
            catch
            {
                returnTuple.error = true;
            }
            return returnTuple;
        }


    }
}
