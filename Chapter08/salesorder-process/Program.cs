using SalesOrder.Data.Entities;
using SalesOrder.Data.Helpers;
using SalesOrder.Data.Products;
using SalesOrder.Data.SalesOrderCreation;
using SalesOrder.ServiceBus.Helpers;
using System;
using System.Threading.Tasks;

namespace salesorder_process
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var options = new Microsoft.EntityFrameworkCore.DbContextOptions<SalesOrderContext>();            
            var salesOrderContext = new SalesOrderContext(options);         

            var serviceBusHelper = new StorageQueueHelper();
            var testFileHelper = new TextFileHelper();
            var productRepository = new ProductRepository(testFileHelper);
            var productService = new ProductService(productRepository);
            var salesOrderRepository = new SalesOrderRepository(salesOrderContext);
            var salesOrderService = new SalesOrderService(salesOrderRepository);

            var salesOrderProcessor = new SalesOrderProcessor(
                serviceBusHelper, productService, salesOrderService);
            
            await salesOrderProcessor.Run();
        }
    }
}
