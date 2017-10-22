using AirTickets.Data.Models.Enums;
using AirTickets.DataServices.Contracts;
using AirTickets.DataServices.Models;
using AirTickets.Web.Controllers;
using AirTickets.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AirTickets.UnitTests.AirTickets.Web.Controllers.FlightControllerTests
{
    [TestClass]
    public class FilteredFlights_Should
    {
        [TestMethod]
        public void ReturnAllFlightActionMethod_WhenPriceIsLessThanZero()
        {
            // Arrange
            var flightServiceMock = new Mock<IFlightService>();
            var airlineServiceMock = new Mock<IAirlineService>();

            var flightController = new FlightController(flightServiceMock.Object, airlineServiceMock.Object);

            // Act
            var result = (RedirectToRouteResult)flightController.FilteredFlights(-1);

            // Assert
            Assert.AreEqual("AllFlights", result.RouteValues["action"]);
        }

        [TestMethod]
        public void NoReturnFlight_WhenPriceIsLessThanExistingFlightsInDatabase()
        {
            // Arrange
            var flightServiceMock = new Mock<IFlightService>();
            var airlineServiceMock = new Mock<IAirlineService>();

            var collection = new List<FlightModel>();

            //var collectionFlighViewtModels = new List<FlightViewModel>();

            flightServiceMock.Setup(x => x.GetFlightByPrice(10)).Returns(collection);

            var flightController = new FlightController(flightServiceMock.Object, airlineServiceMock.Object);

            // Act
            var result = flightController.FilteredFlights(10) as PartialViewResult;

            // Assert
            Assert.AreEqual(null, result.View);
        }

        [TestMethod]
        public void ReturnFlights_WhitPriceLessThanTheInput()
        {
            // Arrange
            var flightServiceMock = new Mock<IFlightService>();
            var airlineServiceMock = new Mock<IAirlineService>();

            var collectionFlightModels = new List<FlightModel>();

            for (int i = 0; i < 2; i++)
            {
                var flightModel = new FlightModel()
                {
                    Id = Guid.NewGuid(),
                    Title = "BA123" + i,
                    Price = 50 + i,
                    Duration = TimeSpan.Parse("01:10:00") + TimeSpan.FromHours(i),
                    TravelClass = TravelClass.First
                };
                collectionFlightModels.Add(flightModel);
            }

            var collectionFlighViewtModels = new List<FlightViewModel>();

            flightServiceMock.Setup(x => x.GetFlightByPrice(100)).Returns(collectionFlightModels);

            var flightController = new FlightController(flightServiceMock.Object, airlineServiceMock.Object);

            // Act
            var result = flightController.FilteredFlights(100);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
