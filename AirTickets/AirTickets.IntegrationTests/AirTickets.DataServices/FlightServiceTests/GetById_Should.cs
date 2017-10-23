using AirTickets.Data;
using AirTickets.Data.Models;
using AirTickets.Data.Models.Enums;
using AirTickets.DataServices.Contracts;
using AirTickets.DataServices.Models;
using AirTickets.Web.App_Start;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Linq;

namespace AirTickets.IntegrationTests.AirTickets.DataServices.BookServiceTests
{
    //[TestClass]
    //public class GetById_Should
    //{
    //    private static Airline dbAirline = new Airline()
    //    {
    //        Id = Guid.NewGuid(),
    //        Name = "BulgariaAir"
    //    };

    //    private static Airport dbAirport = new Airport()
    //    {
    //        Id = Guid.NewGuid(),
    //        Name = "Sofia",
    //        AirportCode = "LBSF"
    //    };

    //    private static Flight dbFlight = new Flight()
    //    {
    //        Id = Guid.NewGuid(),
    //        Title = "BA123",
    //        Price = 120,
    //        Duration = TimeSpan.Parse("02:02:00"),
    //        TravelClass = TravelClass.Business,
    //        Airline = dbAirline,
    //        DepartureAirport = dbAirport,
    //        ArrivalAirport = dbAirport
    //    };

    //    private static IKernel kernel;

    //    [TestInitialize]
    //    public void TestInit()
    //    {
    //        kernel = NinjectWebCommon.CreateKernel();
    //        AirTicketEfDbContext dbContext = kernel.Get<AirTicketEfDbContext>();

    //        dbContext.Airlines.Add(dbAirline);
    //        dbContext.SaveChanges();

    //        dbContext.Airports.Add(dbAirport);
    //        dbContext.SaveChanges();

    //        //var airline = dbContext.Airlines.FirstOrDefault();
    //        //dbFlight.AirlineId = airline.Id;
    //        //dbFlight.Airline = airline;

    //        dbContext.Flights.Add(dbFlight);
    //        dbContext.SaveChanges();


    //    }

    //    [TestCleanup]
    //    public void TestCleanup()
    //    {
    //        AirTicketEfDbContext dbContext = kernel.Get<AirTicketEfDbContext>();

    //        dbContext.Airlines.Attach(dbAirline);
    //        dbContext.Airlines.Remove(dbAirline);

    //        dbContext.SaveChanges();
    //    }

    //    [TestMethod]
    //    public void ReturnModelWithCorrectProperties_WhenThereIsAModelWithThePassedId()
    //    {
    //        // Arrange
    //        IFlightService flightService = kernel.Get<IFlightService>();

    //        // Act
    //        FlightModel result = flightService.GetById(dbFlight.Id);

    //        // Assert
    //        Assert.IsNotNull(result);
    //        Assert.AreEqual(dbFlight.Id, result.Id);
    //        Assert.AreEqual(dbFlight.Title, result.Title);
    //        Assert.AreEqual(dbFlight.Price, result.Price);
    //        Assert.AreEqual(dbFlight.Duration, result.Duration);
    //        Assert.AreEqual(dbFlight.TravelClass, result.TravelClass);

    //    }

    //    [TestMethod]
    //    public void ReturnNull_WhenIdIsNull()
    //    {
    //        // Arrange
    //        IFlightService flightService = kernel.Get<IFlightService>();

    //        // Act
    //        FlightModel flightModel = flightService.GetById(null);

    //        // Assert
    //        Assert.IsNull(flightModel);
    //    }

    //    [TestMethod]
    //    public void ReturnNull_WhenThereIsNoModelWithThePassedId()
    //    {
    //        // Arrange
    //        IFlightService flightService = kernel.Get<IFlightService>();

    //        // Act
    //        FlightModel flightModel = flightService.GetById(Guid.NewGuid());

    //        // Assert
    //        Assert.IsNull(flightModel);
    //    }
    //}
}