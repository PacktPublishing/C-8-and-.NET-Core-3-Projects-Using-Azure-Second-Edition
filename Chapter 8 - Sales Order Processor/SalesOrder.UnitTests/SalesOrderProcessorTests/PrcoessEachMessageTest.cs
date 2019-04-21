using NSubstitute;
using SalesOrder.Data.Products;
using SalesOrder.Data.SalesOrderCreation;
using SalesOrder.ServiceBus.Helpers;
using salesorder_process;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SalesOrder.UnitTests.SalesOrderProcessorTests
{
    public class RunTest
    {
        [Fact]
        public async Task NoMessages_Run()
        {
            // Arrange
            var serviceBusHelper = Substitute.For<IStorageQueueHelper>();
            var productService = Substitute.For<IProductService>();
            var salesOrderService = Substitute.For<ISalesOrderService>();
            var salesOrderProcessor = new SalesOrderProcessor(
                serviceBusHelper, productService, salesOrderService);

            // Act
            bool result = await salesOrderProcessor.ProcessEachMessage();

            // Assert
            Assert.False(result);
        }
    }
}
