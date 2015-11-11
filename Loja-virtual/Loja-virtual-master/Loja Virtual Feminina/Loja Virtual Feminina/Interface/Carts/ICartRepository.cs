using Loja_Virtual_Feminina.Models;
using Loja_Virtual_Feminina.Models.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Virtual_Feminina.Interface
{
    interface ICartRepository
    {
        void Add(Cart b);
        void Edit(Cart b);
        void Remove(Cart b);
        IEnumerable<Cart> GetCarts();
        Cart FindById(int Id);
    }
}
