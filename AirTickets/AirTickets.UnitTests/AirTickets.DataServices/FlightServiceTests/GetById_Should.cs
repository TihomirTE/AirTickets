using AirTickets.Data.Contracts;
using AirTickets.Data.Models;
using AirTickets.DataServices;
using AirTickets.DataServices.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace AirTickets.UnitTests.AirTickets.DataServices.FlightServiceTests
{
    [TestClass]
    public class GetById_Should
    {
        [TestMethod]
        public void ReturnFlightModel_WhenThereIsAModelWithThePassedId()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Flight>>();
            var dbContextMock = new Mock<IAirTicketDbContextSaveChanges>();

            Guid? flightId = Guid.NewGuid();

            wrapperMock.Setup(m => m.GetById(flightId.Value)).Returns(new Flight() { Id = flightId.Value });

            FlightService flightService = new FlightService(wrapperMock.Object, dbContextMock.Object);

            // Act
            FlightModel flightModel = flightService.GetById(flightId);

            // Assert
            Assert.IsNotNull(flightModel);
        }

        [TestMethod]
        public void ReturnNull_WhenIdIsNull()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Flight>>();
            var dbContextMock = new Mock<IAirTicketDbContextSaveChanges>();

            FlightService flightService = new FlightService(wrapperMock.Object, dbContextMock.Object);

            // Act
            FlightModel flightModel = flightService.GetById(null);

            // Assert
            Assert.IsNull(flightModel);
        }

        [TestMethod]
        public void ReturnNull_WhenThereIsNoModelWithThePassedId()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Flight>>();
            var dbContextMock = new Mock<IAirTicketDbContextSaveChanges>();
            Guid? flightId = Guid.NewGuid();

            wrapperMock.Setup(m => m.GetById(flightId.Value)).Returns((Flight)null);

            FlightService flightService = new FlightService(wrapperMock.Object, dbContextMock.Object);

            // Act
            FlightModel flightModel = flightService.GetById(flightId);

            // Assert
            Assert.IsNull(flightModel);
        }
    }
}