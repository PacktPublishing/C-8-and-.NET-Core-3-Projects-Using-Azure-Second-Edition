using NSubstitute;
using SalesOrder.Data.Entities;
using SalesOrder.Data.SalesOrderCreation;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SalesOrder.UnitTests.SalesOrderServiceTests
{
    public class CreateSalesOrder
    {
        [Fact]
        public void CreateSalesOrder_RepositorySaveInvoked()
        {
            // Arrange
            var salesOrderRepository = Substitute.For<ISalesOrderRepository>();
            var salesOrderService = new SalesOrderService(salesOrderRepository);
            var salesOrder = new Models.SalesOrder()
            {
                ProductCode = "NAIL12IN",
                UnitPrice = 0.23M,
                Quantity = 3,
                Reference = new Guid("d0d12bc2-5a1b-4147-8acb-49228ef11411")
            };

            // Act
            salesOrderService.Create(salesOrder);

            // Assert
            salesOrderRepository.Received(1).Create(Arg.Is<SalesOrderEntity>(a => a.Reference == salesOrder.Reference));
        }
    }
}
