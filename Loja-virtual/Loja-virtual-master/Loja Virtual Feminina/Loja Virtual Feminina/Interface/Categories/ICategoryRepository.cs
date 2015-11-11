using Loja_Virtual_Feminina.Models;
using Loja_Virtual_Feminina.Models.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Virtual_Feminina.Interface
{
    interface ICategoryRepository
    {
        void Add(Category b);
        void Edit(Category b);
        void Remove(Category b);
        IEnumerable<Category> GetCategories();
        User FindById(int Id);
    }
}
