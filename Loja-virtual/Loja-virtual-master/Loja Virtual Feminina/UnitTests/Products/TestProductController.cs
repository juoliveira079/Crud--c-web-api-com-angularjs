using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja_Virtual_Feminina.Controllers;
using Loja_Virtual_Feminina.Models;
using System.Net;
using System.Web.Http.Results;

namespace UnitTests.Users
{
    [TestClass]
    public class TestProductController
    {
        [TestMethod]
        public void Post_Product_ShouldReturnSameProduct()
        {
            var controller = new ProductsController(new TestProductContext());

            var item = GetDemoProduct();

            var result =
                controller.PostProduct(item) as CreatedAtRouteNegotiatedContentResult<Product>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.ProductId);
            Assert.AreEqual(result.Content.ProductName, item.ProductName);
        }

        [TestMethod]
        public void Put_Product_ShouldReturnStatusCode()
        {
            var controller = new ProductsController(new TestProductContext());

            var item = GetDemoProduct();

            var result = controller.PutProduct(item.ProductId, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void Put_Product_Should_Fail_When_DifferentID()
        {
            var controller = new ProductsController(new TestProductContext());

            var badresult = controller.PutProduct(999, GetDemoProduct());
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void Get_Product_Should_Return_Product_With_SameID()
        {
            var context = new TestProductContext();
            context.Products.Add(GetDemoProduct());

            var controller = new ProductsController(context);
            var result = controller.GetProduct(3) as OkNegotiatedContentResult<Product>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.ProductId);
        }

        [TestMethod]
        public void Get_Products_Should_Return_AllProducts()
        {
            var context = new TestProductContext();
            context.Products.Add(new Product { ProductId = 1, ProductName = "Demo1", Category_Product = "Roupas", Price = 187, Quantity = 2 });
            context.Products.Add(new Product { ProductId = 2, ProductName = "Demo2", Category_Product = "Roupas", Price = 187, Quantity = 2 });
            context.Products.Add(new Product { ProductId = 3, ProductName = "Demo3", Category_Product = "Roupas", Price = 187, Quantity = 2 });

            var controller = new ProductsController(context);
            var result = controller.GetProducts() as TestProductDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void Delete_Product_Should_ReturnOK()
        {
            var context = new TestProductContext();
            var item = GetDemoProduct();
            context.Products.Add(item);

            var controller = new ProductsController(context);
            var result = controller.DeleteProduct(3) as OkNegotiatedContentResult<Product>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.ProductId, result.Content.ProductId);
        }

        Product GetDemoProduct()
        {
            return new Product() { ProductId = 3, ProductName = "Demo1", Category_Product = "Roupas", Price =187, Quantity = 2 };
        }
    }
}
