using System;
using System.Collections.Generic;
using System.Text;
using SalesOrder.Models;

namespace SalesOrder.Data.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<SalesOrder.Models.Product> GetProductData()
        {
            return _productRepository.GetProductData();
        }

        public bool IsSufficientStock(SalesOrder.Models.SalesOrder salesOrder)
        {
            throw new NotImplementedException();
        }
    }
}
