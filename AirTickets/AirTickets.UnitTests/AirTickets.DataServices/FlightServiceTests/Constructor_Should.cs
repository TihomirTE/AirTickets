using AirTickets.Data.Contracts;
using AirTickets.Data.Models;
using AirTickets.DataServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace AirTickets.UnitTests.AirTickets.DataServices.FlightServiceTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnsAnInstance_WhenBothParametersAreNotNull()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Flight>>();
            var dbContextMock = new Mock<IAirTicketDbContextSaveChanges>();

            // Act
            FlightService flightService = new FlightService(wrapperMock.Object, dbContextMock.Object);

            // Assert
            Assert.IsNotNull(flightService);
        }

        [TestMethod]
        public void ThrowException_WhenFlightSetWrapperIsNull()
        {
            // Arrange
            var dbContextMock = new Mock<IAirTicketDbContextSaveChanges>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new FlightService(null, dbContextMock.Object));
        }

        [TestMethod]
        public void ThrowException_WhenDbContextIsNull()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Flight>>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new FlightService(wrapperMock.Object, null));
        }
    }
}
