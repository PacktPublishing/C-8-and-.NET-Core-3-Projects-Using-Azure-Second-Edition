using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WebResearch.Controllers;
using WebResearch.Models;
using Xunit;

namespace WebResearch.Test
{
    public class ResearchControllerTests
    {
        [Fact]
        public async Task RetrieveDetails_DetailsCorrect()
        {
            // Arrange
            var testUrl = "www.pmichaels.net";
            var options = new DbContextOptionsBuilder<ResearchContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;
            var researchContext = new ResearchContext(options);
            var researchController = new ResearchController(researchContext);
            var research = new Research()
            {
                Id = 1,
                DateSaved = new DateTime(2018, 10, 24),
                Note = "Useful site for programming and tech information",
                Read = false,
                Url = testUrl
            };

            var createResult = await researchController.Create(research);

            // Act
            var detailsResult = await researchController.Details(1);

            // Assert
            var viewResult = (ViewResult)detailsResult;
            var resultsModel = (Research)viewResult.Model;
            Assert.Equal(testUrl, resultsModel.Url);
        }

        [Fact]
        public async Task RetrieveInvalidRecord_DetailsCorrect()
        {
            // Arrange
            var testUrl = "www.pmichaels.net";
            var options = new DbContextOptionsBuilder<ResearchContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;
            var researchContext = new ResearchContext(options);
            var researchController = new ResearchController(researchContext);
            var research = new Research()
            {
                Id = 1,
                DateSaved = new DateTime(2018, 10, 24),
                Note = "Useful site for programming and tech information",
                Read = false,
                Url = testUrl
            };

            var createResult = await researchController.Create(research);

            // Act
            var detailsResult = await researchController.Details(2);

            // Assert
            Assert.IsType<NotFoundResult>(detailsResult);
        }
    }
}
