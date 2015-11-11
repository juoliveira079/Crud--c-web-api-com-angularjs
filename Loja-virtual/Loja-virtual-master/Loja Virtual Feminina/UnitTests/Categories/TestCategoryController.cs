using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja_Virtual_Feminina.Models.Modelo;
using Loja_Virtual_Feminina.Controllers;
using System.Web.Http.Results;
using System.Net;

namespace UnitTests.Categories
{
    [TestClass]
    public class TestCategoryController
    {
        [TestMethod]
        public void Post_Category_ShouldReturnSameCategory()
        {
            var controller = new CategoriesController(new TestCategoryContext());

            var item = GetDemoCategory();

            var result =
                controller.PostCategory(item) as CreatedAtRouteNegotiatedContentResult<Category>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.CategoryId);
            Assert.AreEqual(result.Content.Category_Name, item.Category_Name);
        }

        [TestMethod]
        public void Put_Category_ShouldReturnStatusCode()
        {
            var controller = new CategoriesController(new TestCategoryContext());

            var item = GetDemoCategory();

            var result = controller.PutCategory(item.CategoryId, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void Put_Category_Should_Fail_When_DifferentID()
        {
            var controller = new CategoriesController(new TestCategoryContext());

            var badresult = controller.PutCategory(999, GetDemoCategory());
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void Get_Category_Should_Return_Category_With_SameID()
        {
            var context = new TestCategoryContext();
            context.Categories.Add(GetDemoCategory());

            var controller = new CategoriesController(context);
            var result = controller.GetCategory(3) as OkNegotiatedContentResult<Category>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.CategoryId);
        }

        [TestMethod]
        public void Get_Categories_Should_Return_AllCategories()
        {
            var context = new TestCategoryContext();
            context.Categories.Add(new Category { CategoryId = 1, Category_Name ="Demo1"});
            context.Categories.Add(new Category { CategoryId = 2, Category_Name = "Demo2" });
            context.Categories.Add(new Category { CategoryId = 3, Category_Name = "Demo3" });

            var controller = new CategoriesController(context);
            var result = controller.GetCategories() as TestCategoryDBset;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void Delete_Category_Should_ReturnOK()
        {
            var context = new TestCategoryContext();
            var item = GetDemoCategory();
            context.Categories.Add(item);

            var controller = new CategoriesController(context);
            var result = controller.DeleteCategory(3) as OkNegotiatedContentResult<Category>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.CategoryId, result.Content.CategoryId);
        }

        Category GetDemoCategory()
        {
            return new Category() { CategoryId = 3, Category_Name="Modas"};
        }
    }
}
