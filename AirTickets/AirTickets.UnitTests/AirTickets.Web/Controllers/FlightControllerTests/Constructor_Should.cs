using AirTickets.DataServices.Contracts;
using AirTickets.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace AirTickets.UnitTests.AirTickets.Controllers.FlightControllerTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnsAnInstance_WhenParameterIsNotNull()
        {
            // Arrange
            var flightServiceMock = new Mock<IFlightService>();
            var airlineServiceMock = new Mock<IAirlineService>();

            // Act
            FlightController flightController = new FlightController(flightServiceMock.Object, airlineServiceMock.Object);

            // Assert
            Assert.IsNotNull(flightController);
        }

        [TestMethod]
        public void ThrowException_WhenParameterFlightServiceIsNull()
        {
            var flightServiceMock = new Mock<IFlightService>();

            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new FlightController(flightServiceMock.Object, null));
        }

        [TestMethod]
        public void ThrowException_WhenParameterAirlineServiceIsNull()
        {
            var airlineServiceMock = new Mock<IAirlineService>();

            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new FlightController(null, airlineServiceMock.Object));
        }
    }
}