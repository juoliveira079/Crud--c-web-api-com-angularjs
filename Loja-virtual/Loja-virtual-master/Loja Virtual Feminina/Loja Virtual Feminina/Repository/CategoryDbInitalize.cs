using Loja_Virtual_Feminina.Models;
using Loja_Virtual_Feminina.Models.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Loja_Virtual_Feminina.Repository
{
    public class CategryDbInitalize : DropCreateDatabaseIfModelChanges<CategoryContext>
    {
        protected override void Seed(CategoryContext context)
        {
            context.Categories.Add(
               new Category
               {                                                                      
                  CategoryId =1,
                  Category_Name="Modas"
               });

            context.Categories.Add(
              new Category
              {
                  CategoryId = 2,
                  Category_Name = "Infantil"
              });
           
            context.SaveChanges();
            base.Seed(context);
        }
    }
}