using SalesOrder.Data.Products;
using SalesOrder.Data.SalesOrderCreation;
using SalesOrder.ServiceBus.Helpers;
using System;
using System.Threading.Tasks;

namespace salesorder_process
{
    public class SalesOrderProcessor
    {
        private readonly IStorageQueueHelper _serviceBusHelper;
        private readonly IProductService _productService;
        private readonly ISalesOrderService _salesOrderService;

        public SalesOrderProcessor(IStorageQueueHelper serviceBusHelper,
                                   IProductService productService,
                                   ISalesOrderService salesOrderService)
        {
            _serviceBusHelper = serviceBusHelper;
            _productService = productService;
            _salesOrderService = salesOrderService;
        }

        public async Task Run()
        {
            while (true)
            {
                if (!await ProcessEachMessage())
                { 
                    await Task.Delay(60000);
                    continue;
                }
            }
        }

        public async Task<bool> ProcessEachMessage()
        {
            SalesOrder.Models.SalesOrder? salesOrder = await _serviceBusHelper.GetNextOrderFromMessageQueue();

            if (salesOrder == null) return false;

            _salesOrderService.Create(salesOrder);
            await _serviceBusHelper.ConfirmSalesOrderToMessageQueue(salesOrder);

            return true;
        }
    }
}