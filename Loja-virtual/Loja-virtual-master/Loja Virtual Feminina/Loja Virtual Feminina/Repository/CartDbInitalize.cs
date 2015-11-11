using Loja_Virtual_Feminina.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Loja_Virtual_Feminina.Repository
{
    public class CartDbInitalize : DropCreateDatabaseIfModelChanges<CartContext>
    {
        protected override void Seed(CartContext context)
        {
            context.Carts.Add(
               new Cart
               {                                                                      
                CartId = 1,
                Cart_Product = "Vestido",
                Client = "Joana",
                Total = 177
               });

            context.Carts.Add(
              new Cart
              {
                CartId = 2,
                Cart_Product = "Blusa",
                Client = "Joana",
                Total = 177
              });
           
            context.SaveChanges();
            base.Seed(context);
        }
    }
}