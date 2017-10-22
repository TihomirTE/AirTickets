using AirTickets.Data.Models.Enums;
using AirTickets.DataServices.Contracts;
using AirTickets.DataServices.Models;
using AirTickets.Web.Controllers;
using AirTickets.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TestStack.FluentMVCTesting;

namespace AirTickets.UnitTests.AirTickets.Controllers.BookControllerTests
{
    [TestClass]
    public class Details_Should
    {
        [TestMethod]
        public void ReturnViewWithModelWithCorrectProperties_WhenThereIsAModelWithThePassedId()
        {
            // Arrange
            var flightServiceMock = new Mock<IFlightService>();
            var airlineServiceMock = new Mock<IAirlineService>();
            var flightModel = new FlightModel()
            {
                Id = Guid.NewGuid(),
                Title = "BA123",
                Price = 50,
                Duration = TimeSpan.Parse("01:10:00"),
                TravelClass = TravelClass.First
            };

            var flightViewModel = new FlightViewModel(flightModel);

            flightServiceMock.Setup(m => m.GetById(flightModel.Id)).Returns(flightModel);

            var flightController = new FlightController(flightServiceMock.Object, airlineServiceMock.Object);

            // Act & Assert
            flightController
                .WithCallTo(b => b.Details(flightModel.Id))
                .ShouldRenderDefaultView()
                .WithModel<FlightViewModel>(viewModel =>
                {
                    Assert.AreEqual(flightModel.Title, viewModel.Title);
                    Assert.AreEqual(flightModel.Price, viewModel.Price);
                    Assert.AreEqual(flightModel.Duration, viewModel.Duration);
                    Assert.AreEqual(flightModel.TravelClass, viewModel.TravelClass);
                });
        }

        [TestMethod]
        public void ReturnViewWithEmptyModel_WhenThereNoModelWithThePassedId()
        {
            // Arrange
            var flightServiceMock = new Mock<IFlightService>();
            var airlineServiceMock = new Mock<IAirlineService>();

            var flightViewModel = new FlightViewModel();

            Guid? flightId = Guid.NewGuid();
            Guid? airlineId = Guid.NewGuid();

            flightServiceMock.Setup(m => m.GetById(flightId.Value)).Returns((FlightModel)null);
            //airlineServiceMock.Setup(m => m.GetById(airlineId.Value)).Returns((AirlineModel)null);

            var flightController = new FlightController(flightServiceMock.Object, airlineServiceMock.Object);

            // Act & Assert
            flightController
                .WithCallTo(b => b.Details(flightId.Value))
                .ShouldRenderDefaultView()
                .WithModel<FlightViewModel>(viewModel =>
                {
                    Assert.AreEqual(null, viewModel.Title);
                    Assert.AreEqual(0, viewModel.Price);
                    Assert.AreEqual(TimeSpan.Zero, viewModel.Duration);
                    Assert.AreEqual((TravelClass)0, viewModel.TravelClass);
                });
        }

        [TestMethod]
        public void ReturnViewWithEmptyModel_WhenParameterIsNull()
        {
            // Arrange
            var flightServiceMock = new Mock<IFlightService>();
            var airlineServiceMock = new Mock<IAirlineService>();

            var flightViewModel = new FlightViewModel();

            flightServiceMock.Setup(m => m.GetById(null)).Returns((FlightModel)null);

            var flightController = new FlightController(flightServiceMock.Object, airlineServiceMock.Object);

            // Act & Assert
            flightController
                .WithCallTo(b => b.Details(null))
                .ShouldRenderDefaultView()
                .WithModel<FlightViewModel>(viewModel =>
                {
                    Assert.AreEqual(null, viewModel.Title);
                    Assert.AreEqual(0, viewModel.Price);
                    Assert.AreEqual(TimeSpan.Zero, viewModel.Duration);
                    Assert.AreEqual((TravelClass)0, viewModel.TravelClass);
                });
        }
    }
}