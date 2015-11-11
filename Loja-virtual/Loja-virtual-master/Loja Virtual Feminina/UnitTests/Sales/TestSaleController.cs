using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja_Virtual_Feminina.Controllers;
using Loja_Virtual_Feminina.Models;
using System.Web.Http.Results;
using System.Net;

namespace UnitTests.Sales
{
    [TestClass]
    public class TestSaleController
    {
        [TestMethod]
        public void Post_Sale_ShouldReturnSameSale()
        {
            var controller = new SalesController(new TestSaleContext());

            var item = GetDemoSale();

            var result =
                controller.PostSale(item) as CreatedAtRouteNegotiatedContentResult<Sale>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.SaleId);
            Assert.AreEqual(result.Content.User_Sale, item.User_Sale);
        }
        [TestMethod]
        public void Put_Sale_ShouldReturnStatusCode()
        {
            var controller = new SalesController(new TestSaleContext());

            var item = GetDemoSale();

            var result = controller.PutSale(item.SaleId, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void Put_Sale_Should_Fail_When_DifferentID()
        {
            var controller = new SalesController(new TestSaleContext());

            var badresult = controller.PutSale(999, GetDemoSale());
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        [TestMethod]

        public void Get_Sale_Should_Return_Sale_With_SameID()
        {
            var context = new TestSaleContext();
            context.Sales.Add(GetDemoSale());

            var controller = new SalesController(context);
            var result = controller.GetSale(3) as OkNegotiatedContentResult<Sale>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.SaleId);
        }

        [TestMethod]
        public void Get_Sale_Should_Return_AllSales()
        {
            var context = new TestSaleContext();
            context.Sales.Add(new Sale { SaleId = 1, User_Sale = "user1", Cart_Sale = 1, Product_Sale = "Vestido", Total_Sale = 1897 });
            context.Sales.Add(new Sale { SaleId = 2, User_Sale = "user2", Cart_Sale = 1, Product_Sale = "Vestido", Total_Sale = 1897 });
            context.Sales.Add(new Sale { SaleId = 3, User_Sale = "user3", Cart_Sale = 1, Product_Sale ="Vestido",  Total_Sale=1897});

            var controller = new SalesController(context);
            var result = controller.GetSales() as TestSaleDBset;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void Delete_Sale_Should_ReturnOK()
        {
            var context = new TestSaleContext();
            var item = GetDemoSale();
            context.Sales.Add(item);

            var controller = new SalesController(context);
            var result = controller.DeleteSale(3) as OkNegotiatedContentResult<Sale>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.SaleId, result.Content.SaleId);
        }

        Sale GetDemoSale()
        {
            return new Sale() { SaleId=3,User_Sale="user1",Cart_Sale=1,Product_Sale="Vestido",Total_Sale=1897};
        }
    }
}
