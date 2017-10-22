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
    public class GetAllAirportsSortedByName_Should
    {
        [TestMethod]
        public void ReturnAllAirports_WhenPassetParametersAreCorrect()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Airport>>();
            var dbContextMock = new Mock<IAirTicketDbContextSaveChanges>();

            var models = new List<Airport>() { new Airport { Name = "Sofia", AirportCode = "LBSF" },
                                                new Airport { Name = "Plovdiv", AirportCode = "LBPD" }};

            wrapperMock.Setup(x => x.All).Returns(models.AsQueryable());

            var airportService = new AirportService(wrapperMock.Object, dbContextMock.Object);

            // Act
            var result = airportService.GetAllAirportsSortedByName();
            var expectedType = new List<AirportModel>();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void ReturnFlightModel_WhenPassetParametersAreCorrect()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Airport>>();
            var dbContextMock = new Mock<IAirTicketDbContextSaveChanges>();

            var models = new List<Airport>();

            wrapperMock.Setup(x => x.All).Returns(models.AsQueryable());

            var flightService = new AirportService(wrapperMock.Object, dbContextMock.Object);

            // Act
            var result = flightService.GetAllAirportsSortedByName();

            // Assert
            Assert.IsTrue(new List<AirportModel>().SequenceEqual(result));
        }
    }
}
