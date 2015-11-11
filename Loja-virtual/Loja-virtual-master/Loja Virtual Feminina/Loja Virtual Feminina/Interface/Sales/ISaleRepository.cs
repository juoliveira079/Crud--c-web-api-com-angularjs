using Loja_Virtual_Feminina.Models;
using Loja_Virtual_Feminina.Models.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Virtual_Feminina.Interface
{
    interface ISaleRepository
    {
        void Add(Sale b);
        void Edit(Sale b);
        void Remove(Sale b);
        IEnumerable<Sale> GetSales();
        Sale FindById(int Id);
    }
}
