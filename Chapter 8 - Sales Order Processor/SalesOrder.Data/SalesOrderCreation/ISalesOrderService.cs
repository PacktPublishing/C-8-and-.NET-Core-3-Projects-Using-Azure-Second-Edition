using SalesOrder.Models;

namespace SalesOrder.Data.SalesOrderCreation
{
    public interface ISalesOrderService
    {
        void Create(SalesOrder.Models.SalesOrder salesOrder);
    }
}
