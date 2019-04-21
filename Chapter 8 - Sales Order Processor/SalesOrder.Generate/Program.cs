using SalesOrder.Common;
using SalesOrder.Data.Entities;
using SalesOrder.Data.Helpers;
using SalesOrder.Data.Products;
using SalesOrder.Data.SalesOrderCreation;
using SalesOrder.ServiceBus.Helpers;
using System.Threading.Tasks;

namespace SalesOrder.Generate
{
    class Program
    {     
        static async Task Main(string[] args)
        {
            // How manu to create?
            int salesOrderCount = int.Parse(args[0]);

            // Set-up Helpers and Dependencies
            var serviceBusHelper = new StorageQueueHelper();
            var textFileHelper = new TextFileHelper();

            // Set-up data access
            var options = new Microsoft.EntityFrameworkCore.DbContextOptions<SalesOrderContext>();
            var salesOrderContext = new SalesOrderContext(options);

            var productRepository = new ProductRepository(textFileHelper);
            var productService = new ProductService(productRepository);
            var salesOrderRepository = new SalesOrderRepository(salesOrderContext);

            var consoleLogger = new ConsoleLogger();

            // Process sales orders - will run forever
            var generateSalesOrders = new GenerateSalesOrders(
                serviceBusHelper, productService, consoleLogger);
            await generateSalesOrders.Run(salesOrderCount);
        }
    }
}
