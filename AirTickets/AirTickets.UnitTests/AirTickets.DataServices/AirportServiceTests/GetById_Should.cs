using AirTickets.Data.Contracts;
using AirTickets.Data.Models;
using AirTickets.DataServices;
using AirTickets.DataServices.Models;
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
    public class GetById_Should
    {
        [TestMethod]
        public void ReturnAirportModel_WhenThereIsAModelWithThePassedId()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Airport>>();
            var dbContextMock = new Mock<IAirTicketDbContextSaveChanges>();

            Guid? airportId = Guid.NewGuid();

            wrapperMock.Setup(x => x.GetById(airportId.Value)).Returns(new Airport() { Id = airportId.Value });

            var airportService = new AirportService(wrapperMock.Object, dbContextMock.Object);

            // Act
            var airportModel = airportService.GetById(airportId);

            // Assert
            Assert.IsNotNull(airportModel);
        }

        [TestMethod]
        public void ReturnNull_WhenIdIsNull()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Airport>>();
            var dbContextMock = new Mock<IAirTicketDbContextSaveChanges>();

            var airportService = new AirportService(wrapperMock.Object, dbContextMock.Object);

            // Act
            var airportModel = airportService.GetById(null);

            // Assert
            Assert.IsNull(airportModel);
        }

        [TestMethod]
        public void ReturnNull_WhenThereIsNoModelWithThePassedId()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Airport>>();
            var dbContextMock = new Mock<IAirTicketDbContextSaveChanges>();

            Guid? airportId = Guid.NewGuid();

            wrapperMock.Setup(m => m.GetById(airportId.Value)).Returns((Airport)null);

            var airportService = new AirportService(wrapperMock.Object, dbContextMock.Object);

            // Act
            var airportModel = airportService.GetById(airportId);

            // Assert
            Assert.IsNull(airportModel);
        }
    }
}
