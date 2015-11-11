using Loja_Virtual_Feminina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Virtual_Feminina.Interface
{
    interface IProductRepository
    {
        void Add(Product b);
        void Edit(Product b);
        void Remove(Product b);
        IEnumerable<Product> GetProducts();
        Product FindById(int Id);
    }
}
