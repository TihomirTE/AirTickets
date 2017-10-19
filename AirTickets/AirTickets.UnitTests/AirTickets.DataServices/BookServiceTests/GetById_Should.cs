using AirTickets.Data.Contracts;
using AirTickets.Data.Models;
using AirTickets.DataServices;
using AirTickets.DataServices.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace AirTickets.UnitTests.AirTickets.DataServices.BookServiceTests
{
    [TestClass]
    public class GetById_Should
    {
        //[TestMethod]
        //public void ReturnModel_WhenThereIsAModelWithThePassedId()
        //{
        //    // Arrange
        //    var wrapperMock = new Mock<IEfDbSetWrapper<Flight>>();
        //    var dbContextMock = new Mock<IAirTicketDbContextSaveChanges>();
        //    Guid? bookId = Guid.NewGuid();

        //    wrapperMock.Setup(m => m.GetById(bookId.Value)).Returns(new Flight() { Id = bookId.Value });

        //    FlightService bookService = new FlightService(wrapperMock.Object, dbContextMock.Object);

        //    // Act
        //    FlightModel bookModel = bookService.GetById(bookId);

        //    // Assert
        //    Assert.IsNotNull(bookModel);
        //}

        //[TestMethod]
        //public void ReturnNull_WhenIdIsNull()
        //{
        //    // Arrange
        //    var wrapperMock = new Mock<IEfDbSetWrapper<Flight>>();
        //    var dbContextMock = new Mock<IAirTicketDbContextSaveChanges>();
            
        //    FlightService bookService = new FlightService(wrapperMock.Object, dbContextMock.Object);

        //    // Act
        //    FlightModel bookModel = bookService.GetById(null);

        //    // Assert
        //    Assert.IsNull(bookModel);
        //}

        //[TestMethod]
        //public void ReturnNull_WhenThereIsNoModelWithThePassedId()
        //{
        //    // Arrange
        //    var wrapperMock = new Mock<IEfDbSetWrapper<Flight>>();
        //    var dbContextMock = new Mock<IAirTicketDbContextSaveChanges>();
        //    Guid? bookId = Guid.NewGuid();

        //    wrapperMock.Setup(m => m.GetById(bookId.Value)).Returns((Flight)null);

        //    FlightService bookService = new FlightService(wrapperMock.Object, dbContextMock.Object);

        //    // Act
        //    FlightModel bookModel = bookService.GetById(bookId);

        //    // Assert
        //    Assert.IsNull(bookModel);
        //}
    }
}