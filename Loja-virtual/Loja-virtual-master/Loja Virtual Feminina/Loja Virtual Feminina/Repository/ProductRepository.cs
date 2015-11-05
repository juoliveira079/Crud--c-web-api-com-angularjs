using Loja_Virtual_Feminina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loja_Virtual_Feminina.Repository
{
    public class ProductRepository
    {
        ProductContext context = new ProductContext();
        public void Add(Product b)
        {
            context.Products.Add(b);
            context.SaveChanges();
        }

        public void Edit(Product b)
        {
            context.Entry(b).State = System.Data.Entity.EntityState.Modified;

        }

        public void Remove(int Id)
        {
            Product b = context.Products.Find(Id);
            context.Products.Remove(b);
            context.SaveChanges();
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products;
        }

        public Product FindById(int Id)
        {
            var c = (from r in context.Products where r.ProductId == Id select r).FirstOrDefault();
            return c;
        }
    }
}