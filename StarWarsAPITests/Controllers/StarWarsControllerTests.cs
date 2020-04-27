using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StarWarsAPI.Controllers;
using StarWarsAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsAPI.Controllers.Tests
{
    [TestClass()]
    public class StarWarsControllerTests
    {
        [TestMethod()]
        public async void GetTest()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<StarWarsController>>();
            var mockService = new Mock<IStarWarsService>();

            mockService.Setup(service => service.GetCharactersByFilm(It.IsNotNull<string>()))
                                                .ReturnsAsync(new Models.Character[0]);
            var controller = new StarWarsController(mockLogger.Object, mockService.Object);
            // Act
            var result = await controller.Get();
            // Assert
            Assert.IsTrue(result.ContentType == "arraybuffer");
        }
    }
}