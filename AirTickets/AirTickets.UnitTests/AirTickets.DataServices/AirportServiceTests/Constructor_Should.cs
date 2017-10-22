using AirTickets.Data.Contracts;
using AirTickets.Data.Models;
using AirTickets.DataServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.UnitTests.AirTickets.DataServices.AirportServiceTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnsAnInstance_WhenBothParametersAreNotNull()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Airport>>();
            var dbContextMock = new Mock<IAirTicketDbContextSaveChanges>();

            // Act
            var airportService = new AirportService(wrapperMock.Object, dbContextMock.Object);

            // Assert
            Assert.IsNotNull(airportService);
        }

        [TestMethod]
        public void ThrowException_WhenAirportSetWrapperIsNull()
        {
            // Arrange
            var dbContextMock = new Mock<IAirTicketDbContextSaveChanges>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new AirportService(null, dbContextMock.Object));
        }

        [TestMethod]
        public void ThrowException_WhenDbContextIsNull()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Airport>>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new AirportService(wrapperMock.Object, null));
        }
    }
}
