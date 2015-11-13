using Loja_Virtual_Feminina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Users
{
    class TestProductDbSet : TestDbSet<Product>
    {
        public override Product Find(params object[] keyValues)
        {
            return this.SingleOrDefault(product => product.ProductId == (int)keyValues.Single());
        }
    }
}
