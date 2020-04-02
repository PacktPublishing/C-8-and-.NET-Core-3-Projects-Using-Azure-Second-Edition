using System;
using System.Collections.Generic;
using System.Text;

namespace SalesOrder.Data.Products
{
    public interface IProductService
    {
        IEnumerable<SalesOrder.Models.Product> GetProductData();
    }
}
