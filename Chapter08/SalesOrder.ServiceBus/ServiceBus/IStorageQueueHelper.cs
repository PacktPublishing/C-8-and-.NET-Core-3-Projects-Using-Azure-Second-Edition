using System.Threading.Tasks;
using SalesOrder.Models;

namespace SalesOrder.ServiceBus.Helpers
{
    public interface IStorageQueueHelper
    {
        Task SendToSalesOrderMessageQueue(SalesOrder.Models.SalesOrder salesOrderData);
        Task<Models.SalesOrder?> GetNextOrderFromMessageQueue();
        Task ConfirmSalesOrderToMessageQueue(Models.SalesOrder value);        
    }
}
