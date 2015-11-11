using Loja_Virtual_Feminina.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Loja_Virtual_Feminina.Repository
{
   public class ProductDbInitalize : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            context.Products.Add(
               new Product
               {
                   ProductId = 1,
                   ProductName = "Vestido ",
                   Category_Product = "Roupas",
                   Quantity = 42,
                   Price = 174
               });

            context.Products.Add(
              new Product
              {
                  ProductId = 2,
                  ProductName = "Tenis ",
                  Category_Product = "Calçados",
                  Quantity = 12,
                  Price = 745
              });

           
            context.SaveChanges();

            base.Seed(context);
        }
    }
}