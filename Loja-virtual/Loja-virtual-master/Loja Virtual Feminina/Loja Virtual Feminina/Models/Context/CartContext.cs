using Loja_Virtual_Feminina.Interface.Categories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Loja_Virtual_Feminina.Models
{
    public class CartContext : DbContext, ICartContext
    {
        

        public CartContext()
            : base("name=DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<Cart> Carts { get; set; }

        public void MarkAsModified(Cart item)
        {
            Entry(item).State = EntityState.Modified;
        }
    
    }
}
