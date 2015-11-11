using Loja_Virtual_Feminina.Interface.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Loja_Virtual_Feminina.Models
{
    public class ProductContext : DbContext, IProductContext
    {

        public ProductContext()
            : base("name=DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<Product> Products { get; set; }

        public void MarkAsModified(Product item)
        {
            Entry(item).State = EntityState.Modified;
        }
    
    }
}
