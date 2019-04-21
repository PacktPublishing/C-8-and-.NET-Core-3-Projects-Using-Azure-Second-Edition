using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesOrder.Common;
using SalesOrder.Data.Products;
using SalesOrder.ServiceBus.Helpers;

namespace SalesOrder.Generate
{
    public class GenerateSalesOrders
    {
        private readonly IStorageQueueHelper _serviceBusHelper;        
        private readonly IProductService _productService;
        private readonly ILogger _logger;

        private Random _rnd = new Random();

        public GenerateSalesOrders(IStorageQueueHelper serviceBusHelper,
                                   IProductService productService,
                                   ILogger logger)
        {
            _serviceBusHelper = serviceBusHelper;            
            _productService = productService;
            _logger = logger;
        }

        public async Task Run(int salesOrderCount)
        {            
            for (int i = 0; i < salesOrderCount; i++)
            {
                var newOrder = CreateSalesOrder();
                await _serviceBusHelper.SendToSalesOrderMessageQueue(newOrder);
            }

        }

        private SalesOrder.Models.SalesOrder CreateSalesOrder()
        {
            _logger.Log("Creating new sales order");

            // Get valid Product Codes
            var products = _productService.GetProductData();
            var product = products.ElementAt(_rnd.Next(products.Count() - 1));

            var salesOrder = new SalesOrder.Models.SalesOrder()
            {
                Reference = Guid.NewGuid(),
                ProductCode = product.ProductCode,
                UnitPrice = product.UnitPrice,
                Quantity = _rnd.Next(1, 5)
            };

            return salesOrder;
        }

    }
}
