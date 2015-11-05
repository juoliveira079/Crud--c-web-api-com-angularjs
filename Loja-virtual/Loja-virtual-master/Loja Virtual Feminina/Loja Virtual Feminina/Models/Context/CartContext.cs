using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Loja_Virtual_Feminina.Models
{
   
        public class CartContext : DbContext
        {
            public CartContext()
                : base("name=DefaultConnection")
            {
                base.Configuration.ProxyCreationEnabled = false;
            }

            public DbSet<Cart> Carts { get; set; }
        }
    
}