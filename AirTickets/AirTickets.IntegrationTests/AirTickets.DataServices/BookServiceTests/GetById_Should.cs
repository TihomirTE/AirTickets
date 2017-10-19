using AirTickets.Data;
using AirTickets.Data.Models;
using AirTickets.DataServices.Contracts;
using AirTickets.DataServices.Models;
using AirTickets.Web.App_Start;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Linq;

namespace AirTickets.IntegrationTests.AirTickets.DataServices.BookServiceTests
{
    [TestClass]
    public class GetById_Should
    {
        //private static Airline dbCategory = new Airline()
        //{
        //    Id = Guid.NewGuid(),
        //    Name = "category"
        //};

        //private static Flight dbBook = new Flight()
        //{
        //    Id = Guid.NewGuid(),
        //    Author = "author",
        //    Description = "description",
        //    ISBN = "ISBN",
        //    Title = "title",
        //    WebSite = "website"
        //};

        //private static IKernel kernel;

        //[TestInitialize]
        //public void TestInit()
        //{
        //    kernel = NinjectWebCommon.CreateKernel();
        //    AirTicketEfDbContext dbContext = kernel.Get<AirTicketEfDbContext>();
            
        //    dbContext.Categories.Add(dbCategory);
        //    dbContext.SaveChanges();

        //    var category = dbContext.Categories.Single();
        //    dbBook.CategoryId = category.Id;
        //    dbBook.Category = category;

        //    dbContext.Books.Add(dbBook);
        //    dbContext.SaveChanges();
        //}
        
        //[TestCleanup]
        //public void TestCleanup()
        //{
        //    AirTicketEfDbContext dbContext = kernel.Get<AirTicketEfDbContext>();
            
        //    dbContext.Categories.Attach(dbCategory);
        //    dbContext.Categories.Remove(dbCategory);

        //    dbContext.SaveChanges();
        //}

        //[TestMethod]
        //public void ReturnModelWithCorrectProperties_WhenThereIsAModelWithThePassedId()
        //{
        //    // Arrange
        //    IFlightService bookService = kernel.Get<IFlightService>();

        //    // Act
        //    FlightModel result = bookService.GetById(dbBook.Id);

        //    // Assert
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(dbBook.Id, result.Id);
        //    Assert.AreEqual(dbBook.Author, result.Duration);
        //    Assert.AreEqual(dbBook.ISBN, result.ISBN);
        //    Assert.AreEqual(dbBook.Title, result.Title);
        //    Assert.AreEqual(dbBook.WebSite, result.WebSite);
        //    Assert.AreEqual(dbBook.Description, result.Description);
        //}

        //[TestMethod]
        //public void ReturnNull_WhenIdIsNull()
        //{
        //    // Arrange
        //    IFlightService bookService = kernel.Get<IFlightService>();

        //    // Act
        //    FlightModel bookModel = bookService.GetById(null);

        //    // Assert
        //    Assert.IsNull(bookModel);
        //}

        //[TestMethod]
        //public void ReturnNull_WhenThereIsNoModelWithThePassedId()
        //{
        //    // Arrange
        //    IFlightService bookService = kernel.Get<IFlightService>();

        //    // Act
        //    FlightModel bookModel = bookService.GetById(Guid.NewGuid());

        //    // Assert
        //    Assert.IsNull(bookModel);
        //}
    }
}