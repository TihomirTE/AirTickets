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
        //[TestMethod]
        //public void ReturnViewWithModelWithCorrectProperties_WhenThereIsAModelWithThePassedId()
        //{
        //    // Arrange
        //    var bookServiceMock = new Mock<IFlightService>();
        //    var categoryServiceMock = new Mock<IAirlineService>();
        //    var bookModel = new FlightModel() 
        //    {
        //        Id = Guid.NewGuid(),
        //        Duration = "author",
        //        Description = "description",
        //        ISBN = "ISBN",
        //        Title = "title",
        //        WebSite = "website"
        //    };

        //    var bookViewModel = new BookViewModel(bookModel);

        //    bookServiceMock.Setup(m => m.GetById(bookModel.Id)).Returns(bookModel);

        //    BookController bookController = new BookController(bookServiceMock.Object, categoryServiceMock.Object);

        //    // Act & Assert
        //    bookController
        //        .WithCallTo(b => b.Details(bookModel.Id))
        //        .ShouldRenderDefaultView()
        //        .WithModel<BookViewModel>(viewModel =>
        //        {
        //            Assert.AreEqual(bookModel.Duration, viewModel.Author);
        //            Assert.AreEqual(bookModel.ISBN, viewModel.ISBN);
        //            Assert.AreEqual(bookModel.Title, viewModel.Title);
        //            Assert.AreEqual(bookModel.WebSite, viewModel.WebSite);
        //            Assert.AreEqual(bookModel.Description, viewModel.Description);
        //        });
        //}

        //[TestMethod]
        //public void ReturnViewWithEmptyModel_WhenThereNoModelWithThePassedId()
        //{
        //    // Arrange
        //    var bookServiceMock = new Mock<IFlightService>();
        //    var categoryServiceMock = new Mock<IAirlineService>();

        //    var bookViewModel = new BookViewModel();

        //    Guid? bookId = Guid.NewGuid();
        //    bookServiceMock.Setup(m => m.GetById(bookId.Value)).Returns((FlightModel)null);

        //    BookController bookController = new BookController(bookServiceMock.Object, categoryServiceMock.Object);

        //    // Act & Assert
        //    bookController
        //        .WithCallTo(b => b.Details(bookId.Value))
        //        .ShouldRenderDefaultView()
        //        .WithModel<BookViewModel>(viewModel =>
        //        {
        //            Assert.IsNull(viewModel.Author);
        //            Assert.IsNull(viewModel.ISBN);
        //            Assert.IsNull(viewModel.Title);
        //            Assert.IsNull(viewModel.WebSite);
        //            Assert.IsNull(viewModel.Description);
        //        });
        //}

        //[TestMethod]
        //public void ReturnViewWithEmptyModel_WhenParameterIsNull()
        //{
        //    // Arrange
        //    var bookServiceMock = new Mock<IFlightService>();
        //    var categoryServiceMock = new Mock<IAirlineService>();

        //    var bookViewModel = new BookViewModel();
            
        //    bookServiceMock.Setup(m => m.GetById(null)).Returns((FlightModel)null);

        //    BookController bookController = new BookController(bookServiceMock.Object, categoryServiceMock.Object);

        //    // Act & Assert
        //    bookController
        //        .WithCallTo(b => b.Details(null))
        //        .ShouldRenderDefaultView()
        //        .WithModel<BookViewModel>(viewModel =>
        //        {
        //            Assert.IsNull(viewModel.Author);
        //            Assert.IsNull(viewModel.ISBN);
        //            Assert.IsNull(viewModel.Title);
        //            Assert.IsNull(viewModel.WebSite);
        //            Assert.IsNull(viewModel.Description);
        //        });
        //}
    }
}