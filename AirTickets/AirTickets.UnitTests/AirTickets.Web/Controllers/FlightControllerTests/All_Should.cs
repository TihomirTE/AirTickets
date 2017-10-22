using AirTickets.DataServices.Contracts;
using AirTickets.DataServices.Models;
using AirTickets.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AirTickets.UnitTests.AirTickets.Web.Controllers.FlightControllerTests
{
    [TestClass]
    public class All_Should
    {
        [TestMethod]
        public void ViewModel_WhenParametersAreCorrect()
        {
            // Arrange
            var flightServiceMock = new Mock<IFlightService>();
            var airlineServiceMock = new Mock<IAirlineService>();

            var flightController = new FlightController(flightServiceMock.Object, airlineServiceMock.Object);

            // Act
            var result = flightController.All();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
