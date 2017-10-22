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

namespace AirTickets.UnitTests.AirTickets.DataServices.AirlineServiceTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnsAnInstance_WhenBothParametersAreNotNull()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Airline>>();
            var dbContextMock = new Mock<IAirTicketDbContextSaveChanges>();

            // Act
            var airlineService = new AirlineService(wrapperMock.Object, dbContextMock.Object);

            // Assert
            Assert.IsNotNull(airlineService);
        }

        [TestMethod]
        public void ThrowException_WhenAirlineSetWrapperIsNull()
        {
            // Arrange
            var dbContextMock = new Mock<IAirTicketDbContextSaveChanges>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new AirlineService(null, dbContextMock.Object));
        }

        [TestMethod]
        public void ThrowException_WhenDbContextIsNull()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Airline>>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new AirlineService(wrapperMock.Object, null));
        }
    }
}
