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
using TestStack.FluentMVCTesting;

namespace AirTickets.UnitTests.AirTickets.Web.Controllers.FlightControllerTests
{
    [TestClass]
    public class AllFlight_Should
    {
        [TestMethod]
        public void NotReturnModels_WhenPassetParametersAreNotCorrect()
        {
            // Arrange
            var flightServiceMock = new Mock<IFlightService>();
            var airlineServiceMock = new Mock<IAirlineService>();

            var collection = new List<FlightModel>();

            flightServiceMock.Setup(x => x.GetAllFlights()).Returns(collection);

            var flightController = new FlightController(flightServiceMock.Object, airlineServiceMock.Object);

            // Act
            var result = flightController.AllFlights() as PartialViewResult;

            // Assert
            Assert.AreEqual(null, result.View);
        }

        [TestMethod]
        public void ReturnModels_WhenPassetParametersAreCorrect()
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

            flightServiceMock.Setup(x => x.GetAllFlights()).Returns(collectionFlightModels);

            var flightController = new FlightController(flightServiceMock.Object, airlineServiceMock.Object);

            // Act
            var result = flightController.AllFlights();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReturnExactNumberOfModels_WhenPassetParametersAreCorrect()
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

            flightServiceMock.Setup(x => x.GetAllFlights()).Returns(collectionFlightModels);

            var flightController = new FlightController(flightServiceMock.Object, airlineServiceMock.Object);

            var result = flightController.AllFlights();

            // Act
            var model = (List<FlightViewModel>)((PartialViewResult)result).Model;

            // Assert
            Assert.AreEqual(2, model.Count);
        }
    }
}
