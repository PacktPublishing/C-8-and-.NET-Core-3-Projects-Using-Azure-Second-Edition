using NSubstitute;
using SalesOrder.Common;
using SalesOrder.Data.Products;
using SalesOrder.Generate;
using SalesOrder.ServiceBus.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SalesOrder.UnitTests.Generate
{
    public class GenerateSalesOrdersTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(20)]
        public async Task GenerateSalesOrders_CreatesCorrectOrderCount(int runCount)
        {
            // Arrange
            var productService = Substitute.For<IProductService>();
            productService.GetProductData().Returns(new List<Models.Product>()
            {
                new Models.Product() {ProductCode = "AAA", UnitPrice = 12.34m}
            });

            var serviceBusHelper = Substitute.For<IStorageQueueHelper>();
            var logger = Substitute.For<ILogger>();
            
            var generateSalesOrders = new GenerateSalesOrders(
                serviceBusHelper, productService, logger);

            // Act
            await generateSalesOrders.Run(runCount);

            // Assert
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            serviceBusHelper.Received(runCount).SendToSalesOrderMessageQueue(Arg.Any<Models.SalesOrder>());
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }
    }
}
