using AirTickets.Data;
using AirTickets.Data.Models;
using AirTickets.DataServices.Contracts;
using AirTickets.Web.App_Start;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AirTickets.IntegrationTests.AirTickets.DataServices.CategoryServiceTests
{
    //[TestClass]
    //public class GetAllCategoriesSortedById_Should
    //{
    //    private static List<Airline> dbCategories = new List<Data.Models.Airline>() {
    //        new Airline()
    //        {
    //            Id = Guid.NewGuid(),
    //            Name = "category 1"
    //        },
    //        new Airline()
    //        {
    //            Id = Guid.NewGuid(),
    //            Name = "category 2"
    //        },
    //        new Airline()
    //        {
    //            Id = Guid.NewGuid(),
    //            Name = "category 3"
    //        }
    //    };

    //    private static Flight dbBook = new Flight()
    //    {
    //        Id = Guid.NewGuid(),
    //        Author = "author",
    //        Description = "description",
    //        ISBN = "ISBN",
    //        Title = "title",
    //        WebSite = "website"
    //    };

    //    private static IKernel kernel;

    //    [TestInitialize]
    //    public void TestInit()
    //    {
    //        kernel = NinjectWebCommon.CreateKernel();
    //        AirTicketEfDbContext dbContext = kernel.Get<AirTicketEfDbContext>();

    //        foreach (Airline dbCategory in dbCategories)
    //        {
    //            dbContext.Categories.Add(dbCategory);
    //        }

    //        dbContext.SaveChanges();

    //        var category = dbContext.Categories.First();
    //        dbBook.CategoryId = category.Id;
    //        dbBook.Category = category;

    //        dbContext.Books.Add(dbBook);
    //        dbContext.SaveChanges();
    //    }

    //    [TestCleanup]
    //    public void TestCleanup()
    //    {
    //        AirTicketEfDbContext dbContext = kernel.Get<AirTicketEfDbContext>();
            
    //        foreach (Airline dbCategory in dbCategories)
    //        {
    //            dbContext.Categories.Attach(dbCategory);
    //            dbContext.Categories.Remove(dbCategory);
    //        }

    //        dbContext.SaveChanges();
    //    }

    //    [TestMethod]
    //    public void ReturnAllCategoriesSortedById()
    //    {
    //        // Arrange
    //        IAirlineService categoryService = kernel.Get<IAirlineService>();

    //        var expectedOrder = dbCategories.OrderBy(c => c.Id).ToList();

    //        // Act
    //        var result = categoryService.GetAllCategoriesSortedById().ToList();

    //        // Assert
    //        for (int i = 0; i < expectedOrder.Count; i++)
    //        {
    //            Assert.AreEqual(expectedOrder[i].Id, result[i].Id);
    //        }
    //    }
    //}
}
