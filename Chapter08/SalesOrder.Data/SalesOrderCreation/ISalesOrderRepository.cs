
using SalesOrder.Data.Entities;

namespace SalesOrder.Data.SalesOrderCreation
{
    public interface ISalesOrderRepository
    {
        void Create(SalesOrderEntity salesOrderEntity);
        
    }
}
