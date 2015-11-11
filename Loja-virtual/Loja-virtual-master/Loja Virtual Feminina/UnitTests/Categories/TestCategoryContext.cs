using Loja_Virtual_Feminina.Interface.Categories;
using Loja_Virtual_Feminina.Models.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Categories
{
    class TestCategoryContext : ICategoryContext
    {
        public TestCategoryContext()
        {
            this.Categories = new TestCategoryDBset();
        }

        public DbSet<Category> Categories { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Category item) { }
        public void Dispose() { }
    }
}
