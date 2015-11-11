using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja_Virtual_Feminina.Controllers;
using Loja_Virtual_Feminina.Models;
using System.Net;
using System.Web.Http.Results;

namespace UnitTests.Users
{
    [TestClass]
    public class TestUserController
    {
        [TestMethod]
        public void Post_User_ShouldReturnSameUser()
        {
            var controller = new UsersController(new TestUserContext());

            var item = GetDemoUser();

            var result =
                controller.PostUser(item) as CreatedAtRouteNegotiatedContentResult<User>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.UserId);
            Assert.AreEqual(result.Content.Name, item.Name);
        }

        [TestMethod]
        public void Put_User_ShouldReturnStatusCode()
        {
            var controller = new UsersController(new TestUserContext());

            var item = GetDemoUser();

            var result = controller.PutUser(item.UserId, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void Put_User_Should_Fail_When_DifferentID()
        {
            var controller = new UsersController(new TestUserContext());

            var badresult = controller.PutUser(999, GetDemoUser());
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void Get_User_Should_Return_User_With_SameID()
        {
            var context = new TestUserContext();
            context.Users.Add(GetDemoUser());

            var controller = new UsersController(context);
            var result = controller.GetUser(3) as OkNegotiatedContentResult<User>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.UserId);
        }

        [TestMethod]
        public void Get_Users_Should_Return_AllUsers()
        {
            var context = new TestUserContext();
            context.Users.Add(new User { UserId = 1, Name = "Demo1", Cpf = "123654",  End="Rua Silva",     Phone="2759164"});
            context.Users.Add(new User { UserId = 2, Name = "Demo2", Cpf = "123563",  End = "Rua Almeida", Phone = "2759164" });
            context.Users.Add(new User { UserId = 3, Name = "Demo3", Cpf = "1234569", End = "Rua Casda",   Phone = "2759164" });

            var controller = new UsersController(context);
            var result = controller.GetUsers() as TestUserDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void Delete_User_Should_ReturnOK()
        {
            var context = new TestUserContext();
            var item = GetDemoUser();
            context.Users.Add(item);

            var controller = new UsersController(context);
            var result = controller.DeleteUser(3) as OkNegotiatedContentResult<User>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.UserId, result.Content.UserId);
        }

        User GetDemoUser()
        {
            return new User() { UserId = 3, Name = "Demo1", Cpf = "123654", End = "Rua Silva", Phone = "2759164" };
        }
    }
}
