using NSubstitute;
using SalesOrder.Data.Helpers;
using System;
using Xunit;

namespace SalesOrder.UnitTests.ProductRepositoryTests
{
    public class GetProductData
    {
        [Fact]
        public void GetProductData_HasData_ReturnsCorrectProductCount()
        {
            // Arrange
            string textFileContents = $"CLAWHAMMER,13.95{Environment.NewLine}NAIL010MMX100,2.50{Environment.NewLine}NAIL015MMX100,2.50";

            var textFileHelper = Substitute.For<ITextFileHelper>();
            textFileHelper.GetContentTextFile("ProductList.csv").Returns(textFileContents);
            var productRepository = new Data.Products.ProductRepository(textFileHelper);

            // Act
            var data = productRepository.GetProductData();

            // Assert
            Assert.Equal(3, data.Count);
        }

        [Fact]
        public void GetProductData_HasDataAndBlankLines_ReturnsCorrectProductCount()
        {
            // Arrange
            string textFileContents = $"CLAWHAMMER,13.95{Environment.NewLine}NAIL010MMX100,2.50{Environment.NewLine}{Environment.NewLine}NAIL015MMX100,2.50{Environment.NewLine}{Environment.NewLine}";

            var textFileHelper = Substitute.For<ITextFileHelper>();
            textFileHelper.GetContentTextFile("ProductList.csv").Returns(textFileContents);
            var productRepository = new Data.Products.ProductRepository(textFileHelper);

            // Act
            var data = productRepository.GetProductData();

            // Assert
            Assert.Equal(3, data.Count);
        }

    }
}
