using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using SalesOrder.Models;

namespace SalesOrder.ServiceBus.Helpers
{
    public class StorageQueueHelper : IStorageQueueHelper
    {
        public async Task ConfirmSalesOrderToMessageQueue(Models.SalesOrder salesOrderData)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                "DefaultEndpointsProtocol=https;AccountName=salesorderqueue;AccountKey=kz8eED0s25wezSDCyj0BmukVq2zE9puEFRVq4jIR++n8L1NNSUyAxeJXZHVN91BgsQQ9sPE2gnlsb5MWC1TsVw==;EndpointSuffix=core.windows.net");

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("salesorderconfirm");
            await queue.CreateIfNotExistsAsync();
            CloudQueueMessage message = new CloudQueueMessage(JsonConvert.SerializeObject(salesOrderData));

            await queue.AddMessageAsync(message);

        }

        public async Task<Models.SalesOrder?> GetNextOrderFromMessageQueue()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                "DefaultEndpointsProtocol=https;AccountName=salesorderqueue;AccountKey=kz8eED0s25wezSDCyj0BmukVq2zE9puEFRVq4jIR++n8L1NNSUyAxeJXZHVN91BgsQQ9sPE2gnlsb5MWC1TsVw==;EndpointSuffix=core.windows.net");

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("salesorder");
            var message = await queue.GetMessageAsync();
            if (message == null) return null;

            string data = message.AsString;

            var salesOrder = JsonConvert.DeserializeObject<Models.SalesOrder>(data);

            await queue.DeleteMessageAsync(message.Id, message.PopReceipt);

            return salesOrder;
        }

        public async Task SendToSalesOrderMessageQueue(Models.SalesOrder salesOrderData)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                "DefaultEndpointsProtocol=https;AccountName=salesorderqueue;AccountKey=kz8eED0s25wezSDCyj0BmukVq2zE9puEFRVq4jIR++n8L1NNSUyAxeJXZHVN91BgsQQ9sPE2gnlsb5MWC1TsVw==;EndpointSuffix=core.windows.net");

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("salesorder");
            await queue.CreateIfNotExistsAsync();
            CloudQueueMessage message = new CloudQueueMessage(JsonConvert.SerializeObject(salesOrderData));

            await queue.AddMessageAsync(message);
        }

    }
}
