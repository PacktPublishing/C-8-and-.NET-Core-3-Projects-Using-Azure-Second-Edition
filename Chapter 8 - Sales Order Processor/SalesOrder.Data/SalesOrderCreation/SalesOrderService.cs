using SalesOrder.Data.Entities;

namespace SalesOrder.Data.SalesOrderCreation
{
    public class SalesOrderService : ISalesOrderService
    {
        private readonly ISalesOrderRepository _salesOrderRepository;        

        public SalesOrderService(ISalesOrderRepository salesOrderRepository)
        {
            _salesOrderRepository = salesOrderRepository;
        }

        public void Create(SalesOrder.Models.SalesOrder salesOrder)
        {
            var salesOrderEntity = new SalesOrderEntity()
            {
                ProductCode = salesOrder.ProductCode,
                Quantity = salesOrder.Quantity,
                Reference = salesOrder.Reference,
                UnitPrice = salesOrder.UnitPrice
            };
            _salesOrderRepository.Create(salesOrderEntity);
        }
    }
}
