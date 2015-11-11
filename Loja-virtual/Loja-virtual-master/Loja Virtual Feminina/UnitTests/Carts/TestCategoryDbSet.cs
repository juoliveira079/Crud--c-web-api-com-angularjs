using Loja_Virtual_Feminina.Models;
using Loja_Virtual_Feminina.Models.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Categories
{
    class TestCartDBset : TestDbSet<Cart>
    {
        public override Cart Find(params object[] keyValues)
        {
            return this.SingleOrDefault(cart => cart.CartId == (int)keyValues.Single());
        }
    }
}
