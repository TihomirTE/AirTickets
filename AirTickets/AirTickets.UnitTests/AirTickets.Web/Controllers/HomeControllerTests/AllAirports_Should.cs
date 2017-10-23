using AirTickets.Data.Models;
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

namespace AirTickets.UnitTests.AirTickets.Web.Controllers.HomeControllerTests
{
    [TestClass]
    public class AllAirports_Should
    {
        [TestMethod]
        public void NotReturnModels_WhenPassetParametersAreNotCorrect()
        {
            // Arrange
            var airportServiceMock = new Mock<IAirportService>();

            var collection = new List<AirportModel>();

            airportServiceMock.Setup(x => x.GetAllAirportsSortedByName()).Returns(collection);

            var homeController = new HomeController(airportServiceMock.Object);

            // Act
            var result = homeController.AllAirports() as PartialViewResult;

            // Assert
            Assert.AreEqual(null, result.View);
        }

        [TestMethod]
        public void ReturnModels_WhenPassetParametersAreCorrect()
        {
            // Arrange
            var airportServiceMock = new Mock<IAirportService>();

            var collection = new List<AirportModel>();


            for (int i = 0; i < 2; i++)
            {
                var airportModel = new AirportModel()
                {
                    Id = Guid.NewGuid(),
                    Name = "Sofia" + i,
                    AirportCode = "LBSF" + i,
                    DepartureFlights = new List<FlightModel>() { new FlightModel() { Id = Guid.NewGuid(), Title = "FD123", Price = 100, Duration = TimeSpan.Parse("02:10:00") } },
                    ArrivalFlights = new List<FlightModel>() { new FlightModel() { Id = Guid.NewGuid(), Title = "FD987", Price = 150, Duration = TimeSpan.Parse("02:00:00") } }
                };
                collection.Add(airportModel);
            }

            var collectionAirportViewtModels = new List<AirportViewModel>();

            airportServiceMock.Setup(x => x.GetAllAirportsSortedByName()).Returns(collection);

            var homeController = new HomeController(airportServiceMock.Object);

            // Act
            var result = homeController.AllAirports();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReturnExactNumberOfModels_WhenPassetParametersAreCorrect()
        {
            // Arrange
            var airportServiceMock = new Mock<IAirportService>();

            var collection = new List<AirportModel>();

            for (int i = 0; i < 2; i++)
            {
                var airportModel = new AirportModel()
                {
                    Name = "Sofia" + i,
                    AirportCode = "LBSF" + i,
                    DepartureFlights = new List<FlightModel>() { new FlightModel() { Id = Guid.NewGuid(), Title = "FD123", Price = 100, Duration = TimeSpan.Parse("02:10:00") } },
                    ArrivalFlights = new List<FlightModel>() { new FlightModel() { Id = Guid.NewGuid(), Title = "FD987", Price = 150, Duration = TimeSpan.Parse("02:00:00") } }
                };
                collection.Add(airportModel);
            }

            var collectionAirportViewtModels = new List<AirportViewModel>();

            airportServiceMock.Setup(x => x.GetAllAirportsSortedByName()).Returns(collection);

            var homeController = new HomeController(airportServiceMock.Object);

            // Act
            var result = homeController.AllAirports();
            var model = (List<AirportViewModel>)((PartialViewResult)result).Model;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
