using System;
using System.Text;
using System.Collections.Generic;
using Moq;
using AirTickets.Web.Controllers.Flight;
using AirTickets.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirTickets.UnitTests.AirTickets.Web.Controllers.FlightControllerTests
{
    /// <summary>
    /// Summary description for Contructor_Should
    /// </summary>
    [TestClass]
    public class Contructor_Should
    {
        [TestMethod]
        public void ReturnsAnInstance_WhenParameterIsNotNull()
        {
            // Arrange
            var flightServiceMock = new Mock<IFlightService>();
            var destinationServiceMock = new Mock<IDestinationService>();

            // Act
            var flightController = new FlightController(flightServiceMock.Object, destinationServiceMock.Object);

            // Assert
            Assert.IsNotNull(flightController);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
        "flightController is null")]
        public void ThrowException_WhenParametersAreNull()
        {
            // Arrange & Act & Assert
            //Assert.ThrowsException<ArgumentNullException>(() => new FlightController(null, null));
            var flightController = new FlightController(null, null);
        }
    }
}
