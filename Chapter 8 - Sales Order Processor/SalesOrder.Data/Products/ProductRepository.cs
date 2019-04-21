using System;
using System.Collections.Generic;
using System.Text;
using SalesOrder.Data.Helpers;
using SalesOrder.Models;

namespace SalesOrder.Data.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly ITextFileHelper _textFileHelper;

        public ProductRepository(ITextFileHelper textFileHelper)
        {
            _textFileHelper = textFileHelper;
        }

        public IList<SalesOrder.Models.Product> GetProductData()
        {            
            string data = _textFileHelper.GetContentTextFile("ProductList.csv");

            var products = new List<Models.Product>();

            string[] productLines = data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);            
            foreach(var productLine in productLines)
            {
                string[] productData = productLine.Split(',');

                var product = new Models.Product()
                {
                    ProductCode = productData[0],
                    UnitPrice = decimal.Parse(productData[1])
                };

                products.Add(product);
            }

            return products;
        }
    }
}
