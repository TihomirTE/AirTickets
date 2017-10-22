using AirTickets.Auth.Contracts;
using AirTickets.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestStack.FluentMVCTesting;

namespace AirTickets.UnitTests.AirTickets.Controllers.AccountControllerTests
{
    [TestClass]
    public class Login_Should
    {
        [TestMethod]
        public void ReturnViewWithReturnUrlInViewBag()
        {
            // Arrange
            var signInServiceMock = new Mock<ISignInService>();
            var userServiceMock = new Mock<IUserService>();

            string returnUrl = "url";

            AccountController accountController = new AccountController(signInServiceMock.Object, userServiceMock.Object);

            // Act & Assert
            accountController
                .WithCallTo(c => c.Login(returnUrl))
                .ShouldRenderDefaultView();

            Assert.AreEqual(returnUrl, accountController.ViewBag.ReturnUrl);
        }
    }
}