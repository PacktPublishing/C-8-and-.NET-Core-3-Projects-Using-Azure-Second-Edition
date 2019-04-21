using System;
using System.Collections.Generic;
using System.Text;

namespace SalesOrder.Data.Products
{
    public interface IProductRepository
    {
        IList<SalesOrder.Models.Product> GetProductData();
    }
}
