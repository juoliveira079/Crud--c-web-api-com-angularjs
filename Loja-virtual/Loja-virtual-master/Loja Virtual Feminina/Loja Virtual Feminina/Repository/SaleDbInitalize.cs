using Loja_Virtual_Feminina.Models;
using Loja_Virtual_Feminina.Models.Context;
using Loja_Virtual_Feminina.Models.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Loja_Virtual_Feminina.Repository
{
    public class SaleDbInitalize : DropCreateDatabaseIfModelChanges<SaleContext>
    {
        protected override void Seed(SaleContext context)
        {
            context.Sales.Add(
               new Sale
               {                                                                      
                SaleId=1,
                Cart_Sale=2,
                Product_Sale="Roupas",
                User_Sale="Joana",
                Total_Sale=1233
               });

            context.Sales.Add(
              new Sale
              {
                  SaleId = 2,
                  Cart_Sale = 3,
                  Product_Sale = "Roupas",
                  User_Sale = "Joao",
                  Total_Sale = 345
              });
           
            context.SaveChanges();
            base.Seed(context);
        }
    }
}