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

namespace AirTickets.UnitTests.AirTickets.DataServices.FlightServiceTests
{
    [TestClass]
    public class GetFlightByPrice_Should
    {
        [TestMethod]
        public void ReturnAllFlights_WithPriceEqualOrLessThanEntered()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Flight>>();
            var dbContextMock = new Mock<IAirTicketDbContextSaveChanges>();

            var models = new List<Flight>();

            wrapperMock.Setup(x => x.All).Returns(models.AsQueryable());

            var flightService = new FlightService(wrapperMock.Object, dbContextMock.Object);

            // Act
            var result = flightService.GetFlightByPrice(100);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
