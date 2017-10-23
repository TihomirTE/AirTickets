using AirTickets.DataServices.Contracts;
using AirTickets.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AirTickets.UnitTests.AirTickets.Web.Controllers.HomeControllerTests
{
    [TestClass]
    public class Index_Should
    {
        [TestMethod]
        public void ViewModel_WhenParametersAreCorrect()
        {
            // Arrange
            var airportServiceMock = new Mock<IAirportService>();

            var homeController = new HomeController(airportServiceMock.Object);

            // Act
            var result = homeController.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
