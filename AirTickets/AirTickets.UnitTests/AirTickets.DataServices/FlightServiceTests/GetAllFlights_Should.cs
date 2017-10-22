using AirTickets.Data.Contracts;
using AirTickets.Data.Models;
using AirTickets.Data.Models.Enums;
using AirTickets.DataServices;
using AirTickets.DataServices.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.UnitTests.AirTickets.DataServices.FlightServiceTests
{
    [TestClass]
    public class GetAllFlights_Should
    {
        [TestMethod]
        public void ReturnAllFlights_WhenPassetParametersAreCorrect()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Flight>>();
            var dbContextMock = new Mock<IAirTicketDbContextSaveChanges>();

            var models = new List<Flight>();

            wrapperMock.Setup(x => x.AllWithInclude(y => y.Airline)).Returns(models.AsQueryable());

            var flightService = new FlightService(wrapperMock.Object, dbContextMock.Object);

            // Act
            var result = flightService.GetAllFlights();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReturnNoFlights_WhenPassetParametersAreNotCorrect()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Flight>>();
            var dbContextMock = new Mock<IAirTicketDbContextSaveChanges>();

            var models = new List<Flight>(0);

            wrapperMock.Setup(x => x.AllWithInclude(y => y.Airline)).Returns(models.AsQueryable());

            var flightService = new FlightService(wrapperMock.Object, dbContextMock.Object);

            // Act
            var result = flightService.GetAllFlights();

            // Assert
            Assert.IsTrue(new List<FlightModel>().SequenceEqual(result));
        }
    }
}
