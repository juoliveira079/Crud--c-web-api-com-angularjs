using Loja_Virtual_Feminina.Models.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Virtual_Feminina.Interface.Categories
{
    public interface ICategoryContext : IDisposable
    {
        DbSet<Category> Categories { get; }
        int SaveChanges();
        void MarkAsModified(Category item);
    }
}
