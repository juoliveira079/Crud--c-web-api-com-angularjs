using Loja_Virtual_Feminina.Interface.Categories;
using Loja_Virtual_Feminina.Models.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Loja_Virtual_Feminina.Models
{
    public class CategoryContext : DbContext, ICategoryContext
    {

        public CategoryContext()
            : base("name=DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<Category> Categories { get; set; }
        public void MarkAsModified(Category item)
        {
            Entry(item).State = EntityState.Modified;
        }
    
    }
}
