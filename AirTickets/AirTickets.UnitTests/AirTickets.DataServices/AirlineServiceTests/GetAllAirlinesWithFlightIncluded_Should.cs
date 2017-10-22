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

namespace AirTickets.UnitTests.AirTickets.DataServices.AirlineServiceTests
{
    [TestClass]
    public class GetAllAirlinesWithFlightIncluded_Should
    {
        [TestMethod]
        public void ReturnAllAirlines_WhenPassetParametersAreCorrect()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Airline>>();
            var dbContextMock = new Mock<IAirTicketDbContextSaveChanges>();

            var models = new List<Airline>() { new Airline { Name = "BulgariaAir" } };

            wrapperMock.Setup(x => x.AllWithInclude(y => y.Flights)).Returns(models.AsQueryable());

            var airlineService = new AirlineService(wrapperMock.Object, dbContextMock.Object);

            // Act
            var result = airlineService.GetAllAirlinesWithFlightsIncluded();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void ReturnAirlineModel_WhenPassetParametersAreCorrect()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Airline>>();
            var dbContextMock = new Mock<IAirTicketDbContextSaveChanges>();

            var models = new List<Airline>();

            wrapperMock.Setup(x => x.AllWithInclude(y => y.Flights)).Returns(models.AsQueryable());

            var airlineService = new AirlineService(wrapperMock.Object, dbContextMock.Object);

            // Act
            var result = airlineService.GetAllAirlinesWithFlightsIncluded();

            // Assert
            Assert.IsTrue(new List<AirlineModel>().SequenceEqual(result));
        }
    }
}
