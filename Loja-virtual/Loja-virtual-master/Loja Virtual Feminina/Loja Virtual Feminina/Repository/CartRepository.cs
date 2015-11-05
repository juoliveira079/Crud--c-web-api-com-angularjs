using Loja_Virtual_Feminina.Models;
using Loja_Virtual_Feminina.Models.Context;
using Loja_Virtual_Feminina.Models.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loja_Virtual_Feminina.Repository
{
    public class CartRepository
    {
        CartContext context = new CartContext();
        public void Add(Cart b)
        {
            context.Carts.Add(b);
            context.SaveChanges();
        }

        public void Edit(Cart b)
        {
            context.Entry(b).State = System.Data.Entity.EntityState.Modified;

        }

        public void Remove(int Id)
        {
            Cart b = context.Carts.Find(Id);
            context.Carts.Remove(b);
            context.SaveChanges();
        }

        public IEnumerable<Cart> GetCategories()
        {
            return context.Carts;
        }

        public Cart FindById(int Id)
        {
            var c = (from r in context.Carts where r.CartId == Id select r).FirstOrDefault();
            return c;
        }
    }
}