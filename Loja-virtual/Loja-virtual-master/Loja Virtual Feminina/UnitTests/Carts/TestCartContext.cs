using Loja_Virtual_Feminina.Interface.Categories;
using Loja_Virtual_Feminina.Models;
using Loja_Virtual_Feminina.Models.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Categories
{
    class TestCartContext : ICartContext
    {
        public TestCartContext()
        {
            this.Carts = new TestCartDBset();
        }

        public DbSet<Cart> Carts { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Cart item) { }
        public void Dispose() { }
    }
}
