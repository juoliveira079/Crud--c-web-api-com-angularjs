using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja_Virtual_Feminina.Models.Modelo;
using Loja_Virtual_Feminina.Controllers;
using System.Web.Http.Results;
using System.Net;
using Loja_Virtual_Feminina.Models;

namespace UnitTests.Categories
{
    [TestClass]
    public class TestCartController
    {
        [TestMethod]
        public void Post_Cart_ShouldReturnSameCart()
        {
            var controller = new CartsController(new TestCartContext());

            var item = GetDemoCart();

            var result =
                controller.PostCart(item) as CreatedAtRouteNegotiatedContentResult<Cart>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.CartId);
            Assert.AreEqual(result.Content.Cart_Product, item.Cart_Product);
        }

        [TestMethod]
        public void Put_Cart_ShouldReturnStatusCode()
        {
            var controller = new CartsController(new TestCartContext());

            var item = GetDemoCart();

            var result = controller.PutCart(item.CartId, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void Put_Cart_Should_Fail_When_DifferentID()
        {
            var controller = new CartsController(new TestCartContext());

            var badresult = controller.PutCart(999, GetDemoCart());
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void Get_Cart_Should_Return_Cart_With_SameID()
        {
            var context = new TestCartContext();
            context.Carts.Add(GetDemoCart());

            var controller = new CartsController(context);
            var result = controller.GetCart(3) as OkNegotiatedContentResult<Cart>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.CartId);
        }

        [TestMethod]
        public void Get_Cart_Should_Return_AllCarts()
        {
            var context = new TestCartContext();
            context.Carts.Add(new Cart { CartId = 1, Cart_Product = "Demo1", Client = "12", Total = 187 });
            context.Carts.Add(new Cart { CartId = 2, Cart_Product = "Demo2", Client = "12", Total = 187 });
            context.Carts.Add(new Cart { CartId = 3, Cart_Product = "Demo3", Client = "12", Total = 187 });

            var controller = new CartsController(context);
            var result = controller.GetCarts() as TestCartDBset;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void Delete_Cart_Should_ReturnOK()
        {
            var context = new TestCartContext();
            var item = GetDemoCart();
            context.Carts.Add(item);

            var controller = new CartsController(context);
            var result = controller.DeleteCart(3) as OkNegotiatedContentResult<Cart>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.CartId, result.Content.CartId);
        }

        Cart GetDemoCart()
        {
            return new Cart() { CartId = 3, Cart_Product="Demo1",Client="12",Total=187};
        }
    }
}
