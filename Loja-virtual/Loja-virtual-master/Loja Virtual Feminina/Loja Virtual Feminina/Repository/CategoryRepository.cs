using Loja_Virtual_Feminina.Models;
using Loja_Virtual_Feminina.Models.Context;
using Loja_Virtual_Feminina.Models.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loja_Virtual_Feminina.Repository
{
    public class CategoryRepository
    {
        CategoryContext context = new CategoryContext();
        public void Add(Category b)
        {
            context.Categories.Add(b);
            context.SaveChanges();
        }

        public void Edit(Category b)
        {
            context.Entry(b).State = System.Data.Entity.EntityState.Modified;

        }

        public void Remove(int Id)
        {
            Category b = context.Categories.Find(Id);
            context.Categories.Remove(b);
            context.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return context.Categories;
        }

        public Category FindById(int Id)
        {
            var c = (from r in context.Categories where r.CategoryId == Id select r).FirstOrDefault();
            return c;
        }
    }
}